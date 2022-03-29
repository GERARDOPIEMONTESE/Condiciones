using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;
using System.Configuration;
using Backend.Dominio;
using Backend.Homes;

namespace CapitasMigracion.Datos
{
    public class ValidezTerritorialPersistence
    {
        #region Queries

        private const string INSERT_LOCATION = "INSERT INTO Portal.Locacion.Locacion (IdTipoLocacion, Nombre, IdMonedaImpresion, IdMonedaFacturacion, IdEstado) VALUES((SELECT IdTipoLocacion FROM Portal.Locacion.TipoLocacion WHERE Nombre = 'Validez Territorial'), ':1', -1, -1, 25000)";

        //private const string INSERT_DETAIL = "INSERT INTO Portal.Locacion.Locacion_R_Locacion (IdLocacion, IdLocacionPadre) VALUES(:1, :2)";
        private const string INSERT_DETAIL = "INSERT INTO Portal.Locacion.Locacion_R_Locacion (IdLocacion, IdLocacionPadre) VALUES(ISNULL((SELECT IdLocacion FROM Locacion.Pais WHERE Codigo = :1) ,0) , ISNULL((SELECT IdLocacion FROM Portal.Locacion.Locacion, Portal.Locacion.TipoLocacion WHERE Locacion.IdTipoLocacion = TipoLocacion.IdTipoLocacion and TipoLocacion.Nombre = 'Validez Territorial' AND Locacion.Nombre = ':2'), 0))";

        private const string SELECT_DETAIL = "SELECT * FROM Portal.Locacion.Locacion_R_Locacion WHERE IdLocacion = :1 AND IdLocacionPadre = :2";

        #endregion

        public static void Crear(LocationGroup Location)
        {
            ValidezTerritorial ValidezTerritorial = ValidezTerritorialHome.Obtener(Location.Nombre);

            if (ValidezTerritorial.Id == 0)
            {
                QueryExecutor.Ejecutar(INSERT_LOCATION.Replace(":1", Location.Nombre),
                    ConfigurationManager.ConnectionStrings["Portal"].ToString());

                ValidezTerritorial = ValidezTerritorialHome.Obtener(Location.Nombre);
            }
        }

        public static void Crear(LocationGroup Locacion, IList<LocationGroupDetails> Details)
        {
            foreach (LocationGroupDetails Detail in Details)
            {
                try
                {//Insert busqueda x nombre y tipo de locacion padre
                    QueryExecutor.Ejecutar(INSERT_DETAIL.Replace(":1", Detail.CountryCode.ToString()).
                        Replace(":2", Locacion.Nombre),
                        ConfigurationManager.ConnectionStrings["Portal"].ToString());
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
