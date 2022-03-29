using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using FrameworkDAC.Negocio;
using System.Transactions;

namespace Backend.Datos
{
    public class DAOAsociacionTexto : DAOObjetoNegocio<AsociacionTexto>
    {
        #region Singleton

        private static DAOAsociacionTexto _Instancia;

        private DAOAsociacionTexto()
        {
        }

        public static DAOAsociacionTexto Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOAsociacionTexto();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(AsociacionTexto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);
            Parametros.AgregarParametro("IdTexto", ObjetoNegocio.IdTexto);
            Parametros.AgregarParametro("IdTipoTexto", ObjetoNegocio.IdTipoTexto);
            Parametros.AgregarParametro("IdTipoPlan", ObjetoNegocio.IdTipoPlan);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(AsociacionTexto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula_R_Texto", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);
            Parametros.AgregarParametro("IdTexto", ObjetoNegocio.IdTexto);
            Parametros.AgregarParametro("IdTipoTexto", ObjetoNegocio.IdTipoTexto);
            Parametros.AgregarParametro("IdTipoPlan", ObjetoNegocio.IdTipoPlan);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(AsociacionTexto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula_R_Texto", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(AsociacionTexto ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdGrupoClausula_R_Texto"]);
            ObjetoPersistido.IdGrupoClausula = Convert.ToInt32(dr["IdGrupoClausula"]);
            ObjetoPersistido.IdTexto = Convert.ToInt32(dr["IdTexto"]);
            ObjetoPersistido.IdTipoTexto = Convert.ToInt32(dr["IdTipoTexto"]);
            ObjetoPersistido.IdTipoPlan = Convert.ToInt32(dr["IdTipoPlan"]);
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"]);
        }

        public IList<AsociacionTexto> Buscar(int IdGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);

            return Buscar(new Filtro(Parametros, "dbo.GrupoClausula_R_Texto_Tx_IdGrupoClausula"));
        }

        public IList<AsociacionTexto> Buscar(int IdGrupoClausula, int IdTipoPlan)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoPlan", IdTipoPlan);

            return Buscar(new Filtro(Parametros, "dbo.GrupoClausula_R_Texto_Tx_IdGrupoClausula"));
        }

        public void Eliminar(int IdGrupoClausula, TransactionScope ts)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.Eliminado());

            Eliminar("dbo.GrupoClausula_R_Texto_Masiva_E", Parametros, ts);
        }
    }
}
