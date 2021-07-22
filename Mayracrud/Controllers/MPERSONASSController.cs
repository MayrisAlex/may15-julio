using Mayracrud.Data;
using Mayracrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mayracrud.Controllers
{
    [Authorize]
        public class MPERSONASSController : Controller
        {
            private readonly ApplicationDbContext _applicationDbContext;
            public MPERSONASSController(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }
       [Authorize(Roles = "Admi, Usuario")]
                public IActionResult Index()
                {
                    List<Persona> ppersonas = new List<Persona>();
                    ppersonas = _applicationDbContext.Persona.ToList();
                    return View(ppersonas);
                }

        [Authorize(Roles = "Admi")]
                public IActionResult Create ()
                {
          
                    return View();
                }
       [Authorize(Roles = "Admi")]
            [HttpPost]
                public IActionResult Create(Persona ppersona)
                {
            
                    try
                    {
                        ppersona.Estado = 1;
                        _applicationDbContext.Add(ppersona);
                        _applicationDbContext.SaveChanges();
                    }
                    catch (Exception)
                    {

                        return View(ppersona);
                    }

                    return RedirectToAction("Index");
                }
       [Authorize(Roles = "Admi")]
                public IActionResult Edit (int id)
                {
                    if(id==0)
                    {
                        return RedirectToAction("Index");
                    }
                    Persona ppersona = _applicationDbContext.Persona.Where(y => y.Codigo == id).FirstOrDefault();
                    //Persona pppersona = _applicationDbContext.Persona.Find(ma); 
                    if (ppersona==null)
                        return RedirectToAction("Index");
           
                    return View(ppersona);

                }
       [Authorize(Roles = "Admi")]
                [HttpPost]
                public IActionResult Edit (int id, Persona ppersona)
                {
                    if (id != ppersona.Codigo)
                        return RedirectToAction("Index");
                    try
                    {
                        //ppersona.Estado = 1;
                        _applicationDbContext.Update(ppersona);
                        _applicationDbContext.SaveChanges();
                    }
                    catch (Exception)
                    {

                        return View(ppersona);
                    }

                    return RedirectToAction("Index");
                }

                public IActionResult Delete (int id)
                {
                    if (id == 0)
            
                        return RedirectToAction("Index");
            
                    Persona ppersona = _applicationDbContext.Persona.Where(y => y.Codigo == id).FirstOrDefault();
                    try
                    {
                        _applicationDbContext.Remove(ppersona);
                        _applicationDbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index");
                    }


                    return RedirectToAction("Index");

                }

       [Authorize(Roles = "Admi")]
                public IActionResult Desactivar (int id)
                {
                    if (id == 0)

                        return RedirectToAction("Index");

                    Persona ppersona = _applicationDbContext.Persona.Where(y => y.Codigo == id).FirstOrDefault();
                    try
                    {
                        ppersona.Estado = 0;
                        _applicationDbContext.Update(ppersona);
                        _applicationDbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index");
                    }


                    return RedirectToAction("Index");

                }

       [Authorize(Roles = "Admi")]
                public IActionResult Activar(int id)
                {
                    if (id == 0)

                        return RedirectToAction("Index");

                    Persona ppersona = _applicationDbContext.Persona.Where(y => y.Codigo == id).FirstOrDefault();
                    try
                    {
                        ppersona.Estado = 1;
                        _applicationDbContext.Update(ppersona);
                        _applicationDbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index");
                    }


                    return RedirectToAction("Index");

                }


        [Authorize(Roles = "Admi, Usuario")]
                public IActionResult Details(int id)
                {
                    if (id == 0)

                        return RedirectToAction("Index");

                    Persona ppersona = _applicationDbContext.Persona.Where(y => y.Codigo == id).FirstOrDefault();
                   if(ppersona==null)
                        return RedirectToAction("Index");
                   return View(ppersona);
            
                 }
    }
}
