using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using dotNetTips.Utility.Standard.Tester;
using dotNetTips.Utility.Standard.Tester.Models;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace dotNetTips.Benchmark.App
{
    public class CollectionPerfTestRunner : PerfTestRunner
    {

        private readonly Consumer _consumer = new Consumer();
        private Collection<PersonFixed> _personCollection;
        private ImmutableArray<PersonFixed> _personImmutableArray;
        private ImmutableList<PersonFixed> _personImmutableList;
        private ReadOnlyCollection<PersonFixed> _personReadOnlyCollection;

        [Params(100, 500, 1000, 2500, 5000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _personCollection = new Collection<PersonFixed>(RandomData.GeneratePersonCollection<PersonFixed>(Count));
            _personImmutableArray = ImmutableArray.Create<PersonFixed>(_personCollection.ToArray());
            _personImmutableList = ImmutableList.Create<PersonFixed>(_personCollection.ToArray());
            _personReadOnlyCollection = new ReadOnlyCollection<PersonFixed>(_personCollection);
        }

        [Benchmark(Description = "FOR():ImmutableArray")]
        public void TestLoopingCollectionFor03()
        {
            var collection = _personImmutableArray;

            for (int count = 0; count < collection.Count(); count++)
            {
                _consumer.Consume(collection[count]);
            }
        }

        [Benchmark(Description = "FOR():ImmutableList")]
        public void TestLoopingCollectionFor04()
        {
            var collection = _personImmutableList;

            for (int count = 0; count < collection.Count; count++)
            {
                _consumer.Consume(collection[count]);
            }
        }

        [Benchmark(Description = "FOR():ReadOnlyCollection")]
        public void TestLoopingCollectionFor08()
        {
            var collection = _personReadOnlyCollection;

            for (int count = 0; count < collection.Count; count++)
            {
                _consumer.Consume(collection[count]);
            }
        }

        [Benchmark(Description = "FOR():Collection")]
        public void TestLoopingCollectionFor10()
        {
            var collection = _personCollection;

            for (int count = 0; count < collection.Count; count++)
            {
                _consumer.Consume(collection[count]);
            }
        }

        [Benchmark(Description = "FOREACH():ImmutableList")]
        public void TestLoopingForEach05()
        {
            var collection = _personImmutableList;

            foreach (var person in collection)
            {
                _consumer.Consume(person);
            }
        }

        [Benchmark(Description = "FOREACH():ReadOnlyCollection")]
        public void TestLoopingForEach08()
        {
            var collection = _personReadOnlyCollection;

            foreach (var person in collection)
            {
                _consumer.Consume(person);
            }
        }

        [Benchmark(Description = "FOREACH():Collection")]
        public void TestLoopingForEach09()
        {
            var collection = _personCollection;

            foreach (var person in collection)
            {
                _consumer.Consume(person);
            }
        }

    }
}
