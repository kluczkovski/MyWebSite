using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;
using MyWebSite.Repository.Interface;

namespace MyWebSite.Repository
{
    public class ProjectRepository : Repository<Project>,  IProjectRepository
    {
        public ProjectRepository(MyDBContext context) : base(context)
        {
        }

        public async Task<Project> GetProjectAndImages(Guid id)
        {
            return await context.Projects
                        .AsNoTracking()
                        .Include(i => i.ProjectImages)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
