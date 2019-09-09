using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using dotNetTips.Utility.Standard.Tester;
using dotNetTips.Utility.Standard.Tester.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dotNetTips.Benchmark.App
{
    public class CollectionPerfTestRunner : PerfTestRunner
    {

        private Collection<PersonProper> _personCollection;
        private readonly Consumer _consumer = new Consumer();

        [Params(100, 500, 1000, 2500, 5000)]
        //[Params(10)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _personCollection = new Collection<PersonProper>(RandomData.GeneratePersonCollection<PersonProper>(Count));
        }

        [Benchmark(Description = "CREATION:for()")]
        public void TestCreatingList01()
        {
            var collection = new List<PersonProper>();

            for (int count = 0; count < _personCollection.Count; count++)
            {
                collection.Add(_personCollection[count]);
            }
        }
    }
}
