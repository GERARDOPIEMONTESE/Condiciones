using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using FrameworkDAC.Negocio;
using Backend.Dominio;
namespace Backend.Datos
{
    public class DAOPais : DAOObjetoPersistido<Pais>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Portal";

        #endregion

        #region Singleton

        private static DAOPais _Instancia;

        private DAOPais()
        {
        }

        public static DAOPais Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOPais();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override void Completar(Pais ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdPais"];
            ObjetoPersistido.IdLocacion = (int)dr["IdLocacion"];
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.CodigoISOA2 = dr["CodigoISOA2"].ToString();
            ObjetoPersistido.CodigoISOA3 = dr["CodigoISOA3"].ToString();
        }

        #endregion

        #region Metodos

        public IList<Pais> Buscar()
        {
            Filtro Filtro = new Filtro(new Parametros(), "Locacion.Pais_TT");
            return Buscar(Filtro);
        }

        public IList<Pais> BuscarConProductos()
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());
            Filtro Filtro = new Filtro(Parametros, "Condiciones.dbo.Pais_Tx_Producto");
            return Buscar(Filtro);
        }

        public Pais ObtenerPorCodigo(int Codigo)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "Locacion.Pais_Tx_Codigo"));
        }

        public Pais ObtenerPorCodigoISO2(string codigoISO)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("CodigoISOA2", codigoISO);

            return Obtener(new Filtro(Parametros, "Locacion.Pais_Tx_CodigoISOA2"));
        }

        public Pais ObtenerPorIdLocacion(int IdLocacion)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdLocacion", IdLocacion);

            return Obtener(new Filtro(Parametros, "Locacion.Pais_Tx_IdLocacion"));
        }

        #endregion
    }
}
