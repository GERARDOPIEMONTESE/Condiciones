using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TarifaHome
    {
        public static IList<Tarifa> Buscar(int CodigoPais, int IdProducto, bool Anual)
        {
            return DAOTarifa.Instancia().Buscar(CodigoPais, IdProducto, Anual);
        }

        public static IList<Tarifa> Buscar(int CodigoPais, int IdProducto, 
            string CodigoTarifa, bool Activa, string sufijo, bool Anual)
        {
            return DAOTarifa.Instancia().Buscar(CodigoPais, IdProducto, 
                CodigoTarifa, Activa, sufijo, Anual);
        }

        public static IList<Tarifa> Buscar(int CodigoPais, int IdProducto, 
            string CodigoTarifa)
        {
            return DAOTarifa.Instancia().Buscar(CodigoPais, IdProducto, CodigoTarifa);
        }

        public static IList<Tarifa> Buscar(int CodigoPais, int IdProducto,
            string CodigoTarifa, int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo)
        {
            return DAOTarifa.Instancia().Buscar(CodigoPais, IdProducto,
                CodigoTarifa, IdGrupoClausula, IdTipoGrupoClausula, sufijo);
        }

        public static IList<Tarifa> Buscar(int CodigoPais, int IdProducto,
            string CodigoTarifa, int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo, bool Anual)
        {
            return DAOTarifa.Instancia().Buscar(CodigoPais, IdProducto,
                CodigoTarifa, IdGrupoClausula, IdTipoGrupoClausula, sufijo, Anual);
        }

        public static IList<Tarifa> BuscarPorOrden(int CodigoPais, int IdProducto,
            string CodigoTarifa, int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo, bool Anual)
        {
            IList<Tarifa> Tarifas = BuscarPorGrupo(IdGrupoClausula, IdTipoGrupoClausula, sufijo);

            IList<Tarifa> TarifasDisponibles = Buscar(CodigoPais, IdProducto,
                CodigoTarifa, IdGrupoClausula, IdTipoGrupoClausula, sufijo, Anual);

            foreach (Tarifa Tarifa in TarifasDisponibles) 
            {
                Tarifas.Add(Tarifa);
            }

            return Tarifas;
        }

        public static IList<Tarifa> BuscarPorGrupo(int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo)
        {
            return DAOTarifa.Instancia().BuscarPorGrupo(IdGrupoClausula, IdTipoGrupoClausula, sufijo);
        }

        public static IList<Tarifa> BuscarPorGrupo(int IdGrupoClausula, string CodigoTipoGrupoClausula)
        {
            TipoGrupoClausula Tipo = TipoGrupoClausulaHome.Obtener(CodigoTipoGrupoClausula);

            return DAOTarifa.Instancia().BuscarPorGrupo(IdGrupoClausula, Tipo.Id, null);
        }

        public static IList<Tarifa> Buscar(int CodigoPais, int IdProducto)
        {
            return DAOTarifa.Instancia().Buscar(CodigoPais, IdProducto);
        }

        public static Tarifa Obtener(int Id)
        {
            return DAOTarifa.Instancia().Obtener(Id);
        }

        public static Tarifa Obtener(int CodigoPais, string CodigoProducto, string Codigo, bool Anual)
        {
            return DAOTarifa.Instancia().Obtener(CodigoPais, CodigoProducto, Codigo, Anual);
        }

        public static IList<Tarifa> BuscarObtener(int CodigoPais, string CodigoProducto, string Codigo, bool Anual)
        {
            return DAOTarifa.Instancia().BuscarObtener(CodigoPais, CodigoProducto, Codigo, Anual);
        }

        public static IList<Tarifa> Buscar(string CodigoParcial, string SufijoParcial, int Cantidad, int IdProducto)
        {
            return DAOTarifa.Instancia().Buscar(CodigoParcial, SufijoParcial, Cantidad, IdProducto);
        }

        public static Tarifa Obtener(int idProducto, int codigoPais, string codigoTarifa, bool anual)
        {
            return DAOTarifa.Instancia().Obtener(idProducto, codigoPais, codigoTarifa, anual);
        }
    }
}
