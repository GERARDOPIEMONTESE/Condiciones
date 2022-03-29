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
    public class DAOAsociacionContenidoClausula : DAOObjetoNegocio<AsociacionContenidoClausula>
    {
        #region Singleton

        private static DAOAsociacionContenidoClausula _Instancia;

        private DAOAsociacionContenidoClausula()
        {
        }

        public static DAOAsociacionContenidoClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOAsociacionContenidoClausula();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(AsociacionContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausulaPadre", 
                ObjetoNegocio.ContenidoClausulaPadre != null ? 
                    ObjetoNegocio.ContenidoClausulaPadre.Id : 
                    ObjetoNegocio.IdContenidoClausulaPadre);
            Parametros.AgregarParametro("IdContenidoClausulaHijo", ObjetoNegocio.IdContenidoClausulaHijo);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(AsociacionContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdAsociacionContenidoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdContenidoClausulaPadre",
                ObjetoNegocio.ContenidoClausulaPadre != null ?
                    ObjetoNegocio.ContenidoClausulaPadre.Id :
                    ObjetoNegocio.IdContenidoClausulaPadre);

            Parametros.AgregarParametro("IdContenidoClausulaHijo", ObjetoNegocio.IdContenidoClausulaHijo);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(AsociacionContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdAsociacionContenidoClausula", ObjetoNegocio.Id);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(AsociacionContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdAsociacionContenidoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdContenidoClausulaPadre",
                ObjetoNegocio.ContenidoClausulaPadre != null ?
                    ObjetoNegocio.ContenidoClausulaPadre.Id :
                    ObjetoNegocio.IdContenidoClausulaPadre);
            Parametros.AgregarParametro("IdContenidoClausulaHijo", ObjetoNegocio.IdContenidoClausulaHijo);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(AsociacionContenidoClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdAsociacionContenidoClausula"]);
            ObjetoPersistido.IdContenidoClausulaPadre = Convert.ToInt32(dr["IdContenidoClausulaPadre"]);
            ObjetoPersistido.IdClausulaPadre = Convert.ToInt32(dr["IdClausulaPadre"]);
            ObjetoPersistido.CodigoClausulaPadre = dr["CodigoClausulaPadre"].ToString();
            ObjetoPersistido.IdContenidoClausulaHijo = Convert.ToInt32(dr["IdContenidoClausulaHijo"]);
        }

        protected override void CompletarComposicion(AsociacionContenidoClausula ObjetoPersistido)
        {
            ObjetoPersistido.ContenidoClausulaPadre = DAOContenidoClausula.Instancia().
                Obtener(ObjetoPersistido.IdContenidoClausulaPadre);
        }

        public IList<AsociacionContenidoClausula> Buscar(int IdContenidoClausulaHijo)
        {
            return Buscar(IdContenidoClausulaHijo, false);
        }

        public IList<AsociacionContenidoClausula> Buscar(int IdContenidoClausulaHijo, bool Lazy)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdContenidoClausulaHijo", IdContenidoClausulaHijo);

            return Buscar(new Filtro(Parametros,
                "dbo.AsociacionContenidoClausula_Tx_IdContenidoClausula"), Lazy);
        }

        public void Eliminar(int IdContenidoClausula, TransactionScope ts)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdContenidoClausulaHijo", IdContenidoClausula);

            Eliminar("dbo.AsociacionContenidoClausulaMasiva_E", Parametros, ts);
        }

        public void EliminarGrupo(int IdGrupoClausula, TransactionScope ts)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.Eliminado());

            Eliminar("dbo.AsociacionContenidoClausulaGrupoMasiva_E", Parametros, ts);
        }
    }
}