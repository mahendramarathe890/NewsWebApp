using NewsWebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Angular.Service
{
    public class CachedData : ICachedData
    {
        public Dictionary<int, Story> cachedData { get; set; }
        
        public Dictionary<int, Story> cachedShowingData { get; set; }
    }
}
