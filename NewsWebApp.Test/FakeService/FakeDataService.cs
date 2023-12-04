using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NewsWebApp.DAL.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.Test.IntegrationTests.FakeService
{
    public class FakeDataService : IDataService
    {
        public async Task<List<int>> GetAllData(string baseurl, string jsonEndpoint)
        {
            return new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public async Task<T> GetData<T>(string baseurl, string jsonEndpoint)
        {
            T TObject = default(T);

            var response = "{'by' : 'ohjeez','descendants' : 0,'id' : 24179272,'score' : 1,'time' : 1597596808,'title' : 'Security Jobs with a Future – and Ones on the Way Out','type' : 'story','url' : 'https://www.darkreading.com/edge/theedge/security-jobs-with-a-future----and-ones-on-the-way-out/b/d-id/1338652'}";

            TObject = JsonConvert.DeserializeObject<T>(response);

            return TObject;
        }
    }
}
