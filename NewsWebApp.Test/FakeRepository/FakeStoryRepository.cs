using NewsWebApp.Core.Entities;
using NewsWebApp.Core.Interfaces;
using NewsWebApp.DAL.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.Test.IntegrationTests.FakeRepository
{
    public class FakeStoryRepository : IStoryRepository
    {
        IDataService _fakeDataservice;

        public FakeStoryRepository(IDataService fakeDataservice)
        {
            _fakeDataservice = fakeDataservice;
        }

        public async Task<Story> GetByIdAsync(int id)
        {
            string itemEndpoint = $"/v0/item/{id}.json?print=pretty";

            string _baseAPIUrl = "https://hacker-news.firebaseio.com";

            var item = await _fakeDataservice.GetData<Story>(_baseAPIUrl, itemEndpoint);

            return item;
        }

        public Task<List<int>> GetNewStoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
