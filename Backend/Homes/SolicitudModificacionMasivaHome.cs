using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Datos;
using Backend.Dominio;
using Backend.DTO;

namespace Backend.Homes
{
    public class SolicitudModificacionMasivaHome
    {
        public static IList<SolicitudModificacionMasivaDTO> Buscar(int IdTipoOperacion) 
        {
            return DAOSolicitudModificacionMasivaDTO.Instancia().Buscar(IdTipoOperacion);
        }
        
    }
}
