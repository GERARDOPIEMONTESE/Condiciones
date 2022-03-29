using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using CondicionesMigracion.ACNetDatos;
using Backend.Dominio;
using Backend.Homes;

namespace CondicionesMigracion.ACNetServicio
{

    public class ServicioMigracionProductosTarifas
    {
        #region Singleton

        private static ServicioMigracionProductosTarifas _Instancia;

        private ServicioMigracionProductosTarifas()
        {
        }

        public static ServicioMigracionProductosTarifas Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioMigracionProductosTarifas();
            }
            return _Instancia;
        }

        #endregion

        private int ObtenerTipoModalidad(int IdModalidadACNET)
        {
            int IdTipoModalidad = 1;

            switch (IdModalidadACNET)
            {
                case 0: 
                    IdTipoModalidad = 1;
                    break;
                case 2:
                    IdTipoModalidad = 2;
                    break;
                case 3:
                    IdTipoModalidad = 3;
                    break;
                case 1:
                    IdTipoModalidad = 6;
                    break;
                case 5:
                    IdTipoModalidad = 4;
                    break;
                case 4:
                    IdTipoModalidad = 5;
                    break;
                case 6:
                    IdTipoModalidad = 7;
                    break;
                case 7:
                    IdTipoModalidad = 8;
                    break;
                case 8:
                    IdTipoModalidad = 9;
                    break;
            
            }

            return IdTipoModalidad;
        }

        private void Generar(IList<TarifaACNET> Tarifas)
        {
            foreach (TarifaACNET TarifaACNET in Tarifas)
            {
                Tarifa Tarifa = TarifaHome.Obtener(TarifaACNET.CodigoPais, TarifaACNET.CodigoProducto, TarifaACNET.Codigo, TarifaACNET.Anual);

                Tarifa.CodigoPais = TarifaACNET.CodigoPais;
                Tarifa.Codigo = TarifaACNET.Codigo;
                Tarifa.Nombre = TarifaACNET.Nombre;
                Tarifa.Sufijo = TarifaACNET.Sufijo;
                Tarifa.Anual = TarifaACNET.Anual;
                Tarifa.Activa = TarifaACNET.Activa;
                Tarifa.IdTipoGrupoClausula = TarifaACNET.Tipo;
                Tarifa.IdProducto = ProductoHome.Obtener(
                    TarifaACNET.CodigoPais, TarifaACNET.CodigoProducto).Id;
                Tarifa.IdTipoModalidad = ObtenerTipoModalidad(TarifaACNET.IdTipoModalidad);

                if (Tarifa.IdProducto > 0)
                {
                    Tarifa.Persistir();
                }
            }
        }

        public void Migrar()
        {
            //IList<ProductoACNET> Productos = DAOProductoACNET.Instancia().Buscar();

            //foreach (ProductoACNET ProductoACNET in Productos)
            //{
            //    Producto Producto = new Producto();

            //    Producto.Codigo = ProductoACNET.Codigo;
            //    Producto.Nombre = ProductoACNET.Nombre;
            //    Producto.CodigoPais = ProductoACNET.Pais;
            //    Producto.IdTipoGrupoClausula = ProductoACNET.Tipo;

            //    Producto.Persistir();
            //}

            Generar(DAOTarifaACNET.Instancia().BuscarProductos());
            //Generar(DAOTarifaACNET.Instancia().BuscarUpgrades());
        }
    }
}
