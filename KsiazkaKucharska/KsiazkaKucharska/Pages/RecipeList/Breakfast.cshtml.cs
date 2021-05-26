using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsiazkaKucharska.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KsiazkaKucharska.Pages.RecipeList
{
    public class BreakfastModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public BreakfastModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Recipe> Recipes { get; set; }

        public async Task OnGet()
        {
            Recipes = await _db.Recipe.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Recipe = await _db.Recipe.FindAsync(id);
            if (Recipe == null)
            {
                return NotFound();
            }
            _db.Recipe.Remove(Recipe);
            await _db.SaveChangesAsync();
            return RedirectToPage("index");
        }
    }
}