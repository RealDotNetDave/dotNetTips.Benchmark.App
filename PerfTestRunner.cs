// ***********************************************************************
// Assembly         : dotNetTips.Benchmark.App
// Author           : david
// Created          : 08-27-2019
//
// Last Modified By : david
// Last Modified On : 08-27-2019
// ***********************************************************************
// <copyright file="PerfTestRunner.cs" company="dotNetTips.Benchmark.App">
//     Copyright (c) David McCarter. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace dotNetTips.Benchmark.App
{
    /// <summary>
    /// Class PerfTestRunner.
    /// Implements the <see cref="Object" />
    /// </summary>
    /// <seealso cref="Object" />
    [CategoriesColumn]
    [EvaluateOverhead]
    [GcServer(true)]
    [HtmlExporter()]
    [Orderer(SummaryOrderPolicy.Method)]
    [RankColumn()]
    [CsvExporter()]
    [CsvMeasurementsExporter]
    //[RPlotExporter]
    //[DisassemblyDiagnoser(printSource: true, printIL: true, printDiff: true, printPrologAndEpilog: true)]
    //[ConcurrencyVisualizerProfiler()]
    //[EtwProfiler()]
    [MemoryDiagnoser()]
    [StopOnFirstError]
    public abstract class PerfTestRunner
    {
    }
}
