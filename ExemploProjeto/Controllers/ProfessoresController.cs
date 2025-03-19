using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;

namespace ProjetoEscola.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly EscolaDBContext _context;

        public ProfessoresController(EscolaDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professores.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FirstOrDefaultAsync(m => m.IdProfessor == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdProfessor,NomeProfessor")] Professor professor)
        {
            _context.Add(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfessor,NomeProfessor")] Professor professor)
        {
            if(id != professor.IdProfessor)
            {
                return NotFound();
            }
            try
            {
                _context.Update(professor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(professor.IdProfessor))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FirstOrDefaultAsync(m => m.IdProfessor == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.IdProfessor == id);
        }
    }
}
