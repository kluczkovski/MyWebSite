using System;
namespace MyWebSite.Models
{
    public class ProjectImage : Entity
    {
        public ProjectImage()
        {
        }

        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public string ImageName { get; set; }

        public string Image { get; set; }

    }
}
