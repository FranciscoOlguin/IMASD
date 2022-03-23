using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class Empleado
    {
        public static ML.Result GetAll()
        
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BDNOMINA2022Entities context = new DL.BDNOMINA2022Entities())
                {
                    var query = context.EmpleadoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Departamento = new ML.Departamento();
                            empleado.Departamento.IdDepartamento = obj.IdDepartamento;
                            empleado.Departamento.Nombre = obj.NDep;
                            empleado.Email = obj.Email;
                            empleado.Sexo = obj.Sexo;
                            empleado.Telefono = obj.Telefono;
                            empleado.Celular = obj.Celular;
                            empleado.FechaNacimiento = obj.Fechanacimiento.Value.ToString("dd/MM/yyyy");
                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = obj.IdEstado;
                            empleado.Estado.Nombre = obj.NEst;
                            empleado.CodigoPostal = obj.CodigoPostal;
                            empleado.Direccion = obj.Direccion;
                            empleado.PagoNomina = obj.PagoNomina.Value;


                            result.Objects.Add(empleado);
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
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BDNOMINA2022Entities context = new DL.BDNOMINA2022Entities())
                {
                    var query = context.EmpleadoAdd(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Departamento.IdDepartamento, empleado.Email, empleado.Sexo, empleado.Telefono, empleado.Celular, empleado.FechaNacimiento, empleado.Estado.IdEstado, empleado.CodigoPostal, empleado.Direccion, empleado.PagoNomina);

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
                result.Ex = ex;
            }
            return result;
        }//Fin AddEF
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BDNOMINA2022Entities context = new DL.BDNOMINA2022Entities())
                {
                    var query = context.EmpleadoUpdate(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno,empleado.Departamento.IdDepartamento,empleado.Email,empleado.Sexo,empleado.Telefono,empleado.Celular,empleado.FechaNacimiento,empleado.Estado.IdEstado,empleado.CodigoPostal,empleado.Direccion,empleado.PagoNomina,empleado.IdEmpleado);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el usuario";
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
        }//Fin UpdateEF
        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BDNOMINA2022Entities context = new DL.BDNOMINA2022Entities())
                {
                    var query = context.EmpleadoDelete(IdEmpleado);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
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
        }//Fin DeleteEF
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BDNOMINA2022Entities context = new DL.BDNOMINA2022Entities())
                {

                    var query = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Departamento = new ML.Departamento();
                        empleado.Departamento.IdDepartamento = query.IdDepartamento;
                        empleado.Departamento.Nombre = query.NDep;
                        empleado.Email = query.Email;
                        empleado.Sexo = query.Sexo;
                        empleado.Telefono = query.Telefono;
                        empleado.Celular = query.Celular;
                        empleado.FechaNacimiento = query.Fechanacimiento.Value.ToString("MM/dd/yyyy");
                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = query.IdEstado;
                        empleado.Estado.Nombre = query.NEst;
                        empleado.CodigoPostal = query.CodigoPostal;
                        empleado.Direccion = query.Direccion;
                        empleado.PagoNomina = query.PagoNomina.Value;

                        result.Object = empleado;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Empleado";
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
        }//Fin GetByIdEF

    }
}
