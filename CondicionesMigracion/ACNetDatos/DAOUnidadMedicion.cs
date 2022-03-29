using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOUnidadMedicion : DAOObjetoCodificado<UnidadMedicion>
    {
        #region Consultas

        private const string POR_ID = "SELECT * FROM ICARD.UNIDAD_MEDICION WHERE ID = ";

        #endregion

        #region Singleton

        private static DAOUnidadMedicion _Instancia;

        private DAOUnidadMedicion()
        {
        }

        public static DAOUnidadMedicion Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOUnidadMedicion();
            }
            return _Instancia;
        }

        #endregion

        protected override void Completar(UnidadMedicion ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(UnidadMedicion ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.Nombre = dr["NOMBRE"].ToString();
            ObjetoPersistido.Nomenclatura = dr["NOMENCLATURA"].ToString();
        }

        public override UnidadMedicion Obtener(int Id)
        {
            return ObtenerOracle(POR_ID + Id, true);
        }
    }
}
