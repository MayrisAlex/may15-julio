using may15_julio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace may15_julio.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController

        
        public ActionResult Index()
        {
            List<Persona> lisper = new List<Persona>();

           if (string.IsNullOrEmpty(HttpContext.Session.GetString("ListaPersona")))
            { 
                Persona per = new Persona();
                per.Cedula = " 1722539150";
                per.Nombre = "Mayra ";
                per.Apellido = "Pilliza";
                per.Direccion = "Quito- La Magdalena";
                per.Genero = "Femenino";
                for (int i = 0; i < 10; i++)
                {
                    lisper.Add(per);         
                }
            }
            else
            {
                lisper = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("LIstaPersona"));
            }


            HttpContext.Session.SetString("LIstaPersona", JsonConvert.SerializeObject(lisper));
            return View(lisper);
           
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona ppersona)
        {
            try
            {
                List<Persona> person = new List<Persona>();  
                person = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("LIstaPersona"));
                person.Add(ppersona);
                HttpContext.Session.SetString("LIstaPersona", JsonConvert.SerializeObject(person));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
