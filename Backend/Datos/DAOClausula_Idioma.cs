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
    public class DAOClausula_Idioma : DAOObjetoNegocio<Clausula_Idioma>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Condiciones";

        #endregion

        #region Singleton

        private static DAOClausula_Idioma _Instancia;

        private DAOClausula_Idioma()
        {
        }

        public static DAOClausula_Idioma Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausula_Idioma();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override Parametros ParametrosCrear(Clausula_Idioma ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdClausula", ObjetoNegocio.IdClausula);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);

            return Parametros;
        }

        protected override Parametros ParametrosModificar(Clausula_Idioma ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdClausula_R_Idioma", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdIdioma", ObjetoNegocio.IdIdioma);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);

            return Parametros;
        }

        protected override Parametros ParametrosEliminar(Clausula_Idioma ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            return Parametros;
        }

        protected override void Completar(Clausula_Idioma ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdClausula_R_Idioma"];
            ObjetoPersistido.IdClausula = (int)dr["IdClausula"];
            ObjetoPersistido.IdIdioma = (int)dr["IdIdioma"];
            ObjetoPersistido.Nombre = (string)dr["Nombre"];

        }

        #endregion

        #region Metodos

        public IList<Clausula_Idioma> BuscarPorClausula(int Id)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdClausula", Id);

            Filtro Filtro = new Filtro(p, "dbo.Clausula_R_Idioma_TX_IdClausula");
            return Buscar(Filtro);
        }

        #endregion

    }
}
