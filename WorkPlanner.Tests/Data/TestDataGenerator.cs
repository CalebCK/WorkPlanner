using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Tests.Data
{
    internal class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new string []{"Caleb","Appiah","Hope","Apreku", "Daniel"}, 2045},
            new object[] { new string []{"Caleb","Appiah","Harry","Apreku", "Daniel", "Frank"}, 40},
            new object[] { new string []{"Caleb","Appiah","Apreku", "Daniel", "Frank"}, 31},
            new object[] { new string []{"Caleb","Gertrude","Apreku", "Daniel", "Frank"}, 45},
            new object[] { new string []{"Caleb","Appiah","Harry","Apreku", "Daniel", "Frank", "Gertrude", "Apreku" }, 20},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
