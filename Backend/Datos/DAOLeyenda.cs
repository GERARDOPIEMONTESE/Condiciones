using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using System.Transactions;
using FrameworkDAC.Negocio;

namespace Backend.Datos
{
    public class DAOLeyenda : DAOObjetoNegocio<Leyenda>
    {
        #region Singleton

        private static DAOLeyenda _Instancia;

        private DAOLeyenda()
        {
        }

        public static DAOLeyenda Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOLeyenda();
            }
            return _Instancia;
         }

        #endregion

        protected override string  NombreConnectionString()
        {
 	         return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(Leyenda ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausulaRango", ObjetoNegocio.IdContenidoClausulaRango);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Texto", ObjetoNegocio.Texto);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(Leyenda ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdLeyenda", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdContenidoClausulaRango", ObjetoNegocio.IdContenidoClausulaRango);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Texto", ObjetoNegocio.Texto);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(Leyenda ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdLeyenda", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(Leyenda ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdLeyenda", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdContenidoClausulaRango", ObjetoNegocio.IdContenidoClausulaRango);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Texto", ObjetoNegocio.Texto);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        public void Eliminar(int IdContenidoClausulaRango, TransactionScope ts)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdContenidoClausulaRango", IdContenidoClausulaRango);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            Eliminar("dbo.LeyendaMasiva_E", Parametros, ts);
        }

        protected override void Completar(Leyenda ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdLeyenda"]);
            ObjetoPersistido.IdContenidoClausulaRango = Convert.ToInt32(dr["IdContenidoClausulaRango"]);
            ObjetoPersistido.IdIdioma = Convert.ToInt32(dr["IdIdioma"]);
            ObjetoPersistido.Texto = dr["Texto"].ToString();
        }

        public IList<Leyenda> Buscar(int IdContenidoClausulaRango)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdContenidoClausulaRango", IdContenidoClausulaRango);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.Leyenda_Tx_IdContenidoClausulaRango"));
        }
    }
}
