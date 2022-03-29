using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class RiesgoTerceros : ObjetoNegocio
    {
        private const string NOMBRE = "RiesgoTerceros";

        #region Propiedades

        public int IdPais { get; set; }
        public string DescripcionPais { get; set; }
        public string TipoNegocio { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int? IdCompaniaSeguro { get; set; }
        public string CompaniaSeguro { get; set; }
        public string Riesgo { get; set; }
        public DateTime? FechaInicioVigencia { get; set; }
        public DateTime? FechaFinVigencia { get; set; }
        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAORiesgoTerceros.Instancia();
        }
    }
}
