using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;
using Backend.Homes;

namespace Backend.Dominio
{
    public class Tarifa : ObjetoNegocio
    {
        private const string NOMBRE = "Tarifa";


        #region Propiedades

        public int IdProducto {get; set;}
        public int CodigoPais {get; set;}
        public string Codigo {get; set;}
        public string Nombre {get; set;}
        public string Sufijo {get; set;}
        public int IdTipoGrupoClausula {get; set;}
        public bool Anual {get; set;}
        public bool Activa {get; set;}
        public int IdTipoModalidad {get; set;}


        public string TipoModalidad
        {
            get
            {
                return TipoModalidadHome.Obtener(IdTipoModalidad).Descripcion;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOTarifa.Instancia();
        }
    }
}
