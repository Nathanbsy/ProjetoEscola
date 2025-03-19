using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;

namespace ProjetoEscola.Controllers
{
    public class DisciplinasController : Controller
    {
        private readonly EscolaDBContext _context;

        public DisciplinasController(EscolaDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disciplinas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(m => m.idDis == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("idDis,nomeDis")] Disciplina disciplina)
        {
            _context.Add(disciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var autor = await _context.Disciplinas.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("idDis,nomeDis")] Disciplina disciplina)
        {
            if (id != disciplina.idDis)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.idDis))
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

            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(m => m.idDis == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplinas.Any(e => e.idDis == id);
        }
    }
}
