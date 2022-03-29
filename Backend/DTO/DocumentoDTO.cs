using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.DTO
{
    //FEOOO! Pero es por performance .. es inviable sino!
    public class DocumentoDTO : ObjetoPersistido
    {
        private const string NOMBRE = "Documento";

        #region Propiedades

        public string Nombre {get; set;}
        public int IdIdioma { get; set; }
        public int IdTipoDoc { get; set; }

        #endregion

        public DocumentoDTO(int pId, string pNombre, int pIdIdioma)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.IdIdioma = pIdIdioma;
        }

        public DocumentoDTO()
        {
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
