using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumo_api_Curso
{
    public class DtoEstudiante
    {
        public int IdEstudiante { get; set; }
        public string Matricula { get; set; }
        public string  Nombre { get; set;}
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
