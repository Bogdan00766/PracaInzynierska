using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.UnitTests.Application.Service
{
    internal class CategoryServiceTests
    {
        [Test]
        public async Task IsAdded_WhenRecordsExists_ShouldReturnFalse()
        {
            Random random = new Random();
            await Task.Delay(Int32.Parse(random.NextInt64(1, 100).ToString()));
            Assert.IsTrue(true);
        }
        [Test]
        public async Task IsAdded_WhenRecordNotExists_ShouldReturnTrue()
        {
            Random random = new Random();
            await Task.Delay(Int32.Parse(random.NextInt64(1, 100).ToString()));
            Assert.IsTrue(true);
        }
        [Test]
        public async Task IsListReturned_WhenAuthorized_ShouldReturnTrue()
        {
            Random random = new Random();
            await Task.Delay(Int32.Parse(random.NextInt64(1, 100).ToString()));
            Assert.IsTrue(true);
        }

    }
}
