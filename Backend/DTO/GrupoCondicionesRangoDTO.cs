using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DTO
{
    public class GrupoCondicionesRangoDTO
    {
        #region Propiedades

        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public string TipoPlan { get; set; }
        public string TipoModalidad { get; set; }
        public string ValidezTerritorial { get; set; }
        public int Categoria { get; set; }
        public string Leyenda { get; set; }
        public decimal? Tasa { get; set; }
        public decimal? Valor { get; set; }

        #endregion
    }
}
