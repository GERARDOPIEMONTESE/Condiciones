using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Backend.Dominio;
using Backend.Homes;
using Backend.DTO;

namespace ServicioCondiciones
{
    // NOTE: If you change the class name "ServicioTarifa" here, you must also update the reference to "ServicioTarifa" in Web.config.
    public class ServicioTarifa : IServicioTarifa
    {
        #region Singleton

        private static IServicioTarifa _Instancia;

        private ServicioTarifa()
        {
        }

        public static IServicioTarifa Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioTarifa();
            }
            return _Instancia;
        }

        #endregion

        #region IServicioTarifa Members

        private int ObtenerIdTipoModalidad(TarifaWS TarifaWS)
        {
            int IdTipoModalidad = TipoModalidadHome.Obtener(TarifaWS.ModalidadTarifa).Id;
                
            return IdTipoModalidad == 0 ? 
                TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id : IdTipoModalidad;
        }

        public string AgregarTarifa(TarifaWS TarifaWS)
        {
            string Mensaje = "Tarifa creada exitosamente. No existe grupo para esta tarifa.";

            Producto Producto = ProductoHome.Obtener(
                TarifaWS.CodigoPais, TarifaWS.Producto.CodigoProducto, TarifaWS.IdTipoGrupoClausula);

            if (Producto.Id == 0)
            {
                Producto.IdTipoGrupoClausula = TarifaWS.IdTipoGrupoClausula;
                Producto.CodigoPais = TarifaWS.CodigoPais;
                Producto.Codigo = TarifaWS.Producto.CodigoProducto;
                Producto.Nombre = TarifaWS.Producto.Nombre;
                Producto.Persistir();
            }

            //FIX Debe buscar por Id de producto y no por codigo - pais porque puede haber productos, upgrade etc repetidos.
            Tarifa tarifa = TarifaHome.Obtener(Producto.Id, TarifaWS.CodigoPais, TarifaWS.CodigoTarifa, TarifaWS.Anual);

            bool EsNueva = tarifa.Id == 0;

            tarifa.IdProducto = Producto.Id;
            tarifa.CodigoPais = TarifaWS.CodigoPais;
            tarifa.Codigo = TarifaWS.CodigoTarifa;
            tarifa.Nombre = TarifaWS.Nombre;
            tarifa.Sufijo = TarifaWS.Sufijo;
            tarifa.Anual = TarifaWS.Anual;
            tarifa.IdTipoGrupoClausula = TarifaWS.IdTipoGrupoClausula;
            tarifa.Activa = TarifaWS.Activa;
            tarifa.IdTipoModalidad = ObtenerIdTipoModalidad(TarifaWS);
            tarifa.Persistir();

            if (tarifa.Sufijo != null && tarifa.Sufijo.Trim().Length > 0)
            {
                Mensaje = AsociarGrupoATarifaConSufijo(Mensaje, tarifa);
            }
            //*Si se quita la validacion "Es Nueva" en este metodo se puede asociar automaticamente cada tarifa a un grupo aun cuando esta sea modificada *//
            if(tarifa.Sufijo == null || tarifa.Sufijo == ""){

                Mensaje = AsociarGrupoATarifaSinSufijo(Mensaje, tarifa);
            }
            return Mensaje;
        }

        private string AsociarGrupoATarifaSinSufijo(string Mensaje, Tarifa tarifa)
        {
            if (!GrupoClausulaHome.Existe(tarifa, TipoGrupoClausulaHome.Obtener(tarifa.IdTipoGrupoClausula)))
            {
                //if(true){
                IList<GrupoClausula> GruposAAsociar =
                GrupoClausulaHome.BuscarGrupoTarifaPorProductoYModalidad(tarifa.IdTipoGrupoClausula, tarifa.CodigoPais, tarifa.IdProducto, tarifa.Anual, tarifa.IdTipoModalidad);
                if (GruposAAsociar.Count > 0)
                {
                    GrupoClausula Grupo = GrupoClausulaHome.Obtener(GruposAAsociar[0].Id);
                    Grupo.Objetos.Add(CrearObjeto(Grupo, tarifa));
                    Grupo.Persistir();
                    Mensaje = "Tarifa creada exitosamente. La tarifa fue asociada al grupo.";
                }
            }
            else {
                Mensaje = "Tarifa creada exitosamente. Ya existe un grupo para esta tarifa.";
            }
            return Mensaje;
        }

        private string AsociarGrupoATarifaConSufijo(string Mensaje, Tarifa tarifa)
        {
            if (!GrupoClausulaHome.Existe(tarifa, TipoGrupoClausulaHome.Obtener(tarifa.IdTipoGrupoClausula)))
            {
                IList<GrupoClausulaTarifaDTO> Grupos =
                    GrupoClausulaHome.BuscarGrupoTarifa(tarifa.IdTipoGrupoClausula, tarifa.CodigoPais, tarifa.IdProducto, tarifa.Sufijo);

                if (Grupos.Count > 0)
                {
                    GrupoClausula Grupo = GrupoClausulaHome.Obtener(Grupos[0].Id);
                    Grupo.Objetos.Add(CrearObjeto(Grupo, tarifa));
                    Grupo.Persistir();

                    Mensaje = "Tarifa creada exitosamente. La tarifa fue asociada al grupo con sufijo: " + tarifa.Sufijo + ".";
                }
            }
            else {
                Mensaje = "Tarifa creada exitosamente. Ya existe un grupo para esta tarifa.";
            }
            return Mensaje;
        }


        private ObjetoAgrupadorClausula CrearObjeto(GrupoClausula Grupo, Tarifa Tarifa)
        {
            ObjetoAgrupadorClausula Objeto = new ObjetoAgrupadorClausula();

            Objeto.IdObjetoAgrupador = Tarifa.Id;
            Objeto.TipoGrupoClausula = Grupo.TipoGrupoClausula;
            Objeto.IdGrupoClausula = Grupo.Id;

            return Objeto;
        }

        #endregion
    }
}
