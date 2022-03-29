using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOValidezTerritorial : DAOObjetoCodificado<ValidezTerritorial>
    {
        #region Singleton

        private static DAOValidezTerritorial _Instancia;

        private DAOValidezTerritorial()
        {
        }

        public static DAOValidezTerritorial Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOValidezTerritorial();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreSchemaDefault()
        {
            return "Locacion.";
        }

        protected override void Completar(ValidezTerritorial ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdLocacion"]);
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
        }

        public IList<ValidezTerritorial> Buscar()
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("NombreTipoLocacion", ValidezTerritorial.TIPO_LOCACION);

            return Buscar(new Filtro(Parametros, "Locacion.Locacion_Tx_TipoLocacion"));
        }

        public ValidezTerritorial ObtenerPorNombre(string Nombre)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Nombre", Nombre);
            Parametros.AgregarParametro("NombreTipoLocacion", ValidezTerritorial.TIPO_LOCACION);

            return Obtener(new Filtro(Parametros, "Locacion.Locacion_Tx_Nombre"));
        }

    }
}
