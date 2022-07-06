using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.ProgramacionNCapasTestEntities context = new DLEF.ProgramacionNCapasTestEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo, materia.Creditos, materia.Semestre.IdSemestre);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        //UPDATE

        public static ML.Result Update(ML.Materia materia) //12/12/2019 No se elimina la credencial, se cambia
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.ProgramacionNCapasTestEntities context = new DLEF.ProgramacionNCapasTestEntities())
                {
                    var updateResult = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo, materia.Creditos, materia.Semestre.IdSemestre);

                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el status de la credencial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        //DELETE
        public static ML.Result Delete(ML.Materia materia) //12/12/2019 No se elimina la credencial, se cambia
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.ProgramacionNCapasTestEntities context = new DLEF.ProgramacionNCapasTestEntities())
                {
                    var updateResult = context.MateriaDelete(materia.IdMateria);

                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el status de la credencial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //GETALL

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.ProgramacionNCapasTestEntities context = new DLEF.ProgramacionNCapasTestEntities())
                {

                    //var usuario = context.AlumnoGetSinFotoFirma().ToList();
                    var materias = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (materias != null)
                    {
                        foreach (var obj in materias)
                        {
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo;
                            materia.Creditos = obj.Creditos.Value;

                            
                            materia.Semestre = new ML.Semestre();
                            materia.Semestre.IdSemestre = obj.IdSemestre.Value;

                         
                            result.Objects.Add(materia);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        //GETBYID
        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.ProgramacionNCapasTestEntities context = new DLEF.ProgramacionNCapasTestEntities())
                {
                    //var objDepartamento = context.DepartamentoGetById(IdDepartamento).FirstOrDefault();
                    var objmaterias = context.MateriaGetById(IdMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objmaterias != null)
                    {

                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = objmaterias.IdMateria;
                        materia.Nombre = objmaterias.Nombre;
                        materia.Costo = objmaterias.Costo;
                        materia.Creditos = objmaterias.Creditos.Value;


                        materia.Semestre = new ML.Semestre();
                        materia.Semestre.IdSemestre = objmaterias.IdSemestre.Value;


                        result.Object = materia;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Departamento";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
