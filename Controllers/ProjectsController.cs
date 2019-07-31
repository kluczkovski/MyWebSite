using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebSite.Models;
using MyWebSite.Repository.Interface;
using MyWebSite.ViewModels;

namespace MyWebSite.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRep;
        private readonly IMapper _mapper;
       
        public ProjectsController(IProjectRepository project, IMapper mapper)
        {
            _projectRep = project;
            _mapper = mapper;

        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var projectsfromRep = await _projectRep.GetAll();
            var projects = _mapper.Map<IEnumerable<ProjectViewModel>>(projectsfromRep);

            return View(projects);
        }


        // Get -> Create
        public IActionResult Create()
        {
            var projectViewModel = new ProjectViewModel();
            projectViewModel.Created = DateTime.Now;
            return View(projectViewModel);
        }

        // Post -> Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(projectViewModel);
            }

            string fileName = await UploadFile(projectViewModel.ImageUpload);
            if (fileName == null)
            {
                return View(projectViewModel);
            }

            projectViewModel.MainImage = fileName;
            var project = _mapper.Map<Project>(projectViewModel);

            await _projectRep.Add(project);
            await _projectRep.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // Get - Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var projectFromRep = await _projectRep.GetById(id);
            if (projectFromRep == null)
            {
                return NotFound();
            }
            var projectViewModel = _mapper.Map<ProjectViewModel>(projectFromRep);
            return View(projectViewModel);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProjectViewModel projectViewModel)
        {
            if (id != projectViewModel.Id)
            {
                return NotFound();
            }

            // Update image
            if (projectViewModel.ImageUpload != null)
            {
                // Delete Old image
                DeleteUploadFile(projectViewModel.MainImage);

                string fileName = await UploadFile(projectViewModel.ImageUpload);
                if (fileName == null)
                {
                    return View(projectViewModel);
                }
                projectViewModel.MainImage = fileName;
            }

            var project = _mapper.Map<Project>(projectViewModel);
            
            await _projectRep.Update(project);
            await _projectRep.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        private async Task<string> UploadFile(IFormFile formFile)
        {
            var imgPrefixo = Guid.NewGuid() + "_";

            if (formFile == null)
            {
                ModelState.AddModelError(string.Empty, "Must be informad the Main Image.");
                return null;
            }

            string filename = imgPrefixo + formFile.FileName;
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/images", filename);
            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "The file already exist with this name");
                return null;
            }

            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
           
            return filename;
        }

        private void DeleteUploadFile(string file)
        {
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwwroot/images/", file);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

        }
    }
}
