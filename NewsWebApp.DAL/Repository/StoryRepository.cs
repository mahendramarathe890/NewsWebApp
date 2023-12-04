﻿using NewsWebApp.Core.Entities;
using NewsWebApp.Core.Interfaces;
using NewsWebApp.DAL.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.DAL.Repository
{
    public class StoryRepository : IStoryRepository
    {
        private static string _baseAPIUrl = "https://hacker-news.firebaseio.com";
        IDataService _dataService;

        public StoryRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Story> GetByIdAsync(int id)
        {
            
            string itemEndpoint = $"/v0/item/{id}.json?print=pretty";

            var item = await _dataService.GetData<Story>(_baseAPIUrl, itemEndpoint);

            return item;
        }

        public async Task<List<int>> GetNewStoriesAsync()
        {
            string newStoriesEndpoint = $"/v0/newstories.json?print=pretty";

            var newStories = await _dataService.GetAllData(_baseAPIUrl, newStoriesEndpoint);

            return newStories;
        }
    }
}
