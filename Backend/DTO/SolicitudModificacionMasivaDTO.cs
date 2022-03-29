using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.DTO
{
    public class SolicitudModificacionMasivaDTO : ObjetoNegocio
    {
        private const string NOMBRE = "SolicitudModificacionMasivaDTO";

        public string Productos { get; set; }
        public string Paises { get; set; }
        public string TE { get; set; }
        public bool TTR { get; set; }
        public int IdTipOperacion { get; set; }
        public string CodigoClausulaUbicacion { get; set; }
        public string CodigoClausula { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public string Español { get; set; }
        public string Ingles { get; set; }
        public string Portugues { get; set; }
        public bool Procesado { get; set; }


        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOSolicitudModificacionMasivaDTO.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
