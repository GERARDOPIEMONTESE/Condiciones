using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class ProductoHome
    {
        public static IList<Producto> Buscar(int CodigoPais, int IdTipoGrupoClausula)
        {
            return DAOProducto.Instancia().Buscar(CodigoPais, IdTipoGrupoClausula);
        }

        public static IList<Producto> BuscarOrdenadoNombre(int CodigoPais, int IdTipoGrupoClausula)
        {
            return DAOProducto.Instancia().BuscarOrdenadoNombre(CodigoPais, IdTipoGrupoClausula);
        }

        public static IList<Producto> Buscar(IList<int> Paises, int IdTipoGrupoClausula)
        {
            IList<Producto> Productos = new List<Producto>();
            foreach (int CodigoPais in Paises)
            {
                IList<Producto> ProductosPais = DAOProducto.Instancia().
                    Buscar(CodigoPais, IdTipoGrupoClausula);
                foreach (Producto Producto in ProductosPais)
                {
                    Productos.Add(Producto);
                }
            }

            return Productos;
        }

        public static Producto Obtener(int Id)
        {
            return DAOProducto.Instancia().Obtener(Id);
        }

        public static Producto Obtener(int CodigoPais, string Codigo)
        {
            return DAOProducto.Instancia().Obtener(Codigo, CodigoPais);
        }

        public static Producto Obtener(int CodigoPais, string Codigo, int IdTipoGrupoClausula)
        {
            return DAOProducto.Instancia().Obtener(Codigo, CodigoPais, IdTipoGrupoClausula);
        }
    }
}
