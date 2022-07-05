using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{


        public class Alumno
        {

            public static ML.Result Add(ML.Alumno alumno)
            {
                //instancia
                ML.Result result = new ML.Result();

                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        string query = "AlumnoAdd";

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = query;
                            cmd.Connection = context;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter[] parameter = new SqlParameter[4];



                            parameter[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                            parameter[0].Value = alumno.Nombre;

                            parameter[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                            parameter[1].Value = alumno.ApellidoPaterno;

                            parameter[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                            parameter[2].Value = alumno.ApellidoMaterno;

                            parameter[3] = new SqlParameter("@FechaNacimiento", SqlDbType.VarChar);
                            parameter[3].Value = alumno.FechaNacimiento;


                            cmd.Parameters.AddRange(parameter);
                            cmd.Connection.Open();

                            int RowsAffected = cmd.ExecuteNonQuery();

                            if (RowsAffected > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;

                            }
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

            //UPDATE
            public static ML.Result Update(ML.Alumno alumno)
            {
                //instancia
                ML.Result result = new ML.Result();

                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        string query = "AlumnoUpdate";

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = query;
                            cmd.Connection = context;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter[] parameter = new SqlParameter[5];

                            parameter[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                            parameter[0].Value = alumno.IdAlumno;

                            parameter[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                            parameter[1].Value = alumno.Nombre;

                            parameter[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                            parameter[2].Value = alumno.ApellidoPaterno;

                            parameter[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                            parameter[3].Value = alumno.ApellidoMaterno;

                            parameter[4] = new SqlParameter("@FechaNacimiento", SqlDbType.VarChar);
                            parameter[4].Value = alumno.FechaNacimiento;

                            cmd.Parameters.AddRange(parameter);
                            cmd.Connection.Open();

                            int RowsAffected = cmd.ExecuteNonQuery();

                            if (RowsAffected > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;

                            }
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
            //DELETE
            public static ML.Result Delete(ML.Alumno alumno)
            {
                //instancia
                ML.Result result = new ML.Result();

                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        string query = "AlumnoDelete";

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = query;
                            cmd.Connection = context;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter[] parameter = new SqlParameter[1];

                            parameter[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                            parameter[0].Value = alumno.IdAlumno;


                            cmd.Parameters.AddRange(parameter);
                            cmd.Connection.Open();

                            int RowsAffected = cmd.ExecuteNonQuery();

                            if (RowsAffected > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;

                            }
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
            public static ML.Result GetAll()
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "AlumnoGetAll";
                            cmd.Connection = context;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Connection.Open();

                            DataTable alumnoTable = new DataTable();

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(alumnoTable);

                            //inicializador condicion incrementador
                            if (alumnoTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                foreach (DataRow row in alumnoTable.Rows)
                                {
                                    ML.Alumno alumno = new ML.Alumno();
                                    alumno.IdAlumno = int.Parse(row[0].ToString());
                                    alumno.Nombre = row[1].ToString();
                                    alumno.ApellidoPaterno = row[2].ToString();
                                    alumno.ApellidoMaterno = row[3].ToString();
                                    alumno.FechaNacimiento = row[4].ToString();


                                    result.Objects.Add(alumno);
                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "Ocurrió un error al momento de insertar la materia";
                            }
                            cmd.Connection.Close();
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
            public static ML.Result GetById(int IdAlumno)
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        string query = "AlumnoGetById";

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = query;
                            cmd.Connection = context;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter[] collection = new SqlParameter[1];

                            collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                            collection[0].Value = IdAlumno;

                            cmd.Parameters.AddRange(collection);


                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable tableMateria = new DataTable();

                                da.Fill(tableMateria);

                                cmd.Connection.Open();

                                if (tableMateria.Rows.Count > 0)
                                {
                                    result.Objects = new List<object>();

                                    DataRow row = tableMateria.Rows[0];

                                    ML.Alumno alumno = new ML.Alumno();
                                    alumno.IdAlumno = int.Parse(row[0].ToString());
                                    alumno.Nombre = row[1].ToString();
                                    alumno.ApellidoPaterno = row[2].ToString();
                                    alumno.ApellidoMaterno = row[3].ToString();
                                    alumno.FechaNacimiento = row[4].ToString();

                                    result.Object = alumno;  //boxing    --unboxing

                                    result.Correct = true;
                                }
                                else
                                {
                                    result.Correct = false;
                                    result.ErrorMessage = "No se encontraron registros en la tabla Materia";
                                }

                                //inicializador condición incremento


                            }


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

