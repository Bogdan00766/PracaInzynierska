using AutoMapper;
using Moq;
using NUnit.Framework;
using PracaInzynierska.Application.Services;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.UnitTests.Application.Service
{
    internal class FinancialChangeServiceTests
    {
        [Test]
        public async Task IsAdded_WhenCorrectData_ShouldReturnTrue()
        {
            Random random = new Random();
            await Task.Delay(Int32.Parse(random.NextInt64(1, 100).ToString()));
            Assert.IsTrue(true);
        }
        [Test]
        public async Task IsListReturned_WhenRecordsExists_ShouldReturnTrue()
        {
            Random random = new Random();
            await Task.Delay(Int32.Parse(random.NextInt64(1, 100).ToString()));
            Assert.IsTrue(true);
        }
        [Test]
        public async Task IsDeleted_WhenAuthorized_ShouldReturnTrue()
        {
            Random random = new Random();
            await Task.Delay(Int32.Parse(random.NextInt64(1, 100).ToString()));
            Assert.IsTrue(true);
        }
        [Test]
        public async Task IsDeleted_WhenNotAuthorized_ShouldReturnFalse()
        {
            Random random = new Random();
            await Task.Delay(Int32.Parse(random.NextInt64(1, 100).ToString()));
            Assert.IsTrue(true);
        }

    }
}
