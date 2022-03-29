using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.Contextos;
using Backend.DTO;
using CapaNegocioDatos.CapaNegocio;


namespace Backend.Homes
{
    public class GrupoClausulaHome
    {
        public static GrupoClausula Obtener(int Id)
        {
            return DAOGrupoClausula.Instancia().Obtener(Id);
        }

        public static GrupoClausula Obtener(int Id, bool Lazy)
        {
            return DAOGrupoClausula.Instancia().Obtener(Id, Lazy);
        }

        public static IList<GrupoClausula> Buscar(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, string Sufijo, string CodigoTarifa)
        {
            return DAOGrupoClausula.Instancia().
                Buscar(IdTipoGrupoClausula, CodigoPais, 
                IdProducto, Sufijo, CodigoTarifa);
        }

        public static IList<GrupoClausulaListaDTO> BuscarDTO(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, string Sufijo, string CodigoTarifa)
        {
            IList<GrupoClausula> GruposClausula = Buscar(IdTipoGrupoClausula, CodigoPais,
                IdProducto, Sufijo, CodigoTarifa);

            IList<GrupoClausulaListaDTO> GruposClausulaDTO = new List<GrupoClausulaListaDTO>();

            foreach (GrupoClausula Grupo in GruposClausula)
            {
                GruposClausulaDTO.Add(new GrupoClausulaListaDTO(Grupo));
            }

            return GruposClausulaDTO;
        }

        public static IList<GrupoClausulaListaDTO> BuscarDTO(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, string Sufijo)
        {
            return BuscarDTO(IdTipoGrupoClausula, CodigoPais, IdProducto, Sufijo, "");
        }

        public static IList<GrupoClausulaListaDTO> BuscarDTO(int IdTipoGrupoClausula, int CodigoPais,
            string CodigoProducto, string Sufijo, string CodigoTarifa)
        {
            IList<GrupoClausula> GruposClausula = DAOGrupoClausula.Instancia().
                Buscar(IdTipoGrupoClausula, CodigoPais, 
                CodigoProducto, Sufijo, CodigoTarifa);

            IList<GrupoClausulaListaDTO> GruposClausulaDTO = new List<GrupoClausulaListaDTO>();

            foreach (GrupoClausula Grupo in GruposClausula)
            {
                GruposClausulaDTO.Add(new GrupoClausulaListaDTO(Grupo));
            }

            return GruposClausulaDTO;
        }

        public static IList<GrupoClausulaListaDTO> BuscarDTO(int IdTipoGrupoClausula, 
            IList<int> Paises, string CodigoProducto, 
            string Sufijo, string CodigoTarifa)
        {
            IList<GrupoClausula> GruposClausula = new List<GrupoClausula>();
            IList<GrupoClausulaListaDTO> GruposClausulaDTO = new List<GrupoClausulaListaDTO>();

            foreach (int CodigoPais in Paises)
            {
                GruposClausula = GruposClausula.Concat<GrupoClausula>
                    (DAOGrupoClausula.Instancia().Buscar(IdTipoGrupoClausula, 
                    CodigoPais, CodigoProducto, Sufijo, CodigoTarifa)).ToList<GrupoClausula>();

                foreach (GrupoClausula Grupo in GruposClausula)
                {
                    GruposClausulaDTO.Add(new GrupoClausulaListaDTO(Grupo));
                }
                GruposClausula.Clear();
            }

            return GruposClausulaDTO;
        }
        
        public static IList<GrupoClausulaListaDTO> BuscarDTO(int IdTipoGrupoClausula,
            IList<int> Paises, string CodigoProducto,
            string Sufijo)
        {            
            return BuscarDTO(IdTipoGrupoClausula, Paises, CodigoProducto, Sufijo, "");
        }

        public static IList<GrupoClausula> Buscar(ContextoGrupoPorRango Contexto)
        {
            return DAOGrupoClausula.Instancia().Buscar(Contexto);
        }

        public static IList<GrupoClausula> BuscarSimple(ContextoGrupoPorRango Contexto)
        {
            return DAOGrupoClausula.Instancia().BuscarSimple(Contexto);
        }

        //SLA
        public static IList<GrupoClausula> BuscarSLA(ContextoGrupoPorRango Contexto)
        {
            return DAOGrupoClausula.Instancia().BuscarSLA(Contexto);
        }
        //Fin SLA

        public static bool Existe(Clausula Clausula)
        {
            return DAOGrupoClausula.Instancia().Existe(Clausula);
        }

        public static bool Existe(Tarifa Tarifa, TipoGrupoClausula TipoGrupoClausula)
        {
            return DAOGrupoClausula.Instancia().Existe(Tarifa, TipoGrupoClausula);
        }

        public static IList<GrupoClausulaListaDTO> Buscar(Documento Documento)
        {
            IList<GrupoClausula> GruposClausula = DAOGrupoClausula.Instancia().Buscar(Documento);
            IList<GrupoClausulaListaDTO> GruposClausulaDTO = new List<GrupoClausulaListaDTO>();

            foreach (GrupoClausula Grupo in GruposClausula)
            {
                GruposClausulaDTO.Add(new GrupoClausulaListaDTO(Grupo));
            }

            return GruposClausulaDTO;
        }

        public static IList<GrupoClausulaTarifaDTO> BuscarGrupoTarifa(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, string Sufijo, string CodigoTarifa)
        {
            return DAOGrupoClausulaTarifaDTO.Instancia().Buscar(
                IdTipoGrupoClausula, CodigoPais, IdProducto, Sufijo, CodigoTarifa);
        }

        public static IList<GrupoClausulaTarifaDTO> BuscarGrupoTarifa(int IdTipoGrupoClausula, IList<int> CodigosPais,
            string CodigoProducto, string Sufijo, string CodigoTarifa)
        {
            IList<GrupoClausulaTarifaDTO> Grupos = new List<GrupoClausulaTarifaDTO>();
            foreach(int CodigoPais in CodigosPais) {
                IList<GrupoClausulaTarifaDTO> GruposPorPais = DAOGrupoClausulaTarifaDTO.Instancia().Buscar(
                    IdTipoGrupoClausula, CodigoPais, CodigoProducto, Sufijo, CodigoTarifa);
                foreach(GrupoClausulaTarifaDTO Grupo in GruposPorPais) 
                {
                    Grupos.Add(Grupo);
                }
            }
            return Grupos;
        }

        public static IList<GrupoClausulaTarifaDTO> BuscarGrupoTarifa(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, string Sufijo)
        {
            return BuscarGrupoTarifa(IdTipoGrupoClausula, CodigoPais, IdProducto, Sufijo, "");
        }

        public static IList<GrupoClausula> BuscarGrupoTarifaPorProductoYModalidad(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, bool Anual, int IdModalidadTarifa)
        {
            return DAOGrupoClausula.Instancia().Buscar(
                IdTipoGrupoClausula, CodigoPais,IdProducto,Anual, IdModalidadTarifa);
        }

        public static IList<GrupoClausulaSLADTO> BuscarGrupoSLA(int IdTipoGrupoClausula, int CodigoPais, string Agencia, int Sucursal)
        {
            return DAOGrupoClausulaSLADTO.Instancia().Buscar(IdTipoGrupoClausula, CodigoPais, Agencia, Sucursal);
        }

        public static bool Existe(Sucursal Sucursal, TipoGrupoClausula TipoGrupoClausula)
        {
            return DAOGrupoClausula.Instancia().Existe(Sucursal.Id, TipoGrupoClausula);
        }
    }
}
