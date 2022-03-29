using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.DTO;


namespace Backend.Homes
{
    public class ClausulaHome
    {

        public static Clausula Obtener(int Id)
        {
            return DAOClausula.Instancia().Obtener(Id, true);
        }

        public static Clausula Obtener(string Codigo)
        {
            return DAOClausula.Instancia().Obtener(Codigo);
        }

        public static IList<Clausula> BuscarPorParametros(int IdTipoClausula, string Codigo, string Nombre)
        {
            return DAOClausula.Instancia().BuscarPorParametros(IdTipoClausula, Codigo, Nombre);
        }

        public static IList<Clausula> Buscar()
        {
            return DAOClausula.Instancia().Buscar();
        }

        public static IList<ClausulaDTO> BuscarDTO(IList<int> IdsGrupoClausula)
        {
            IList<Clausula> Clausulas = DAOClausula.Instancia().Buscar(IdsGrupoClausula);
            IList<ClausulaDTO> ClausulasDTO = new List<ClausulaDTO>();

            foreach (Clausula Clausula in Clausulas)
            {
                ClausulaDTO Dto = new ClausulaDTO();
                Dto.Id = Clausula.Id;
                Dto.NombreClausula = Clausula.Codigo;
                Dto.TextoIdentificatorio = Clausula.Codigo;

                ClausulasDTO.Add(Dto);
            }
            return ClausulasDTO;
        }

        public static IList<Clausula> Buscar(int IdTipoClausula)
        {
            return DAOClausula.Instancia().Buscar(IdTipoClausula);
        }

        public static IList<ClausulaIdiomaDTO> BuscarDTOPorParametros(int IdTipoClausula, string Codigo, string Nombre)
        {
            IList<Clausula> IClausula = DAOClausula.Instancia().BuscarPorParametros(IdTipoClausula, Codigo, Nombre);
            IList<ClausulaIdiomaDTO> IClausulaDTO = new List<ClausulaIdiomaDTO>();

            foreach (Clausula clausula in IClausula)
            {
                foreach (Clausula_Idioma clausula_idioma in clausula.Clausula_Idioma)
                {
                    ClausulaIdiomaDTO ClausulaIdiomaDTO = new ClausulaIdiomaDTO();
                    ClausulaIdiomaDTO.Id = clausula.Id;
                    ClausulaIdiomaDTO.Codigo = clausula.Codigo;
                    ClausulaIdiomaDTO.OrdenPredefinido = clausula.OrdenPredefinido;
                    ClausulaIdiomaDTO.Nombre = clausula_idioma.Nombre;
                    ClausulaIdiomaDTO.Idioma = IdiomaHome.ObtenerNombreIdioma(clausula_idioma.IdIdioma);
                    ClausulaIdiomaDTO.TipoClausula = clausula.TipoClausula.Nombre;

                    IClausulaDTO.Add(ClausulaIdiomaDTO);
                }
            }

            return IClausulaDTO;
        }


    }



  

}
