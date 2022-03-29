using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Datos;
using Backend.Dominio;
using Backend.DTO;


namespace Backend.Homes
{
    public class PaisHome
    {
        public static IList<Pais> Buscar()
        {
            return DAOPais.Instancia().Buscar();
        }

        public static IList<Pais> BuscarConProductos()
        {
            return DAOPais.Instancia().BuscarConProductos();
        }

        public static IList<PaisDTO> BuscarDTO()
        {
            IList<PaisDTO> Dtos = new List<PaisDTO>();
            IList<Pais> Paises = Buscar();

            foreach (Pais Pais in Paises)
            {
                Dtos.Add(new PaisDTO(Pais));
            }


            return Dtos;
        }

        public static Pais ObtenerPorIdLocacion(int IdLocacion)
        {
            return DAOPais.Instancia().ObtenerPorIdLocacion(IdLocacion);
        }

        public static Pais ObtenerPorCodigo(int Codigo)
        {
            return DAOPais.Instancia().ObtenerPorCodigo(Codigo);
        }

        public static Pais ObtenerPorCodigoISO2(string CodigoISO)
        {
            return DAOPais.Instancia().ObtenerPorCodigoISO2(CodigoISO);
        }
    }
}
