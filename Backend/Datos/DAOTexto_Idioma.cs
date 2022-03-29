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
    public class DAOTexto_Idioma : DAOObjetoNegocio<Texto_Idioma>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Condiciones";

        #endregion

        #region Singleton

        private static DAOTexto_Idioma _Instancia;

        private DAOTexto_Idioma()
        {
        }

        public static DAOTexto_Idioma Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTexto_Idioma();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override Parametros ParametrosCrear(Texto_Idioma ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTexto", ObjetoNegocio.IdTexto);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Texto", ObjetoNegocio.Texto);
            return Parametros;
        }

        protected override Parametros ParametrosModificar(Texto_Idioma ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTexto_R_Idioma", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Texto", ObjetoNegocio.Texto);
            return Parametros;
        }

        protected override Parametros ParametrosEliminar(Texto_Idioma ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(Texto_Idioma ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTexto_R_Idioma", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdTexto", ObjetoNegocio.IdTexto);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Texto", ObjetoNegocio.Texto);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(Texto_Idioma ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdTexto_R_Idioma"];
            ObjetoPersistido.IdTexto = (int)dr["IdTexto"];
            ObjetoPersistido.IdIdioma = (int)dr["IdIdioma"];
            ObjetoPersistido.Texto = (string)dr["Texto"];
        }

        #endregion

        #region Metodos

        public IList<Texto_Idioma> BuscarPorTexto(int Id)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdTexto", Id);

            Filtro Filtro = new Filtro(p, "dbo.Texto_R_Idioma_TX_IdTexto");
            return Buscar(Filtro);
        }

        #endregion

    }
}
