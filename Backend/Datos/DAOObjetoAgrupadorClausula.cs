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
    public class DAOObjetoAgrupadorClausula : DAOObjetoNegocio<ObjetoAgrupadorClausula>
    {
        #region Singleton

        private static DAOObjetoAgrupadorClausula _Instancia;

        private DAOObjetoAgrupadorClausula()
        {
        }

        public static DAOObjetoAgrupadorClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOObjetoAgrupadorClausula();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(ObjetoAgrupadorClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdLocacion", ObjetoNegocio.IdLocacion);
            Parametros.AgregarParametro("IdObjetoAgrupador", ObjetoNegocio.IdObjetoAgrupador);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.TipoGrupoClausula.Id);
            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(ObjetoAgrupadorClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdObjetoAgrupadorClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdLocacion", ObjetoNegocio.IdLocacion);
            Parametros.AgregarParametro("IdObjetoAgrupador", ObjetoNegocio.IdObjetoAgrupador);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.TipoGrupoClausula.Id);
            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(ObjetoAgrupadorClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdObjetoAgrupadorClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(ObjetoAgrupadorClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdObjetoAgrupadorClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdLocacion", ObjetoNegocio.IdLocacion);
            Parametros.AgregarParametro("IdObjetoAgrupador", ObjetoNegocio.IdObjetoAgrupador);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.TipoGrupoClausula.Id);
            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(ObjetoAgrupadorClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdObjetoAgrupadorClausula"]);
            ObjetoPersistido.IdLocacion = Convert.ToInt32(dr["IdLocacion"]);
            ObjetoPersistido.IdObjetoAgrupador = Convert.ToInt32(dr["IdObjetoAgrupador"]);
            ObjetoPersistido.TipoGrupoClausula = DAOTipoGrupoClausula.Instancia().
                Obtener(Convert.ToInt32(dr["IdTipoGrupoClausula"]));
            ObjetoPersistido.IdGrupoClausula = Convert.ToInt32(dr["IdGrupoClausula"]);
            ObjetoPersistido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"]);
        }

        public IList<ObjetoAgrupadorClausula> Buscar(int IdGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.ObjetoAgrupadorClausula_Tx_IdGrupoClausula"));
        }

        public void Eliminar(int IdGrupoClausula, TransactionScope ts)
        {
            try
            {
                Parametros Parametros = new Parametros();
                Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
                Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.Eliminado());

                Eliminar("dbo.ObjetoAgrupadorClausulaMasiva_E", Parametros, ts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
