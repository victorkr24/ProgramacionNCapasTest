using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public string Costo { get; set; }
        public int Creditos { get; set; }
        public ML.Semestre Semestre { get; set; }
        public List<object> Materias { get; set; }
    }
}
