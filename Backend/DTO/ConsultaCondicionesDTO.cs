using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendCondiciones.DTO
{
    public class ConsultaCondicionesDTO
    {
        #region Propiedades

        public string CodigoISOPais { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoTarifa { get; set; }
        public bool Anual { get; set; }
        public int Edad { get; set; }
        public string Agencia { get; set; }
        public int Sucursal { get; set; }
        public string Idioma { get; set; }
        public string TipoModalidad { get; set; }

        #endregion

        public ConsultaCondicionesDTO() { }
    }

    public class ReporteDespegar
    {
        #region Properties

        public string ConditionsReportTitle { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public string Leyend { get; set; }

        #endregion

        #region Constructor

        public ReporteDespegar(string codeTypeContentPrint, string code, string text,
                            string leyend, string reportTitle)
        {
            Code = code;
            Text = text;
            Leyend = leyend;
            ConditionsReportTitle = reportTitle;
        }

        #endregion
    }
}
