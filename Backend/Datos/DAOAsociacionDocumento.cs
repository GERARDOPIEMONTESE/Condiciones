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
    public class DAOAsociacionDocumento : DAOObjetoNegocio<AsociacionDocumento>
    {
        #region Singleton

        private static DAOAsociacionDocumento _Instancia;

        private DAOAsociacionDocumento()
        {
        }

        public static DAOAsociacionDocumento Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOAsociacionDocumento();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(AsociacionDocumento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdObjeto", ObjetoNegocio.IdObjeto);
            Parametros.AgregarParametro("IdDocumento", ObjetoNegocio.Documento.Id);
            Parametros.AgregarParametro("IdTipoAsociacionDocumento", ObjetoNegocio.TipoAsociacionDocumento.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(AsociacionDocumento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdAsociacionDocumento", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdObjeto", ObjetoNegocio.IdObjeto);
            Parametros.AgregarParametro("IdDocumento", ObjetoNegocio.Documento.Id);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(AsociacionDocumento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdAsociacionDocumento", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(AsociacionDocumento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdAsociacionDocumento", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdObjeto", ObjetoNegocio.IdObjeto);
            Parametros.AgregarParametro("IdDocumento", ObjetoNegocio.Documento.Id);
            Parametros.AgregarParametro("IdTipoAsociacionDocumento", ObjetoNegocio.TipoAsociacionDocumento.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(AsociacionDocumento ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdAsociacionDocumento"]);            
            ObjetoPersistido.Documento = DAODocumento.Instancia().Obtener(Convert.ToInt32(dr["IdDocumento"]), true);
            ObjetoPersistido.TipoAsociacionDocumento = DAOTipoAsociacionDocumento.
                Instancia().Obtener(Convert.ToInt32(dr["IdTipoAsociacionDocumento"]));
            ObjetoPersistido.IdObjeto = Convert.ToInt32(dr["IdObjeto"]);
            ObjetoPersistido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"]);
        }

        public IList<AsociacionDocumento> Buscar(int IdObjeto, int IdTipoAsociacionDocumento)
        {
            return Buscar(IdObjeto, IdTipoAsociacionDocumento, 0);
        }

        public IList<AsociacionDocumento> Buscar(int IdObjeto, int IdTipoAsociacionDocumento, int IdTipoDocumento)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoAsociacionDocumento", IdTipoAsociacionDocumento);
            Parametros.AgregarParametro("IdObjeto", IdObjeto);
            Parametros.AgregarParametro("IdTipoDocumento", IdTipoDocumento);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.AsociacionDocumento_Tx_IdObjeto"));
        }

        public void Eliminar(int IdGrupoClausula, TransactionScope ts)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdEstadoBorrado", ObjetoNegocio.Eliminado());

            Eliminar("dbo.AsociacionDocumentoMasiva_E", Parametros, ts);
        }

        public IList<AsociacionDocumento> Buscar()
        {
            return Buscar(0);
        }

        public IList<AsociacionDocumento> Buscar(int IdTipoAsociacionDocumento)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoAsociacionDocumento", IdTipoAsociacionDocumento);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());
            Parametros.AgregarParametro("IdExcluyeTipoAsociacion", 3);

            return Buscar(new Filtro(Parametros, "dbo.AsociacionDocumento_Tx_IdTipoAsociacionDocumento"));   
        }

        public IList<AsociacionDocumento> BuscarPorDocumento(int IdDocumento, int IdTipoAsociacionDocumento)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdDocumento", IdDocumento);
            Parametros.AgregarParametro("IdTipoAsociacionDocumento", IdTipoAsociacionDocumento);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.AsociacionDocumento_Tx_IdDocumento"),true);
        }
        public void BorrarAsocisiones(int IdDocumento) 
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdDocumento", IdDocumento);
                
            Ejecutar(new Filtro(Parametros, "dbo.AsociacionDocumento_BorrarPorDocumento"));
        }


        public void CrearAsociacionesADocumento(int IdDocumento, string asociados, int tipoasociacion,int IdUsuario)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdDocumento", IdDocumento);
            Parametros.AgregarParametro("Asociados", asociados);
            Parametros.AgregarParametro("TipoAsociacion", tipoasociacion);
            Parametros.AgregarParametro("IdUsuario", IdUsuario);

            Ejecutar(new Filtro(Parametros, "dbo.AsociacionDocumento_CrearAsociacionesADocumento"));
        }
    }
}
