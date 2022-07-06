using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            ML.Materia materia = new ML.Materia();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
                return View(materia);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return View("Modal");
            }

        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (IdMateria == null)//ADD
            {

                return View(materia);
            }
            else  //UPDATE
            {
                ML.Result result = BL.Materia.GetById(IdMateria.Value);

                if (result.Correct)
                {
                    materia = new ML.Materia();
                    materia = ((ML.Materia)result.Object);
                    ViewBag.Message = " No se pudo realizar la consulta " + result.ErrorMessage;
                    return View(materia);
                }
            }
            return View(materia);

        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            if (materia.IdMateria != 0)
            {
                result = BL.Materia.Update(materia);

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
                result = BL.Materia.Add(materia);

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
        public ActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;

            ML.Result result = BL.Materia.Delete(materia);
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