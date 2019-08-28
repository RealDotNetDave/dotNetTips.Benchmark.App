// ***********************************************************************
// Assembly         : dotNetTips.Benchmark.App
// Author           : david
// Created          : 08-27-2019
//
// Last Modified By : david
// Last Modified On : 08-28-2019
// ***********************************************************************
// <copyright file="Program.cs" company="dotNetTips.Benchmark.App">
//     Copyright (c) David McCarter. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CsProj;
using System;

namespace dotNetTips.Benchmark.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = DefaultConfig.Instance.With(
                Job.Default.With(CsProjCoreToolchain.NetCoreApp30)).With(
                Job.Default.With(CsProjCoreToolchain.NetCoreApp22)).With(
                Job.Default.With(CsProjClassicNetToolchain.Net48)).With(
                Job.Default.With(CsProjClassicNetToolchain.Net472));

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAll(config);

            Console.Beep();
            Console.ReadLine();
        }
    }
}
