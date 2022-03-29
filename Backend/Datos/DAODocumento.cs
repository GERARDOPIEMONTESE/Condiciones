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
    public class DAODocumento : DAOObjetoNegocio<Documento>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Condiciones";

        #endregion

        #region Singleton

        private static DAODocumento _Instancia;

        private DAODocumento()
        {
        }

        public static DAODocumento Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAODocumento();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos
         
        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override Parametros ParametrosCrear(Documento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros(); 
            Parametros.AgregarParametro("IdTipoDocumento", ObjetoNegocio.TipoDocumento.Id);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("Documento", ObjetoNegocio.DocumentoContenido);
            Parametros.AgregarParametro("DocumentoDimension", ObjetoNegocio.DocumentoDimension);
            Parametros.AgregarParametro("DocumentoTipoContenido", ObjetoNegocio.DocumentoTipoContenido);
            Parametros.AgregarParametro("CodigoValidacion", ObjetoNegocio.CodigoValidacion);            
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            Parametros.AgregarParametro("Observaciones", ObjetoNegocio.Observaciones);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.Idioma.Id);
 
            return Parametros;
        }

        protected override Parametros ParametrosModificar(Documento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdDocumento", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdTipoDocumento", ObjetoNegocio.TipoDocumento.Id);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("Documento", ObjetoNegocio.DocumentoContenido);
            Parametros.AgregarParametro("DocumentoDimension", ObjetoNegocio.DocumentoDimension);
            Parametros.AgregarParametro("DocumentoTipoContenido", ObjetoNegocio.DocumentoTipoContenido);
            Parametros.AgregarParametro("Observaciones", ObjetoNegocio.Observaciones);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.Idioma.Id);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(Documento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdDocumento", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdTipoDocumento", ObjetoNegocio.TipoDocumento.Id);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("Documento", ObjetoNegocio.DocumentoContenido);
            Parametros.AgregarParametro("DocumentoDimension", ObjetoNegocio.DocumentoDimension);
            Parametros.AgregarParametro("DocumentoTipoContenido", ObjetoNegocio.DocumentoTipoContenido);
            Parametros.AgregarParametro("CodigoValidacion", ObjetoNegocio.CodigoValidacion);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("Fecha", DateTime.Now);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            Parametros.AgregarParametro("Observaciones", ObjetoNegocio.Observaciones);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.Idioma.Id);

            return Parametros;
        }

        protected override Parametros ParametrosEliminar(Documento ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdDocumento", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }
 
        protected override void Completar(Documento ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdDocumento"];
            ObjetoPersistido.TipoDocumento = DAOTipoDocumento.Instancia().Obtener((int)dr["IdTipoDocumento"]);
            ObjetoPersistido.Nombre = (string)dr["Nombre"];
            ObjetoPersistido.DocumentoDimension = Convert.ToInt64(dr["DocumentoDimension"]);
            ObjetoPersistido.DocumentoTipoContenido = (string)dr["DocumentoTipoContenido"];
            ObjetoPersistido.CodigoValidacion = (Guid)dr["CodigoValidacion"];
            ObjetoPersistido.Fecha = (DateTime)dr["Fecha"];
            ObjetoPersistido.Observaciones = dr["Observaciones"].ToString();
            ObjetoPersistido.Idioma = DAOIdioma.Instancia().Obtener((int)dr["IdIdioma"]);
            try
            {
                ObjetoPersistido.DocumentoContenido = (byte[])dr["Documento"] ;
            }
            catch (Exception) { }
        }
 
        #endregion

        #region Metodos

        public IList<Documento> BuscarPorParametros(int IdTipoDocumento, string Nombre)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdTipoDocumento", IdTipoDocumento);
            p.AgregarParametro("Nombre", Nombre);
 
            Filtro Filtro = new Filtro(p, "dbo.Documento_Tx_BuscarPorParametros");
            return Buscar(Filtro);
        }

        public IList<Documento> BuscarPorIdioma(int IdIdioma)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdIdioma", IdIdioma);

            Filtro Filtro = new Filtro(p, "dbo.Documento_TX_IdIdioma");
            return Buscar(Filtro);
        }

        public IList<Documento> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.Documento_Tx_BuscarPorParametros"));
        }

        #endregion
    }

}
