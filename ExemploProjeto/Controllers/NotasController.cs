using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data;
using ProjetoEscola.Models;

namespace ExemploProjeto.Controllers
{
    public class NotasController : Controller
    {
        private readonly EscolaDBContext _context;

        public NotasController(EscolaDBContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var escolaDBcontext = _context.Notas.Include(n => n.Aluno).Include(n => n.Disciplina).Include(n => n.Professor);
            return View(await escolaDBcontext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Disciplina)
                .Include(n => n.Professor)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewData["fk_idAluno"] = new SelectList(_context.Alunos, "idAluno", "idAluno");
            ViewData["fk_nomeDisciplina"] = new SelectList(_context.Disciplinas, "idDisciplina", "idDisciplina");
            ViewData["fk_idProf"] = new SelectList(_context.Professores, "idProfessor", "idProfessor");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idNota,nota,faltas,fk_idProf,fk_idAluno,fk_nomeDisciplina")] Notas nota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["fk_idAluno"] = new SelectList(_context.Alunos, "idAluno", "idAluno", nota.IdAluno);
            ViewData["fk_nomeDisciplina"] = new SelectList(_context.Disciplinas, "idDisciplina", "idDisciplina", nota.IdDisciplina);
            ViewData["fk_idProf"] = new SelectList(_context.Professores, "idProfessor", "idProfessor", nota.IdProfessor);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Notas.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            ViewData["fk_idAluno"] = new SelectList(_context.Alunos, "idAluno", "idAluno", nota.IdAluno);
            ViewData["fk_nomeDisciplina"] = new SelectList(_context.Disciplinas, "idDisciplina", "idDisciplina", nota.IdDisciplina);
            ViewData["fk_idProf"] = new SelectList(_context.Professores, "idProfessor", "idProfessor", nota.IdProfessor);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idNota,nota,faltas,fk_idProf,fk_idAluno,fk_nomeDisciplina")] Notas nota)
        {
            if (id != nota.IdNota)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.IdNota))
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

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Disciplina)
                .Include(n => n.Professor)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
            return _context.Notas.Any(e => e.IdNota == id);
        }
    }
}
