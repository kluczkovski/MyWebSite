using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebSite.Models;
using MyWebSite.Repository.Interface;
using MyWebSite.Utility;
using MyWebSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebSite.Controllers
{
    public class ProjectImagesController : Controller
    {
        private readonly IProjectRepository _projectRep;
        private readonly IProjectImageRepository _projectImageRep;
        private readonly IMapper _mapper;

        public ProjectImagesController(IProjectRepository projectRepository, IProjectImageRepository projectImageRepository, IMapper mapper)
        {
            _projectRep = projectRepository;
            _projectImageRep = projectImageRepository;
            _mapper = mapper;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        // Get: Create
        public async Task<IActionResult> Create(Guid idProject)
        {
            var projectFromRep = await _projectRep.GetById(idProject);
            var projectImageVM = new ProjectImageViewModel();
            var projectVM = _mapper.Map<ProjectViewModel>(projectFromRep);
            projectImageVM.ProjectViewModel = projectVM; 
            return View(projectImageVM);
        }


        // Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectImageViewModel projectImageViewModel)
        {
            ModelState.Remove("ProjectViewModel.Name");
            ModelState.Remove("ProjectViewModel.Description");
            if (!ModelState.IsValid)
            {
                return View(projectImageViewModel);
            }


            string fileName = null;
            try
            {
                fileName = await UploadFile.Add(projectImageViewModel.ImageUpload);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (fileName == null)
            {
                return View(projectImageViewModel);
            }

            projectImageViewModel.Image = fileName;
            var projectImage = _mapper.Map<ProjectImage>(projectImageViewModel);
            //var project = _projectRep.GetById(projectImageViewModel.ProjectViewModel.Id);
            projectImage.ProjectId = projectImageViewModel.ProjectViewModel.Id;
            await _projectImageRep.Add(projectImage);
            await _projectImageRep.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
