using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Backend.Dominio;
using Backend.Homes;

namespace ServicioConsultaClausulas
{
    // NOTE: If you change the class name "ServicioTarifa" here, you must also update the reference to "ServicioTarifa" in Web.config.
    public class ServicioTarifa : IServicioTarifa
    {
 
        #region IServicioTarifa Members

        public void AgregarTarifa(TarifaWS TarifaWS)
        {
            string xml = ServicioConversionXml.Instancia().SerializeObject(TarifaWS);

            Producto Producto = ProductoHome.Obtener(
                TarifaWS.CodigoPais, TarifaWS.Producto.CodigoProducto);

            if (Producto.Id == 0)
            {
                Producto.IdTipoGrupoClausula = TarifaWS.IdTipoGrupoClausula;
                Producto.CodigoPais = TarifaWS.CodigoPais;
                Producto.Codigo = TarifaWS.Producto.CodigoProducto;
                Producto.Nombre = TarifaWS.Producto.Nombre;

                Producto.Persistir();
            }

            Tarifa Tarifa = TarifaHome.Obtener(TarifaWS.CodigoPais, 
                TarifaWS.Producto.CodigoProducto, TarifaWS.CodigoTarifa, TarifaWS.Anual);

            if (Tarifa.Id == 0)
            {
                Tarifa.IdProducto = Producto.Id;
                Tarifa.CodigoPais = TarifaWS.CodigoPais;
                Tarifa.Codigo = TarifaWS.CodigoTarifa;
                Tarifa.Nombre = TarifaWS.Nombre;
                Tarifa.Sufijo = TarifaWS.Sufijo;
                Tarifa.Anual = TarifaWS.Anual;
                Tarifa.IdTipoGrupoClausula = TarifaWS.IdTipoGrupoClausula;
                Tarifa.Activa = TarifaWS.Activa;

                Tarifa.Persistir();
            }
        }

        #endregion
    }
}
