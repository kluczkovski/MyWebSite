using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MyWebSite.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Name of Project")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} size should be between {1} and {2}.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        //Used in the view
        public IFormFile ImageUpload { get; set; }
        //Used in the model
        [Display(Name ="Main Image")]
        public string MainImage { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Display(Name = "GitHub")]
        public string GitHubLink { get; set; }

        [Display(Name = "Link")]
        public string Url { get; set; }

        public string ToolsUsed { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }
    }
}
