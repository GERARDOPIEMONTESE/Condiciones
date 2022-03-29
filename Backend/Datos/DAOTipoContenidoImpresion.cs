using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoContenidoImpresion : DAOObjetoCodificado<TipoContenidoImpresion>
    {
        #region Singleton

        private static DAOTipoContenidoImpresion _Instancia;

        private DAOTipoContenidoImpresion()
        {
        }

        public static DAOTipoContenidoImpresion Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoContenidoImpresion();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoContenidoImpresion ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoContenidoImpresion"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        public IList<TipoContenidoImpresion> Buscar()
        {
            return DAOTipoContenidoImpresion.Instancia().Buscar(
                new Filtro(new Parametros(), "dbo.TipoContenidoImpresion_Tx_Codigo"));
        }

        public TipoContenidoImpresion Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoContenidoImpresion_Tx_Codigo"));
        }
    }
}
