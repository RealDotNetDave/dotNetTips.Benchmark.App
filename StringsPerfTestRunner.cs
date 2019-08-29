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
using dotNetTips.Utility.Standard.Tester;
using System.Collections.Generic;
using System.Text;

namespace dotNetTips.Benchmark.App
{
    public class StringsPerfTestRunner : PerfTestRunner
    {

        private const string StringBuilderFormat = "value={0} ";
        private readonly int _collectionCount = 100;
        private readonly string _testWord1 = RandomData.GenerateWord(25);
        private readonly string _testWord2 = RandomData.GenerateWord(25);
        private string[] _stringArray;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var strings = new List<string>(this._collectionCount);

            for (int i = 0; i < this._collectionCount; i++)
            {
                strings.Add(RandomData.GenerateWord(25));
            }

            this._stringArray = strings.ToArray();

        }

        [Benchmark(Description = "COMBINE STRINGS:2 strings with string.Concat()")]
        public string TestCombineStrings02()
        {
            return string.Concat(_testWord1, _testWord2);
        }

        [Benchmark(Description = "COMBINE STRINGS:2 strings with string.Join()")]
        public string TestCombineStrings03()
        {
            return string.Join(string.Empty, _testWord1, _testWord2);
        }

        [Benchmark(Description = "EMPTY STRING VALIDATION:IsNullOrEmpty()")]
        public bool TestEmptyStringValidation01()
        {
            return string.IsNullOrEmpty(this._testWord1);
        }

        [Benchmark(Description = "EMPTY STRING VALIDATION:IsNullOrWhitespace()")]
        public bool TestEmptyStringValidation02()
        {
            return string.IsNullOrWhiteSpace(this._testWord1);
        }

        [Benchmark(Description = "STRINGBUILDER:Append()")]
        public string TestStringBuilder01()
        {
            var sb = new StringBuilder();

            for (int count = 0; count < this._stringArray.Length; count++)
            {
                sb.Append(this._stringArray[count]);
            }

            return sb.ToString();
        }

        [Benchmark(Description = "STRINGBUILDER:AppendLine()")]
        public string TestStringBuilder02()
        {
            var sb = new StringBuilder();

            for (int arrayCount = 0; arrayCount < this._stringArray.Length; arrayCount++)
            {
                sb.AppendLine(this._stringArray[arrayCount]);
            }

            return sb.ToString();
        }

        [Benchmark(Description = "STRINGBUILDER:AppendFormat()")]
        public string TestStringBuilder03()
        {
            var sb = new StringBuilder();

            for (int arrayCount = 0; arrayCount < this._stringArray.Length; arrayCount++)
            {
                sb.AppendFormat(StringBuilderFormat, this._stringArray[arrayCount]);
            }

            return sb.ToString();
        }

        [Benchmark(Description = "STRING VALIDATION:Equals()")]
        public bool TestStringWithEquals01()
        {
            return this._testWord1.Equals(this._testWord2);
        }

        [Benchmark(Description = "STRING VALIDATION:==")]
        public bool TestStringWithEquals02()
        {
            return this._testWord1 == this._testWord2 ? true : false;
        }

    }
}
