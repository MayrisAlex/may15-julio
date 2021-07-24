using Mayracrud.Data;
using Mayracrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mayracrud.Controllers
{
    public class GENEROSController : Controller
    {


        private readonly ApplicationDbContext _ccontexto;
        public GENEROSController(ApplicationDbContext context)
        {
            _ccontexto = context;
        }

        // GET: GenerossController1cs
        public ActionResult Index()
        {

            List<Genero> lisgenero = _ccontexto.Generos.ToList();


            return View(lisgenero);
        }

        // GET: GenerossController1cs/Details/5
        public ActionResult Details(int id)
        {
            Genero _genero = _ccontexto.Generos.FirstOrDefault(y => y.Codigo == id);
            return View(_genero);
        }

        // GET: GenerossController1cs/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: GenerossController1cs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero _genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ccontexto.Add(_genero);
                    _ccontexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_genero);
            }
        }

        // GET: GenerossController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            Genero _genero = _ccontexto.Generos.FirstOrDefault(y => y.Codigo == id);
            return View(_genero);
        }

        // POST: GenerossController1cs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Genero _genero)
        {
            if (id != _genero.Codigo)

            {
                return RedirectToAction("Index");
            }
            try
            {
                _ccontexto.Update(_genero);
                _ccontexto.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {
                return View(_genero);
            }
        }

        //[Authorize(Roles = "BackupJefe")]
        public IActionResult Desactivar(int id)
        {
            if (id == 0)

                return RedirectToAction("Index");

            Genero ppersona = _ccontexto.Generos.Where(y => y.Codigo == id).FirstOrDefault();
            try
            {
                ppersona.Estado = 0;
                _ccontexto.Update(ppersona);
                _ccontexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");

        }

        // [Authorize(Roles = "BackupJefe")]
        public IActionResult Activar(int id)
        {
            if (id == 0)

                return RedirectToAction("Index");

            Genero ppersona = _ccontexto.Generos.Where(y => y.Codigo == id).FirstOrDefault();
            try
            {
                ppersona.Estado = 1;
                _ccontexto.Update(ppersona);
                _ccontexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");

        }
    }



}

