using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;

namespace ProjetoEscola.Controllers
{
    public class AlunosController : Controller
    {
        private readonly EscolaDBContext _context;

        public AlunosController(EscolaDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FirstOrDefaultAsync(m => m.idAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("idAluno,nomeAluno")] Aluno aluno)
        {
            _context.Add(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("idAluno,nomeAluno")] Aluno aluno)
        {
            if (id != aluno.idAluno)
            {
                return NotFound();
            }

            _context.Update(aluno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FirstOrDefaultAsync(m => m.idAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.idAluno == id);
        }
    }
}
