using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

[assembly: TestCollectionOrderer("Calculations.Test.TestCollectionOrder", "Calculations.Test")]

namespace Calculations.Test
{
    public class TestCollectionOrder : ITestCollectionOrderer
    {

        IEnumerable<ITestCollection> ITestCollectionOrderer.OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            return testCollections.OrderBy(c => c.DisplayName);
        }
    }
}
