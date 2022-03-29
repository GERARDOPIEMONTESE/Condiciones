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
    public class DAOContenidoClausula : DAOObjetoNegocio<ContenidoClausula>
    {
        #region Singleton

        private static DAOContenidoClausula _Instancia;

        private DAOContenidoClausula()
        {
        }

        public static DAOContenidoClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOContenidoClausula();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(ContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdClausula", ObjetoNegocio.IdClausula);
            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoImpresionClausula", ObjetoNegocio.TipoImpresionClausula.Id);
            Parametros.AgregarParametro("IdTipoContenidoImpresion", ObjetoNegocio.TipoContenidoImpresion.Id);
            Parametros.AgregarParametro("EvaluableEnAsistencia", ObjetoNegocio.EvaluableEnAsistencia);
            Parametros.AgregarParametro("VisibleEnAsistencia", ObjetoNegocio.VisibleEnAsistencia);
            Parametros.AgregarParametro("IdTipoCobertura", ObjetoNegocio.TipoCobertura == null ? -1 : ObjetoNegocio.TipoCobertura.Id);
            Parametros.AgregarParametro("Orden", ObjetoNegocio.Orden);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(ContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdClausula", ObjetoNegocio.IdClausula);
            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoImpresionClausula", ObjetoNegocio.TipoImpresionClausula.Id);
            Parametros.AgregarParametro("IdTipoContenidoImpresion", ObjetoNegocio.TipoContenidoImpresion.Id);
            Parametros.AgregarParametro("EvaluableEnAsistencia", ObjetoNegocio.EvaluableEnAsistencia);
            Parametros.AgregarParametro("VisibleEnAsistencia", ObjetoNegocio.VisibleEnAsistencia);
            Parametros.AgregarParametro("IdTipoCobertura", ObjetoNegocio.TipoCobertura == null ? -1 : ObjetoNegocio.TipoCobertura.Id);
            Parametros.AgregarParametro("Orden", ObjetoNegocio.Orden);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(ContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(ContenidoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdContenidoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdClausula", ObjetoNegocio.IdClausula);
            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoImpresionClausula", ObjetoNegocio.TipoImpresionClausula.Id);
            Parametros.AgregarParametro("IdTipoContenidoImpresion", ObjetoNegocio.TipoContenidoImpresion.Id);
            Parametros.AgregarParametro("EvaluableEnAsistencia", ObjetoNegocio.EvaluableEnAsistencia);
            Parametros.AgregarParametro("VisibleEnAsistencia", ObjetoNegocio.VisibleEnAsistencia);
            Parametros.AgregarParametro("IdTipoCobertura", ObjetoNegocio.TipoCobertura == null ? -1 : ObjetoNegocio.TipoCobertura.Id);
            Parametros.AgregarParametro("Orden", ObjetoNegocio.Orden);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(ContenidoClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdContenidoClausula"]);
            ObjetoPersistido.IdClausula = Convert.ToInt32(dr["IdClausula"]);
            ObjetoPersistido.IdGrupoClausula = Convert.ToInt32(dr["IdGrupoClausula"]);
            ObjetoPersistido.TipoImpresionClausula = DAOTipoImpresionClausula.Instancia().Obtener(
                Convert.ToInt32(dr["IdTipoImpresionClausula"]));
            ObjetoPersistido.TipoContenidoImpresion = DAOTipoContenidoImpresion.Instancia().Obtener(
                Convert.ToInt32(dr["IdTipoContenidoImpresion"]));
            ObjetoPersistido.EvaluableEnAsistencia = Convert.ToBoolean(dr["EvaluableEnAsistencia"]);
            ObjetoPersistido.VisibleEnAsistencia = Convert.ToBoolean(dr["VisibleEnAsistencia"]);
            ObjetoPersistido.TipoCobertura = DAOTipoCobertura.Instancia().Obtener(
                Convert.ToInt32(dr["IdTipoCobertura"]));
            ObjetoPersistido.Orden = Convert.ToInt32(dr["Orden"]);
            ObjetoPersistido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"]);
        }

        protected override void CrearComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, System.Transactions.TransactionScope ts)
        {
            string message = string.Empty;
            try
            {
                ContenidoClausula Contenido = (ContenidoClausula)ObjetoNegocio;

                EliminarComposicion(Contenido, ts);

                foreach (AsociacionContenidoClausula Padre in Contenido.Padres)
                {
                    Padre.IdContenidoClausulaHijo = Contenido.Id;
                    Padre.IdUsuario = Contenido.IdUsuario;
                    message = "AsociacionContenidoClausulaHijo";
                    Padre.Crear(ts);
                }

                foreach (ContenidoClausulaRango Rango in Contenido.Contenidos)
                {
                    Rango.IdContenidoClausula = Contenido.Id;
                    Rango.IdUsuario = Contenido.IdUsuario;
                    message = "Rango";
                    Rango.Persistir(ts);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(message + "."+ ex.Message);
            }
            
        }

        protected override void ModificarComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, System.Transactions.TransactionScope ts)
        {
            CrearComposicion(ObjetoNegocio, ts);
        }

        protected override void EliminarComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, System.Transactions.TransactionScope ts)
        {
            ContenidoClausula Contenido = (ContenidoClausula) ObjetoNegocio;

            DAOAsociacionContenidoClausula.Instancia().Eliminar(Contenido.Id, ts);

            DAOContenidoClausulaRango.Instancia().Eliminar(Contenido.Id, ts);

        }

        protected override void CompletarComposicion(ContenidoClausula ObjetoPersistido)
        {
            try
            {
                ObjetoPersistido.Padres = DAOAsociacionContenidoClausula.Instancia().
                    Buscar(ObjetoPersistido.Id);

                ObjetoPersistido.Contenidos = DAOContenidoClausulaRango.Instancia().
                    Buscar(ObjetoPersistido.Id);
            }
            catch (Exception e)
            {
            }
            
        }

        public ContenidoClausula Obtener(int IdGrupoClausula, int IdClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdClausula", IdClausula);
            Parametros.AgregarParametro("IdEstadoElimiando", ObjetoNegocio.Eliminado());

            return Obtener(new Filtro(Parametros, 
                "dbo.ContenidoClausula_Tx_IdGrupoClausula"));
        }

        public IList<ContenidoClausula> Buscar(int IdGrupoClausula, bool Lazy)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);

            return Buscar(new Filtro(
                Parametros, "dbo.ContenidoClausula_Tx_IdGrupoClausula"), Lazy);
        }

        public IList<ContenidoClausula> Buscar(int IdGrupoClausula)
        {
            return Buscar(IdGrupoClausula, false);
        }

        public void Eliminar(int IdGrupoClausula, TransactionScope ts)
        {
            DAOAsociacionContenidoClausula.Instancia().EliminarGrupo(IdGrupoClausula, ts);

            DAOContenidoClausulaRango.Instancia().EliminarGrupo(IdGrupoClausula, ts);

            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.Eliminado());

            Eliminar("dbo.ContenidoClausulaMasiva_E", Parametros, ts);
        }

        public void Modificar(int IdGrupoClausula, int IdClausula, IList<Leyenda> Leyendas)
        {
            foreach (Leyenda Leyenda in Leyendas)
            {
                Parametros Parametros = new Parametros();
                Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
                Parametros.AgregarParametro("IdClausula", IdClausula);
                Parametros.AgregarParametro("IdIdioma", Leyenda.IdIdioma);
                Parametros.AgregarParametro("Texto", Leyenda.Texto);
                Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

                Modificar("dbo.ContenidoClausula_M_Leyenda", Parametros);
            }
        }
    }
}
