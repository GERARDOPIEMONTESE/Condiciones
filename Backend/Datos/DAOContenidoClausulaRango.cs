using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using Backend.Contextos;
using System.Transactions;
using FrameworkDAC.Negocio;

namespace Backend.Datos
{
    public class DAOContenidoClausulaRango : DAOObjetoNegocio<ContenidoClausulaRango>
    {
        #region Singleton

        private static DAOContenidoClausulaRango _Instancia;

        private DAOContenidoClausulaRango()
        {
        }

        public static DAOContenidoClausulaRango Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOContenidoClausulaRango();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(ContenidoClausulaRango ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausula", ObjetoNegocio.IdContenidoClausula);
            Parametros.AgregarParametro("EdadMinima", ObjetoNegocio.EdadMinima);
            Parametros.AgregarParametro("EdadMaxima", ObjetoNegocio.EdadMaxima);
            Parametros.AgregarParametro("IdTipoPlan", ObjetoNegocio.TipoPlan.Id);
            Parametros.AgregarParametro("IdTipoModalidad", ObjetoNegocio.TipoModalidad.Id);
            Parametros.AgregarParametro("Categoria", ObjetoNegocio.Categoria);
            Parametros.AgregarParametro("Contenido", ObjetoNegocio.Contenido == null ? "" : ObjetoNegocio.Contenido);
            Parametros.AgregarParametro("IdValidezTerritorialClausula", ObjetoNegocio.ValidezTerritorialClausula == null
                ? 0 : ObjetoNegocio.ValidezTerritorialClausula.Id);
            Parametros.AgregarParametro("IdValidezTerritorial", ObjetoNegocio.ValidezTerritorial == null
                ? 0 : ObjetoNegocio.ValidezTerritorial.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            Parametros.AgregarParametro("Peso", ObjetoNegocio.Peso);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(ContenidoClausulaRango ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausulaRango", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdContenidoClausula", ObjetoNegocio.IdContenidoClausula);
            Parametros.AgregarParametro("EdadMinima", ObjetoNegocio.EdadMinima);
            Parametros.AgregarParametro("EdadMaxima", ObjetoNegocio.EdadMaxima);
            Parametros.AgregarParametro("IdTipoPlan", ObjetoNegocio.TipoPlan.Id);
            Parametros.AgregarParametro("IdTipoModalidad", ObjetoNegocio.TipoModalidad.Id);
            Parametros.AgregarParametro("Categoria", ObjetoNegocio.Categoria);
            Parametros.AgregarParametro("Contenido", ObjetoNegocio.Contenido);
            Parametros.AgregarParametro("IdValidezTerritorialClausula", ObjetoNegocio.ValidezTerritorialClausula == null
                ? 0 : ObjetoNegocio.ValidezTerritorialClausula.Id);
            Parametros.AgregarParametro("IdValidezTerritorial", ObjetoNegocio.ValidezTerritorial == null
                ? 0 : ObjetoNegocio.ValidezTerritorial.Id);
            Parametros.AgregarParametro("Peso", ObjetoNegocio.Peso);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(ContenidoClausulaRango ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausulaRango", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(ContenidoClausulaRango ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausulaRango", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdContenidoClausula", ObjetoNegocio.IdContenidoClausula);
            Parametros.AgregarParametro("EdadMinima", ObjetoNegocio.EdadMinima);
            Parametros.AgregarParametro("EdadMaxima", ObjetoNegocio.EdadMaxima);
            Parametros.AgregarParametro("IdTipoPlan", ObjetoNegocio.TipoPlan.Id);
            Parametros.AgregarParametro("IdTipoModalidad", ObjetoNegocio.TipoModalidad.Id);
            Parametros.AgregarParametro("Categoria", ObjetoNegocio.Categoria);
            Parametros.AgregarParametro("Contenido", ObjetoNegocio.Contenido == null ? "" : ObjetoNegocio.Contenido);
            Parametros.AgregarParametro("IdValidezTerritorialClausula", ObjetoNegocio.ValidezTerritorialClausula == null
                ? 0 : ObjetoNegocio.ValidezTerritorialClausula.Id);
            Parametros.AgregarParametro("IdValidezTerritorial", ObjetoNegocio.ValidezTerritorial == null
                ? 0 : ObjetoNegocio.ValidezTerritorial.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            Parametros.AgregarParametro("Peso", ObjetoNegocio.Peso);

            return Parametros;
        }

        protected override void Completar(ContenidoClausulaRango ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdContenidoClausulaRango"]);
            ObjetoPersistido.IdContenidoClausula = Convert.ToInt32(dr["IdContenidoClausula"]);
            ObjetoPersistido.EdadMinima = Convert.ToInt32(dr["EdadMinima"]);
            ObjetoPersistido.EdadMaxima = Convert.ToInt32(dr["EdadMaxima"]);
            ObjetoPersistido.TipoPlan = DAOTipoPlan.Instancia().Obtener(
                Convert.ToInt32(dr["IdTipoPlan"]));
            ObjetoPersistido.TipoModalidad = DAOTipoModalidad.Instancia().Obtener(
                Convert.ToInt32(dr["IdTipoModalidad"]));
            ObjetoPersistido.Categoria = Convert.ToInt32(dr["Categoria"]);
            ObjetoPersistido.Contenido = dr["Contenido"].ToString();
            ObjetoPersistido.ValidezTerritorialClausula = DAOValidezTerritorialClausula.Instancia().
                Obtener(Convert.ToInt32(dr["IdValidezTerritorialClausula"]));
            ObjetoPersistido.ValidezTerritorial = DAOValidezTerritorial.Instancia().Obtener(
                Convert.ToInt32(dr["IdValidezTerritorial"]));
            ObjetoPersistido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"]);

            /* Agregado de peso*/
            ObjetoPersistido.Peso = DBNull.Value.Equals(dr["Peso"]) ? Convert.ToDecimal(null) : Convert.ToDecimal(dr["Peso"]);
        }

        public IList<ContenidoClausulaRango> Buscar(int IdContenidoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdContenidoClausula", IdContenidoClausula);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.ContenidoClausulaRango_Tx_IdContenidoClausula"));
        }

        public IList<ContenidoClausulaRango> Buscar(ContextoGrupoPorRango Contexto, int IdContenidoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdContenidoClausula", IdContenidoClausula);
            Parametros.AgregarParametro("Edad", Contexto.Edad);
            Parametros.AgregarParametro("IdTipoPlan", Contexto.IdTipoPlan);
            Parametros.AgregarParametro("IdTipoModalidad", Contexto.IdTipoModalidad);
            Parametros.AgregarParametro("Categoria", Contexto.Categoria);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.ContenidoClausulaRango_Tx_Edad"));
        }

        public void Eliminar(int IdContenidoClausula, TransactionScope ts)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdContenidoClausula", IdContenidoClausula);
            Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.Eliminado());

            Eliminar("dbo.ContenidoClausulaRangoMasiva_E", Parametros, ts);
        }

        public void EliminarGrupo(int IdGrupoClausula, TransactionScope ts)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.Eliminado());

            Eliminar("dbo.ContenidoClausulaRangoMasivaGrupo_E", Parametros, ts);
        }

        public void Modificar(ContextoModificacionRango Contexto, 
            int IdGrupoClausula, int IdClausula, string Contenido)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdClausula", IdClausula);
            Parametros.AgregarParametro("EdadMinima", Contexto.EdadMinima);
            Parametros.AgregarParametro("EdadMaxima", Contexto.EdadMaxima);
            Parametros.AgregarParametro("IdTipoPlan", Contexto.IdTipoPlan);
            Parametros.AgregarParametro("IdTipoModalidad", Contexto.IdTipoModalidad);
            Parametros.AgregarParametro("Categoria", Contexto.Categoria);
            Parametros.AgregarParametro("Contenido", Contenido);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            Modificar("dbo.ContenidoClausulaRango_M_Contenido", Parametros);
        }

        public void Modificar(ContextoModificacionRango Contexto,
            int IdGrupoClausula, int IdClausula, IList<Leyenda> Leyendas)
        {
            foreach (Leyenda Leyenda in Leyendas)
            {
                Parametros Parametros = new Parametros();

                Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
                Parametros.AgregarParametro("IdClausula", IdClausula);
                Parametros.AgregarParametro("EdadMinima", Contexto.EdadMinima);
                Parametros.AgregarParametro("EdadMaxima", Contexto.EdadMaxima);
                Parametros.AgregarParametro("IdTipoPlan", Contexto.IdTipoPlan);
                Parametros.AgregarParametro("IdTipoModalidad", Contexto.IdTipoModalidad);
                Parametros.AgregarParametro("Categoria", Contexto.Categoria);
                Parametros.AgregarParametro("IdIdioma", Leyenda.IdIdioma);
                Parametros.AgregarParametro("Texto", Leyenda.Texto);
                Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

                Modificar("dbo.Leyenda_M_ContenidoClausulaRango", Parametros);
            }
        }

        protected override void CrearComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, TransactionScope ts)
        {
            ContenidoClausulaRango Contenido = (ContenidoClausulaRango)ObjetoNegocio;

            if (Contenido.Leyendas == null)
            {
                return;
            }

            foreach (Leyenda Leyenda in Contenido.Leyendas)
            {
                Leyenda.IdContenidoClausulaRango = Contenido.Id;
                Leyenda.IdUsuario = Contenido.IdUsuario;

                Leyenda.Persistir(ts);
            }
        }

        protected override void ModificarComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, TransactionScope ts)
        {
            CrearComposicion(ObjetoNegocio, ts);
        }

        protected override void EliminarComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, TransactionScope ts)
        {
            ContenidoClausulaRango Contenido = (ContenidoClausulaRango)ObjetoNegocio;

            DAOLeyenda.Instancia().Eliminar(Contenido.Id, ts);
        }

        protected override void CompletarComposicion(ContenidoClausulaRango ObjetoPersistido)
        {
            ObjetoPersistido.Leyendas = DAOLeyenda.Instancia().
                Buscar(ObjetoPersistido.Id);
        }
    }
}
