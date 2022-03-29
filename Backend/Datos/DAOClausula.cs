using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using FrameworkDAC.Negocio;
using Backend.Dominio;
using System.Transactions;


namespace Backend.Datos
{
    public class DAOClausula : DAOObjetoNegocio<Clausula>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Condiciones";

        #endregion

        #region Singleton

        private static DAOClausula _Instancia;

        private DAOClausula()
        {
        }

        public static DAOClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausula();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override void Completar(Clausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdClausula"];
            ObjetoPersistido.TipoClausula = DAOTipoClausula.Instancia().Obtener((int)dr["IdTipoClausula"]);
            ObjetoPersistido.Codigo = (string)dr["Codigo"];
            ObjetoPersistido.OrdenPredefinido = Convert.ToInt32(dr["OrdenPredefinido"]);
            ObjetoPersistido.Clausula_Idioma = DAOClausula_Idioma.Instancia().BuscarPorClausula((int)dr["IdClausula"]);
            ObjetoPersistido.Peso = DBNull.Value.Equals(dr["Peso"]) ? (decimal?)null : (decimal?)(dr["Peso"]);
            ObjetoPersistido.Tasa = DBNull.Value.Equals(dr["Tasa"]) ? (decimal?)null : (decimal?)(dr["Tasa"]);
        }

        protected override Parametros ParametrosCrear(Clausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoClausula", ObjetoNegocio.TipoClausula.Id);
            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("OrdenPredefinido", ObjetoNegocio.OrdenPredefinido);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("Fecha", DateTime.Now);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            Parametros.AgregarParametro("Peso", ObjetoNegocio.Peso);
            Parametros.AgregarParametro("Tasa", ObjetoNegocio.Tasa);

            return Parametros;
        }

        protected override Parametros ParametrosModificar(Clausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdTipoClausula", ObjetoNegocio.TipoClausula.Id);
            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("OrdenPredefinido", ObjetoNegocio.OrdenPredefinido);
            Parametros.AgregarParametro("Peso", ObjetoNegocio.Peso);
            Parametros.AgregarParametro("Tasa", ObjetoNegocio.Tasa);

            return Parametros;
        }

        protected override Parametros ParametrosEliminar(Clausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("Fecha", DateTime.Now);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(Clausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdTipoClausula", ObjetoNegocio.TipoClausula.Id);
            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("OrdenPredefinido", ObjetoNegocio.OrdenPredefinido);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("Fecha", DateTime.Now);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            Parametros.AgregarParametro("Peso", ObjetoNegocio.Peso);
            Parametros.AgregarParametro("Tasa", ObjetoNegocio.Tasa);

            return Parametros;
        }

        protected override void CrearComposicion(ObjetoNegocio ObjetoNegocio, TransactionScope ts)
        {
            Clausula Clausula = (Clausula)ObjetoNegocio;

            foreach (Clausula_Idioma Clausula_Idioma in Clausula.Clausula_Idioma)
            {
                Clausula_Idioma.IdClausula = Clausula.Id;
                Clausula_Idioma.Persistir(ts);
            }
        }

        protected override void ModificarComposicion(ObjetoNegocio ObjetoNegocio, TransactionScope ts)
        {
            CrearComposicion(ObjetoNegocio, ts);
        }

        #endregion

        #region Metodos

        public IList<Clausula> BuscarPorParametros(int IdTipoClausula, string Codigo, string Nombre)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdTipoClausula", IdTipoClausula);
            p.AgregarParametro("Codigo", Codigo);
            p.AgregarParametro("Nombre", Nombre);
            p.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());


            Filtro Filtro = new Filtro(p, "dbo.Clausula_Tx_BuscarPorParametros");
            return Buscar(Filtro);
        }

        public IList<Clausula> Buscar(int IdTipoClausula)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdTipoClausula", IdTipoClausula);
            p.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            Filtro Filtro = new Filtro(p, "dbo.Clausula_Tx_BuscarPorParametros");
            return Buscar(Filtro);
        }

        public IList<Clausula> Buscar()
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            Filtro Filtro = new Filtro(p, "dbo.Clausula_Tx_BuscarPorParametros");

            return Buscar(Filtro);
        }

        public IList<Clausula> Buscar(IList<int> IdsGrupoClausula)
        {
            string SqlQuery = "SELECT * FROM Clausula WHERE IdEstado <> " + ObjetoNegocio.Eliminado();
           

            return Buscar(SqlQuery);
        }

        public Clausula Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Obtener(new Filtro(Parametros, "dbo.Clausula_Tx_Codigo"));
        }

        #endregion


    }

}
