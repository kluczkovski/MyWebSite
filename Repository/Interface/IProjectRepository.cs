using System;
using System.Threading.Tasks;
using MyWebSite.Models;

namespace MyWebSite.Repository.Interface
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetProjectAndImages(Guid id);
    }
}
