using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using dotNetTips.Utility.Standard.Tester;
using dotNetTips.Utility.Standard.Tester.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace dotNetTips.Benchmark.App
{
    public class CollectionPerfTestRunner : PerfTestRunner
    {

        private Collection<PersonProper> _personCollection;
        private ImmutableArray<PersonProper> _personImmutableArray;
        private ImmutableList<PersonProper> _personImmutableList;
        private ObservableCollection<PersonProper> _personObservableCollection;
        private ReadOnlyCollection<PersonProper> _personReadOnlyCollection;
        private readonly Consumer _consumer = new Consumer();

        [Params(100, 500, 1000, 2500, 5000)]
        //[Params(10)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _personCollection = new Collection<PersonProper>(RandomData.GeneratePersonCollection<PersonProper>(Count));
            _personImmutableArray = ImmutableArray.Create<PersonProper>(_personCollection.ToArray());
            _personImmutableList = ImmutableList.Create<PersonProper>(_personCollection.ToArray());
            _personObservableCollection = new ObservableCollection<PersonProper>(_personCollection);
            _personReadOnlyCollection = new ReadOnlyCollection<PersonProper>(_personCollection);
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

        [Benchmark(Description = "CREATION:for() with Capacity")]
        public void TestCreatingList02()
        {
            var collection = new List<PersonProper>(_personCollection.Count);

            for (int count = 0; count < _personCollection.Count; count++)
            {
                collection.Add(_personCollection[count]);
            }
        }

        [Benchmark(Description = "for():Collection")]
        public void TestFor01()
        {
            var collection = _personCollection;

            for (int count = 0; count < collection.Count(); count++)
            {
                _consumer.Consume((collection.ElementAt(count)));
            }
        }

        [Benchmark(Description = "for():ImmutableArray")]
        public void TestFor02()
        {
            var collection = _personImmutableArray;

            for (int count = 0; count < collection.Count(); count++)
            {
                _consumer.Consume((collection.ElementAt(count)));
            }
        }

        [Benchmark(Description = "for():ImmutableList")]
        public void TestFor03()
        {
            var collection = _personImmutableList;

            for (int count = 0; count < collection.Count(); count++)
            {
                _consumer.Consume((collection.ElementAt(count)));
            }
        }

        [Benchmark(Description = "for():ObservableCollection")]
        public void TestFor04()
        {
            var collection = _personObservableCollection;

            for (int count = 0; count < collection.Count(); count++)
            {
                _consumer.Consume((collection.ElementAt(count)));
            }
        }

        [Benchmark(Description = "for():ReadOnlyCollection")]
        public void TestFor05()
        {
            var collection = _personReadOnlyCollection;

            for (int count = 0; count < collection.Count(); count++)
            {
                _consumer.Consume((collection.ElementAt(count)));
            }
        }

        [Benchmark(Description = "RETRIEVING COLLECTION:HashSet")]
        public HashSet<PersonProper> TestRetrievingCollection01()
        {
            return _personCollection.ToHashSet();
        }

        [Benchmark(Description = "CREATING IMMUTABLE SORTED COLLECTION-CREATERANGE:ImmutableSortedSet<>")]
        public void TestCreatingImmutableSortedCollection01()
        {
            var collection = ImmutableSortedSet.CreateRange(_personCollection);
        }

        private static void ProcessPerson(IPerson person)
        {
            var name = person.FirstName;
        }

    }
}
