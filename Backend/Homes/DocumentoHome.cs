using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.DTO;
using BackendCondiciones.Datos;

namespace Backend.Homes
{
    public class DocumentoHome
    {
        public static Documento Obtener(int Id)
        {
            return DAODocumento.Instancia().Obtener(Id);
        }

        public static IList<Documento> Buscar()
        {
            return DAODocumento.Instancia().Buscar();
        }

        public static IList<Documento> BuscarPorParametros(int IdTipoDocumento, string Nombre)
        {
            return DAODocumento.Instancia().BuscarPorParametros(IdTipoDocumento, Nombre);
        }

        public static IList<Documento> BuscarPorIdioma(int IdIdioma)
        {
            return DAODocumento.Instancia().BuscarPorIdioma(IdIdioma);
        }

        public static IList<DocumentoDTO> BuscarDocumentoDTO()
        {
            return DAODocumentoDTO.Instancia().Buscar();
        }

    }

    

}
