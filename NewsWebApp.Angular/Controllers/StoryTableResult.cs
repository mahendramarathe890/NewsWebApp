using NewsWebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Angular.Controllers
{
    public class StoryTableResult
    {
        public StoryTableResult()
        {

        }

        public StoryTableResult(List<Story> data, int pageIndex, int pageSize, int count)
        {
            this.Data = data;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = count;
        }

        public List<Story> Data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalPages { get => (int)Math.Ceiling(Count / (double)PageSize); }
    }
}
