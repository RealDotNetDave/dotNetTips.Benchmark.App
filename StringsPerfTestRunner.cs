// ***********************************************************************
// Assembly         : dotNetTips.Benchmark.App
// Author           : david
// Created          : 08-27-2019
//
// Last Modified By : david
// Last Modified On : 08-28-2019
// ***********************************************************************
// <copyright file="StringsPerfTestRunner.cs" company="dotNetTips.Benchmark.App">
//     Copyright (c) David McCarter. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using dotNetTips.Utility.Standard.Tester;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace dotNetTips.Benchmark.App
{
    public class StringsPerfTestRunner : PerfTestRunner
    {

        private const string StringBuilderFormat = "value={0} ";
        private readonly int _collectionCount = 100;
        private readonly string _testWord1 = "rk3NlKKfVskL9brxuWytx2wm6";
        private readonly string _testWord2 = "JHaVoRDulOZLBrTrekYf5If8v";

        private string _longTestString = "Parsing and formatting are the lifeblood of any modern web applications or services: take data off the wire,  parse it, manipulate it, format it back out. As such, in .NET Core 2.1 along with bringing up Span<T>, we're invested in the formatting and parsing of  primitives, from Int32 to DateTime. Many of those changes can be read about in my previous blog posts, but one of the key factors in enabling those performance improvements was in moving a lot of native code to managed. That may be counter-intuitive, in that it’s “common knowledge” that C code is  faster than C# code. However, in addition to the gap between them narrowing, having (mostly) safe C# code has made the code base easier to experiment  in, so whereas we may have been skittish about tweaking the native implementations, the community-at-large has dived head first into optimizing  these implementations wherever possible. That effort continues in full force in .NET Core 3.0, with some very nice rewards reaped.";

        private byte[] _longTestStringEncodedUTF32;
        private byte[] _longTestStringEncodedUTF7;
        private string[] _stringArray;
        private Consumer _consumer = new Consumer();

        protected string LongTestString { get => this._longTestString; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var strings = new List<string>(this._collectionCount);

            for (int i = 0; i < this._collectionCount; i++)
            {
                strings.Add(RandomData.GenerateWord(25));
            }

            this._stringArray = strings.ToArray();

            _longTestStringEncodedUTF32 = Encoding.UTF32.GetBytes(LongTestString);
            _longTestStringEncodedUTF7 = Encoding.UTF7.GetBytes(LongTestString);
        }

        [Benchmark(Description = "COMBINE STRINGS:2 Strings with +")]
        public void TestCombineStrings01()
        {
            _consumer.Consume(_testWord1 + _testWord2);
        }

        [Benchmark(Description = "COMBINE STRINGS:2 strings with string.Concat()")]
        public void TestCombineStrings02()
        {
            _consumer.Consume(string.Concat(_testWord1, _testWord2));
        }

        [Benchmark(Description = "DECODING STRING:Encoding.UTF32")]
        public void TestDecodingString02()
        {
            _consumer.Consume(Encoding.UTF32.GetString(_longTestStringEncodedUTF32));
        }

        [Benchmark(Description = "DECODING STRING:Encoding.UTF7")]
        public void TestDecodingString03()
        {
            _consumer.Consume(Encoding.UTF7.GetString(_longTestStringEncodedUTF7));
        }

        [Benchmark(Description = "EMPTY STRING VALIDATION:IsNullOrEmpty()")]
        public void TestEmptyStringValidation01()
        {
            _consumer.Consume(string.IsNullOrEmpty(this._testWord1));
        }

        [Benchmark(Description = "EMPTY STRING VALIDATION:IsNullOrWhitespace()")]
        public void TestEmptyStringValidation02()
        {
            _consumer.Consume(string.IsNullOrWhiteSpace(this._testWord1));
        }

        [Benchmark(Description = "ENCODING STRING:Encoding.UTF32")]
        public void TestEncodingString03()
        {
            _consumer.Consume(Encoding.UTF32.GetBytes(LongTestString));
        }

        [Benchmark(Description = "ENCODING STRING:Encoding.UTF7")]
        public void TestEncodingString04()
        {
            _consumer.Consume(Encoding.UTF7.GetBytes(LongTestString));
        }

        [Benchmark(Description = "STRINGBUILDER:Append()")]
        public void TestStringBuilder01()
        {
            var sb = new StringBuilder();

            for (int count = 0; count < this._stringArray.Length; count++)
            {
                sb.Append(this._stringArray[count]);
            }

            _consumer.Consume(sb.ToString());
        }

        [Benchmark(Description = "STRINGBUILDER:AppendLine()")]
        public void TestStringBuilder02()
        {
            var sb = new StringBuilder();

            for (int arrayCount = 0; arrayCount < this._stringArray.Length; arrayCount++)
            {
                sb.AppendLine(this._stringArray[arrayCount]);
            }

            _consumer.Consume(sb.ToString());
        }

        [Benchmark(Description = "STRINGBUILDER:AppendFormat()")]
        public void TestStringBuilder03()
        {
            var sb = new StringBuilder();

            for (int arrayCount = 0; arrayCount < this._stringArray.Length; arrayCount++)
            {
                sb.AppendFormat(StringBuilderFormat, this._stringArray[arrayCount]);
            }

            _consumer.Consume(sb.ToString());
        }

        [Benchmark(Description = "STRINGBUILDER:AppendFormat(CurrentCulture)")]
        public void TestStringBuilder04()
        {
            var sb = new StringBuilder();

            for (int arrayCount = 0; arrayCount < _stringArray.Length; arrayCount++)
            {
                sb.AppendFormat(CultureInfo.CurrentCulture, StringBuilderFormat, _stringArray[arrayCount]);
            }

            _consumer.Consume(sb.ToString());
        }

        [Benchmark(Description = "STRING VALIDATION:Equals()")]
        public void TestStringWithEquals01()
        {
            _consumer.Consume(this._testWord1.Equals(this._testWord2));
        }

        [Benchmark(Description = "STRING VALIDATION:==")]
        public void TestStringWithEquals02()
        {
            _consumer.Consume(this._testWord1 == this._testWord2);
        }

        [Benchmark(Description = "STRING VALIDATION:Equals(CurrentCultureIgnoreCase)")]
        public void TestStringWithEquals03()
        {
            _consumer.Consume(_testWord1.Equals(_testWord2, StringComparison.CurrentCultureIgnoreCase));
        }

    }
}
