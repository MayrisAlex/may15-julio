using Mayracrud.Data;
using Mayracrud.Models;
using Mayracrud.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
       [Authorize(Roles = "BackupJefe,Supervisora")]
                public IActionResult Index()
                {

                    List<PersonaGViewModel> ppersonas = new List<PersonaGViewModel>();
            ppersonas = _applicationDbContext.Persona.Select(y => new PersonaGViewModel
            {
                Codigo = y.Codigo,
                Nombre = y.Nombre,
                Apellido=y.Apellido,
                Estado=y.Estado,
                Direccion=y.Direccion,
                DescripcionGenero=y.CodigoGeneroNavigation.Descripcion,



            }) .    ToList();
            
                    return View(ppersonas);
                }

        [Authorize(Roles = "BackupJefe")]
                public IActionResult Create ()
                {
                ViewData["CodigoGenero"]= new SelectList(_applicationDbContext.Generos.Where(y=> y.Estado==1).ToList(),"Codigo","Descripcion");

          
                    return View();
                }
       [Authorize(Roles = "BackupJefe")]
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
       [Authorize(Roles = "BackupJefe")]
                public IActionResult Edit (int id)
                {
                    if(id==0)
                    {
                        return RedirectToAction("Index");
                    }
                    Persona ppersona = _applicationDbContext.Persona.Where(y => y.Codigo == id).FirstOrDefault();
                    // Persona pppersona = _applicationDbContext.Persona.Find(id); 
                    if (ppersona==null)
                        return RedirectToAction("Index");
           
                    return View(ppersona);

                }
       [Authorize(Roles = "BackupJefe")]
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

        [Authorize(Roles = "BackupJefe,Supervisora")]
                    public IActionResult Details(int id)
                    {
                        if (id == 0)

                            return RedirectToAction("Index");

                        Persona ppersona = _applicationDbContext.Persona.Where(y => y.Codigo == id).FirstOrDefault();
                        if (ppersona == null)
                            return RedirectToAction("Index");
                        return View(ppersona);

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

       [Authorize(Roles = "BackupJefe")]
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

       [Authorize(Roles = "BackupJefe")]
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


       
    }
}
