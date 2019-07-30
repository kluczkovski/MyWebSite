using System;
using MyWebSite.Data;
using MyWebSite.Models;
using MyWebSite.Repository.Interface;

namespace MyWebSite.Repository
{
    public class ProjectImageRepository : Repository<ProjectImage>, IProjectImageRepository
    {
        public ProjectImageRepository(MyDBContext dBContext) : base(dBContext)
        {
        }
    }
}
