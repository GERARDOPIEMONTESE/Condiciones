using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class Producto : ObjetoNegocio
    {
        private const string NOMBRE = "Producto";

        #region Propiedades

        public string Codigo {get; set;}
        public string Nombre {get; set;}
        public int IdTipoGrupoClausula {get; set;}
        public int CodigoPais {get; set;}
        public string CodigoYNombre
        {
            get
            {
                return Codigo + " - " + Nombre;
            }
        }
        public string NombreYCodigo
        {
            get
            {
                return Nombre + " (" + Codigo + ")";
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOProducto.Instancia();
        }
    }
}
