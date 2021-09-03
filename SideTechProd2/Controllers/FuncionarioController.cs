using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SideTechProd2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SideTechProd2.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly Contexto _context;

        public FuncionarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Funcionarios.Include(f => f.Empresa);
            return View(await contexto.ToListAsync());

        }


        /*teste filtro*/
        [HttpGet]
        public async Task<IActionResult> Index(string Empsearch)
        {
            ViewData["getfuncionariodetalhes"] = Empsearch;
            var empquery = from x in _context.Funcionarios select x;
            if (!string.IsNullOrEmpty(Empsearch))
            {
                empquery = empquery.Where(x => x.Nome.Contains(Empsearch));
            }
            return View(await empquery.AsNoTracking().ToListAsync());
        }


        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.IdFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "Cnpj");
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFuncionario,Nome,Cpf,Matricula,DataDeAdmissao,IdEmpresa")] Funcionario funcionario)
        {

            if (_context.Funcionarios.Any(f => f.Matricula == funcionario.Matricula))
            {
                ModelState.AddModelError("Matricula", $"Esta matrícula já está registrada.");
            }
            if (_context.Funcionarios.Any(f => f.Matricula == funcionario.Matricula))
            {
                ModelState.AddModelError("Cpf", $"Este CPF já está registrado.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "Cnpj", funcionario.IdEmpresa);
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "Cnpj", funcionario.IdEmpresa);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFuncionario,Nome,Cpf,Matricula,DataDeAdmissao,IdEmpresa")] Funcionario funcionario)
        {
            if (id != funcionario.IdFuncionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.IdFuncionario))
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
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "Cnpj", funcionario.IdEmpresa);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.IdFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.IdFuncionario == id);
        }
    }
}
