using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FetchNStore1.DAL;
using System.Collections.Generic;
using FetchNStore1.Models;
using Moq;
using System.Data.Entity;
using System.Linq;
namespace FetchNStore1.Tests
{
    [TestClass]
    public class FetchStoreRepositoryTests
    {
        Mock<FetchStoreContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> response_list { get; set; } // Fake
        FetchStoreRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = response_list.AsQueryable();

            // Lie to LINQ make it think that our new Queryable List is a Database table.
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            // Have our Response property return our Queryable List AKA Fake database table.
            mock_context.Setup(c => c.Responses).Returns(mock_response_table.Object);

            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response a) => response_list.Add(a));
            mock_response_table.Setup(t => t.Remove(It.IsAny<Response>())).Callback((Response a) => response_list.Remove(a));
        }

        [TestInitialize]
        public void Initialize()
        {
            // Create Mock FetchStoreContext
            mock_context = new Mock<FetchStoreContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>(); // Fake
            repo = new FetchStoreRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null; // 
        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            FetchStoreRepository repo = new FetchStoreRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            FetchStoreRepository repo = new FetchStoreRepository();

            FetchStoreContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(FetchStoreContext));
        }

        [TestMethod]
        public void RepoEnsureWeHaveNoResponses()
        {
            // Arrange


            // Act
            List<Response> actual_responses = repo.GetResponses();
            int expected_response_count = 0;
            int actual_response_count = actual_responses.Count;

            // Assert
            Assert.AreEqual(expected_response_count, actual_response_count);
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
