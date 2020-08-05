using Capa_Datos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class CondicionLaboralNegocio
    {

        CondicionLaboralDatos _CLDatos = new CondicionLaboralDatos();

        public bool CrearCondicionLaboral(CondicionLaboralEntidad CLNegocio)
        {
            return _CLDatos.CrearCondicionLaboral(CLNegocio);
        }

        public bool ModificarCondicionLaboral(CondicionLaboralEntidad CLNegocio)
        {
            return _CLDatos.ModificarCondicionLaboral(CLNegocio);
        }

        public bool DesactivarCondicionLaboral(CondicionLaboralEntidad CLNegocio)
        {
            return _CLDatos.DesactivarCondicionLaboral(CLNegocio);
        }

        public DataTable ListarCondicionLab(string parametro)
        {
            return _CLDatos.ListarCondicionLab(parametro);
        }
        public CondicionLaboralEntidad BuscarCondicionLaboral(string nombre)
        {
            return _CLDatos.BuscarCondicionLaboral(nombre);
        }

    }
}
