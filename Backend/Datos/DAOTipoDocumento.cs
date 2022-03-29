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
    public class DAOTipoDocumento : DAOObjetoPersistido<TipoDocumento>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Condiciones";

        #endregion

        #region Singleton

        private static DAOTipoDocumento _Instancia;

        private DAOTipoDocumento()
        {
        }

        public static DAOTipoDocumento Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoDocumento();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override void Completar(TipoDocumento ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdTipoDocumento"];
            ObjetoPersistido.Nombre = (string)dr["Nombre"];
        }

        #endregion

        #region Metodos

        public IList<TipoDocumento> Buscar()
        {
            Filtro Filtro = new Filtro(new Parametros(), "dbo.TipoDocumento_TT");
            return Buscar(Filtro);
        }

        #endregion
    }
}
