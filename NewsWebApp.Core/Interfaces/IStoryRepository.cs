using NewsWebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebApp.Core.Interfaces
{
    public interface IStoryRepository : IAsyncRepository<Story>
    {
    }
}
