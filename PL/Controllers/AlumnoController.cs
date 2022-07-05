using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return View("Modal");
            }

        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            if (IdAlumno == null)//ADD
            {

                return View(alumno);
            }
            else  //UPDATE
            {
                ML.Result result = BL.Alumno.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = new ML.Alumno();
                    alumno = ((ML.Alumno)result.Object);
                    ViewBag.Message = " No se pudo realizar la consulta " + result.ErrorMessage;
                    return View(alumno);
                }
            }
            return View(alumno);

        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if (alumno.IdAlumno != 0)
            {
                result = BL.Alumno.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo el usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se actualizo" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                result = BL.Alumno.Add(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado correctaente el producto";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }



        }
        [HttpGet]
        public ActionResult Delete(int IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.IdAlumno = IdAlumno;

            ML.Result result = BL.Alumno.Delete(alumno);
            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return PartialView("Modal");
            }
        }

    }
}