
namespace ServicioCondiciones
{
    public class ConditionsReportObject
    {
        #region Properties

        public string ConditionsReportTitle { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public string Leyend { get; set; }

        #endregion

        #region Constructor

        public ConditionsReportObject(string codeTypeContentPrint, string code, string text,
                            string leyend, string reportTitle)
        {
            //if (code.ToUpper().Equals("LEGAL"))
            //    code = string.Empty;
            Code = code;
            Text = text;
            Leyend = leyend;
            ConditionsReportTitle = reportTitle;
            //switch (codeTypeContentPrint.ToUpper())
            //{
            //    case "CONT":
            //        Text = "";
            //        break;
            //    case "IDCONT":
            //        Text = "";
            //        return;
            //    case "DESCONT":
            //        Code = "";
            //        return;
            //    default:
            //        return;
            //}
        }

        #endregion
    }
}