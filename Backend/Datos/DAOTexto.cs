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
    public class DAOTexto : DAOObjetoNegocio<Texto>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Condiciones";

        #endregion

        #region Singleton

        private static DAOTexto _Instancia;

        private DAOTexto()
        {
        }

        public static DAOTexto Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTexto();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos
         
        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override Parametros ParametrosCrear(Texto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("IdTipoTexto", ObjetoNegocio.TipoTexto.Id);
            Parametros.AgregarParametro("IdTipoTextoResumen", ObjetoNegocio.TipoTextoResumen.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("Fecha", ObjetoNegocio.Fecha);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            
            return Parametros;
        }

        protected override Parametros ParametrosModificar(Texto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            
            Parametros.AgregarParametro("IdTexto", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("IdTipoTexto", ObjetoNegocio.TipoTexto.Id);
            Parametros.AgregarParametro("IdTipoTextoResumen", ObjetoNegocio.TipoTextoResumen.Id);

            return Parametros;
        }

        protected override Parametros ParametrosEliminar(Texto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            
            Parametros.AgregarParametro("IdTexto", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(Texto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTexto", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("IdTipoTexto", ObjetoNegocio.TipoTexto.Id);
            Parametros.AgregarParametro("IdTipoTextoResumen", ObjetoNegocio.TipoTextoResumen.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("Fecha", ObjetoNegocio.Fecha);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void CrearComposicion(ObjetoNegocio ObjetoNegocio, TransactionScope ts)
        {
            Texto Texto = (Texto)ObjetoNegocio;

            foreach (Texto_Idioma Texto_Idioma in Texto.Texto_Idioma)
            {
                Texto_Idioma.IdTexto = Texto.Id;
                Texto_Idioma.IdUsuario = Texto.IdUsuario;

                Texto_Idioma.Persistir(ts);
            }  
        }

        protected override void ModificarComposicion(ObjetoNegocio ObjetoNegocio, TransactionScope ts)
        {
            CrearComposicion(ObjetoNegocio, ts);
        }

        protected override void Completar(Texto ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdTexto"];
            ObjetoPersistido.Nombre = (string)dr["Nombre"];
            ObjetoPersistido.TipoTexto = DAOTipoTexto.Instancia().Obtener(
                Convert.ToInt32(dr["IdTipoTexto"]));
            ObjetoPersistido.TipoTextoResumen = DAOTipoTextoResumen.Instancia().Obtener(
                Convert.ToInt32(dr["IdTipoTextoResumen"]));
            ObjetoPersistido.Texto_Idioma = DAOTexto_Idioma.Instancia().BuscarPorTexto((int)dr["IdTexto"]);
            ObjetoPersistido.Fecha = (DateTime)dr["Fecha"];
        }

        #endregion

        #region Metodos

        public IList<Texto> BuscarPorParametros(string Nombre, int IdTipoTexto, int IdIdioma)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("Nombre", Nombre);
            p.AgregarParametro("IdTipoTexto", IdTipoTexto);
            p.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            Filtro Filtro = new Filtro(p, "dbo.Texto_Tx_BuscarPorParametros");
            
            IList<Texto> ITexto = Buscar(Filtro);

            foreach (Texto texto in ITexto)
                texto.Idioma = IdIdioma;

            return ITexto;
        }

        public Texto Obtener(int IdTipoTexto, string Nombre)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("Nombre", Nombre);
            p.AgregarParametro("IdTipoTexto", IdTipoTexto);

            Filtro Filtro = new Filtro(p, "dbo.Texto_Tx_BuscarPorParametros");
            return Obtener(Filtro);
        }

        #endregion
    }

}
