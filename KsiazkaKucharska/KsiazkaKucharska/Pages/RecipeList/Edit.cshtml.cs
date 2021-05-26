using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsiazkaKucharska.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;

namespace KsiazkaKucharska.Pages.RecipeList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }      
        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task OnGet(int id)
        {
            Recipe = await _db.Recipe.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RecipeFromDb = await _db.Recipe.FindAsync(Recipe.Id);
                RecipeFromDb.Nazwa = Recipe.Nazwa;
                RecipeFromDb.Opis = Recipe.Opis;
                RecipeFromDb.Czas = Recipe.Czas;
                RecipeFromDb.Skladniki = Recipe.Skladniki;
                RecipeFromDb.Porcja = Recipe.Porcja;
                RecipeFromDb.Instrukcje = Recipe.Instrukcje;
                RecipeFromDb.Rodzaj = Recipe.Rodzaj;

                await _db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            return RedirectToPage();
        }
    }
    public class UploadFileModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UploadFileModel(ApplicationDbContext db)
        {
            _db = db;
        }
        private IHostingEnvironment _environment;
        public UploadFileModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public string FileName { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task OnPostAsync()
        {
            var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
                FileName = Upload.FileName;
                FileName=Recipe.Zdjecie;
            }
        }
        
        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task OnGet(int id)
        {
            Recipe = await _db.Recipe.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RecipeFromDb = await _db.Recipe.FindAsync(Recipe.Id);
                RecipeFromDb.Zdjecie = Recipe.Zdjecie;

                await _db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            return RedirectToPage();
        }
    }
}