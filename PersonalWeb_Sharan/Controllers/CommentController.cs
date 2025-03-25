using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalWeb_Sharan.Data;
using PersonalWeb_Sharan.Models;

namespace PersonalWeb_Sharan.Controllers
{
    public class CommentController : Controller
    {
        private readonly PersonalWeb_SharanContext _context;

        public CommentController(PersonalWeb_SharanContext context)
        {
            _context = context;
        }

        // GET: Comment
   

        // GET: Comment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comment/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new CommentViewModel
            {
                Comments = await _context.Comment.ToListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.NewComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create)); // Refresh the page after submission
            }

            viewModel.Comments = await _context.Comment.ToListAsync(); // Reload comments if validation fails
            return View(viewModel);
        }

        // GET: Comment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Text")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        
        public IActionResult Delete(int id)
        {
            var comment = _context.Comment.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                TempData["ErrorMessage"] = "Comment not found!";
                return RedirectToAction(nameof(Create));
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var comment = _context.Comment.Find(id);
            if (comment == null)
            {
                TempData["ErrorMessage"] = "Comment not found!";
                return RedirectToAction(nameof(Create));
            }

            _context.Comment.Remove(comment);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Create)); // Redirect back to the Create page with the updated comment list
        }


        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}
