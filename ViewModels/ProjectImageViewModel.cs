using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MyWebSite.Models;

namespace MyWebSite.ViewModels
{
    public class ProjectImageViewModel
    {
        public ProjectViewModel ProjectViewModel { get; set; }
        public Guid ProjectId { get; set; }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Name of Image")]
        public string ImageName { get; set; }

        //Used for the form
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Image")]
        public IFormFile ImageUpload { get; set; }
        //Used in the model
        public string Image { get; set; }

    }
}
