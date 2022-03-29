using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.DTO;

namespace Backend.Homes
{
    public class AsociacionDocumentoHome
    {
        public static IList<AsociacionDocumento> Buscar()
        {
            return DAOAsociacionDocumento.Instancia().Buscar();
        }

        public static IList<AsociacionDocumento> Buscar(int IdTipoAsociacionDocumento)
        {
            return DAOAsociacionDocumento.Instancia().Buscar(IdTipoAsociacionDocumento);
        }

        public static IList<AsociacionDocumento> BuscarPorDocumento(int IdDocumento, int IdTipoAsociacionDocumento)
        {
            return DAOAsociacionDocumento.Instancia().BuscarPorDocumento(IdDocumento, IdTipoAsociacionDocumento);
        }

        public static AsociacionDocumento Obtener(int Id)
        {
            return DAOAsociacionDocumento.Instancia().Obtener(Id);
        }

        public static IList<AsociacionDocumentoDTO> BuscarDTO(int IdTipoAsociacionDocumento)
        {
            IList<AsociacionDocumento> Asociaciones = Buscar(IdTipoAsociacionDocumento);
            IList<AsociacionDocumentoDTO> Dtos = new List<AsociacionDocumentoDTO>();

            foreach (AsociacionDocumento Asociacion in Asociaciones)
            {
                AsociacionDocumentoDTO Dto = new AsociacionDocumentoDTO();

                Dto.Id = Asociacion.Id;
                Dto.TipoAsociacionDocumento = Asociacion.TipoAsociacionDocumento.Descripcion;
                Dto.NombreDocumento = Asociacion.Documento.Nombre;

                if (TipoAsociacionDocumento.PAIS.Equals(
                    Asociacion.TipoAsociacionDocumento.Codigo))
                {
                    Dto.NombreObjeto = PaisHome.ObtenerPorIdLocacion(Asociacion.IdObjeto).Nombre;
                }

                if (TipoAsociacionDocumento.PRODUCTO.Equals(
                    Asociacion.TipoAsociacionDocumento.Codigo))
                {
                    Dto.NombreObjeto = ProductoHome.Obtener(Asociacion.IdObjeto).Nombre;
                }
                
                Dtos.Add(Dto);
            }

            return Dtos;
        }

        public static IList<AsociacionDocumento> Buscar(int IdProducto, int Id)
        {
            return DAOAsociacionDocumento.Instancia().Buscar(IdProducto, Id);
        }

        public static IList<AsociacionDocumento> BuscarPorObjeto(int IdObjeto, int IdTipoAsociacionDocumento)
        {
            return DAOAsociacionDocumento.Instancia().Buscar(IdObjeto, IdTipoAsociacionDocumento);
        }

        public static void BorrarAsociasiones(int IdDocumento)
        {
            DAOAsociacionDocumento.Instancia().BorrarAsocisiones(IdDocumento);
        }
        public static void CrearAsociacionesADocumento(int IdDocumento, string asociados, int tipoasociacion, int IdUsuario) 
        {
            DAOAsociacionDocumento.Instancia().CrearAsociacionesADocumento(IdDocumento, asociados, tipoasociacion, IdUsuario);
        }
    }
}
