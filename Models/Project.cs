using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MainImage { get; set; }

        public DateTime Created { get; set; }

        public string GitHubLink { get; set; }

        public string Url { get; set; }

        public string ToolsUsed { get; set; }

        public bool IsActive { get; set; }

        public ICollection<ProjectImage > ProjectImages  { get; set; }

    }
}
