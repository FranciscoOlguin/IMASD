using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
   public class Empleado
    {
        public int IdEmpleado { get; set; }
        //[Required(ErrorMessage = "Ingrese el Numero de Nomina")] //decoradores
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "Ingrese el Apellido Paterno")] //decoradores
        public string ApellidoPaterno { get; set; }
        //[Required(ErrorMessage = "Ingrese el Apellido Materno")] //decoradores
        public string ApellidoMaterno { get; set; }
        public ML.Departamento Departamento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string FechaNacimiento { get; set; }
        public ML.Estado Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public decimal PagoNomina { get; set; }
        //[Required(ErrorMessage = "Ingrese el Nombre")] //decoradores
        public List<object> Empleados { get; set; }
    }
}
