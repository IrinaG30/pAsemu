using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CondicionLaboralEntidad
    {
        private string nombre;
        private int idCondicionLaboral, idEstadoDatos;

        public int id
        {
            get { return idCondicionLaboral; }
            set { idCondicionLaboral = value; }
        }

        public string nom
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int idEstado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
