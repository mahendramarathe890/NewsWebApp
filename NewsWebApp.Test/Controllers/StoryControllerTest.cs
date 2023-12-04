using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsWebApp.Angular.Controllers;
using NewsWebApp.Angular.Service;
using NewsWebApp.Core.Entities;
using NewsWebApp.Core.Interfaces;
using NewsWebApp.DAL.Service;
using NewsWebApp.Test.IntegrationTests.FakeRepository;
using NewsWebApp.Test.IntegrationTests.FakeService;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.Test.IntegrationTests
{
    [TestClass]
    public class StoryControllerTest
    {
        IDataService fakeDataService;
        IStoryRepository fakeStoryRepository;
        StoryController storyController;
        ICachedData fakeCachedData;

        string fakePageIndex;
        string fakeSize;

        [TestInitialize]
        public void SetUp()
        {
            fakeCachedData = new FakeCachedData();
            fakeDataService = new FakeDataService(); 
            fakeStoryRepository = new FakeStoryRepository(fakeDataService);
            storyController = new StoryController(fakeStoryRepository, fakeCachedData);

            fakePageIndex = "0";
            fakeSize = "10";
        }

        public StoryControllerTest()
        {
            
        }

        [TestMethod]
        public async Task Test_GetStories()
        {
            //Arrange
            var expectedCount = 3;

            //Act
            var stories = await storyController.GetStories(fakePageIndex, fakeSize);
            var resultStoriesCount = stories.Value.Data.Count;

            //Assert
            Assert.AreEqual(resultStoriesCount, expectedCount, "The expected row counts is not equals to the result data.");
        }

        
        [TestMethod]
        public async Task Test_GetFilteredStories()
        {
            //Arrange
            string testfilter = "title 1";
            var expectedFilteredCount = 1;

            //Act
            var filteredStories = await storyController.GetFilteredStories(testfilter);
            var resultFilteredStoriesCount = filteredStories.Value.Data.Count;

            //Assert
            Assert.AreEqual(resultFilteredStoriesCount, expectedFilteredCount, "The expected row counts is not equals to the result data.");
        }
    }
}
