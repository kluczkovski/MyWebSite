using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models
{
    public class Project : Entity
    {
        public Project()
        {
        }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Name of Project")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} size should be between {1} and {2}.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Main Image")]
        public string MainImage { get; set; }

        public DateTime DateTime { get; set; }

        public string GitHubLink { get; set; }

        public string ToolsUsed { get; set; }

        public ICollection<ProjectImage > ProjectImages  { get; set; }

    }
}
