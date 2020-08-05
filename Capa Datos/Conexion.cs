using System.Configuration;

namespace Capa_Datos
{
    public class Conexion
    {
        public Conexion()
        {
        }

        public string GetConex()
        {
            string strConex = ConfigurationManager.ConnectionStrings["ASEMU"].ConnectionString;
            if (object.ReferenceEquals(strConex, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strConex;
            }
        }

    }

}
