using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;

namespace Backend.DTO
{
    public class ContenidoRangoDTO
    {
        #region Propiedades

        public int EdadMinima {get; set;}
        public int EdadMaxima {get; set;}
        public int IdTipoPlan  {get; set;}
        public int IdTipoModalidad  {get; set;}
        public int Categoria  {get; set;}
        public string Contenido {get; set;}
        public int IdValidezTerritorialClausula {get; set;}
        public int IdValidezTerritorial{get; set;}
        public int IdTipoDestino{get; set;}
        public IList<Leyenda> Leyendas {get; set;}
        public decimal? Peso { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Tasa { get; set; }

        #endregion
    }
}
