using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ProgramacionNCapasTest"].ConnectionString;
        }
        //Data Source = VICTOR - PC2\SQLEXPRESS;Initial Catalog = ProgramacionNCapasTest; Integrated Security = True
    }
}
