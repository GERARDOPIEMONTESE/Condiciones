using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoGrupoClausula : ObjetoCodificado
    {
        private const string NOMBRE = "TipoGrupoClausula";

        public const string TARIFA_PRODUCTO = "Producto";

        public const string TARIFA_UPGRADE = "Upgrade";

        public const string PRODUCTO_SIN_EMISION = "Producto Sin Emision";

        //SLA
        public const string SLA = "SLA";
        //Fin SLA


        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
