using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNetFormatos;

namespace CondicionesMigracion.ACNetServicio
{
    public class ServicioCompatibilidadFormato
    {
        #region Singleton

        private static ServicioCompatibilidadFormato _Instancia;

        private IDictionary<string, IConversorFormato> _Formatos = new Dictionary<string, IConversorFormato>();

        private ServicioCompatibilidadFormato()
        {
            Inicializar();
        }

        public static ServicioCompatibilidadFormato Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioCompatibilidadFormato();
            }

            return _Instancia;
        }

        private void Inicializar()
        {
            _Formatos.Add("ESADBU", new ConversorFormatoIndemnizacion());
            _Formatos.Add("ESAGSI", new ConversorFormatoAge());
            _Formatos.Add("ESAOMC", new ConversorFormatoEdad());
            _Formatos.Add("ESCODO", new ConversorFormatoConsulta());
            _Formatos.Add("ESDMV2", new ConversorFormatoEuro());
            _Formatos.Add("ESEDR2", new ConversorFormatoEuroTotal());
            _Formatos.Add("ESEDRM", new ConversorFormatoEuroTotal());
            _Formatos.Add("ESEDSO", new ConversorFormatoEuroTotal());
            _Formatos.Add("ESEVMV", new ConversorFormatoEuro());
            _Formatos.Add("ESEVMZ", new ConversorFormatoEuro());
            _Formatos.Add("ESOMV2", new ConversorFormatoEuro());
            _Formatos.Add("INOMV2", new ConversorFormatoEuro());
            _Formatos.Add("POOMV2", new ConversorFormatoEuro());            
            _Formatos.Add("ESHDDS", new ConversorFormatoDias());
            _Formatos.Add("ESHDVC", new ConversorFormatoDias());
            _Formatos.Add("ESHMIA", new ConversorFormatoPreposicion());
            _Formatos.Add("ESHMVS", new ConversorFormatoPreposicion());
            _Formatos.Add("ESIAMV", new ConversorFormatoCancelacion());            
            _Formatos.Add("ESIMVC", new ConversorFormatoCondicional());
            _Formatos.Add("ESINCL", new ConversorFormatoIncluye());
            _Formatos.Add("ESMVCE", new ConversorFormatoCompuesto());
            _Formatos.Add("ESMVCO", new ConversorFormatoCompuesto());
            _Formatos.Add("ESMVIA", new ConversorFormatoSimple());
            _Formatos.Add("ESMVIC", new ConversorFormatoMVIncluye());
            _Formatos.Add("ESMVID", new ConversorFormatoMVIncluye());
            _Formatos.Add("ESMVIH", new ConversorFormatoMVIncluye());
            _Formatos.Add("ESMVPO", new ConversorFormatoPorcentaje());
            _Formatos.Add("ESMVRU", new ConversorFormatoRubro());
            _Formatos.Add("ESMVRV", new ConversorFormatoRubro());
            _Formatos.Add("ESMVSC", new ConversorFormatoSeguro());
            _Formatos.Add("ESMVSI", new ConversorFormatoSimple());
            _Formatos.Add("ESRRSI", new ConversorFormatoRegular());
            _Formatos.Add("ESVATE", new ConversorFormatoValidezTerritorial());
            _Formatos.Add("ESVOYY", new ConversorFormatoEdad());
            _Formatos.Add("INADBU", new ConversorFormatoIndemnizacion());
            _Formatos.Add("INAOMC", new ConversorFormatoEdad());
            _Formatos.Add("INDMV2", new ConversorFormatoEuro());
            _Formatos.Add("INDVPV", new ConversorFormatoJapan());
            _Formatos.Add("INEDRM", new ConversorFormatoEuroTotal());
            _Formatos.Add("INHDDS", new ConversorFormatoDias());
            _Formatos.Add("INHMVS", new ConversorFormatoPreposicion());
            _Formatos.Add("INIAMV", new ConversorFormatoCancelacion());
            _Formatos.Add("INIMVC", new ConversorFormatoCondicional());
            _Formatos.Add("ININCL", new ConversorFormatoIncluye());
            _Formatos.Add("INMVCO", new ConversorFormatoCompuesto());
            _Formatos.Add("INMVIC", new ConversorFormatoMVIncluye());
            _Formatos.Add("INMVID", new ConversorFormatoMVIncluye());
            _Formatos.Add("INMVRU", new ConversorFormatoRubro());
            _Formatos.Add("INMVSC", new ConversorFormatoSeguro());
            _Formatos.Add("INVATE", new ConversorFormatoValidezTerritorial());
            _Formatos.Add("INVOYS", new ConversorFormatoEdad());
            _Formatos.Add("ISTEXT", new ConversorFormatoTexto());
            _Formatos.Add("POADBU", new ConversorFormatoIndemnizacion());
            _Formatos.Add("POAOMC", new ConversorFormatoEdad());
            _Formatos.Add("PODMV2", new ConversorFormatoEuro());
            _Formatos.Add("POEDRM", new ConversorFormatoEuroTotal());
            _Formatos.Add("POHDDS", new ConversorFormatoDias());
            _Formatos.Add("POHMVS", new ConversorFormatoPreposicion());
            _Formatos.Add("POINCL", new ConversorFormatoIncluye());
            _Formatos.Add("POMVIC", new ConversorFormatoMVIncluye());
            _Formatos.Add("POMVID", new ConversorFormatoMVIncluye());
            _Formatos.Add("POMVRU", new ConversorFormatoRubro());
            _Formatos.Add("POVATE", new ConversorFormatoValidezTerritorial());
            _Formatos.Add("POVOMM", new ConversorFormatoEdad());
            _Formatos.Add("POVOYY", new ConversorFormatoEdad());
        }

        #endregion
    }
}
