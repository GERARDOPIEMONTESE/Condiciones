using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesMigracion.ACNetFormatos
{
    public class ConversorFormatoContainer
    {
        #region Atributos

        private IDictionary<string, IConversorFormato> _Conversores = 
            new Dictionary<string, IConversorFormato>();

        #endregion
        #region Singleton

        private static ConversorFormatoContainer _Instancia;

        private ConversorFormatoContainer()
        {
            Iniciar();
        }

        public static ConversorFormatoContainer Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ConversorFormatoContainer();
            }
            return _Instancia;
        }

        private void Iniciar()
        {
            //* - FORMATOS QUE VAN.
            _Conversores.Add("INIMVC", new ConversorFormatoCondicional());
            _Conversores.Add("ESOMV2", new ConversorFormatoEuro());
            _Conversores.Add("INOMV2", new ConversorFormatoEuro());
            _Conversores.Add("POOMV2", new ConversorFormatoEuro());            
            _Conversores.Add("ESAGSI", new ConversorFormatoAge()); //*
            _Conversores.Add("ESMVCO", new ConversorFormatoCompuesto()); //*
            _Conversores.Add("ESEVMV", new ConversorFormatoEuro()); //*
            _Conversores.Add("ESEVMZ", new ConversorFormatoEuro()); //*
            _Conversores.Add("ESEDRM", new ConversorFormatoEuroTotal()); //*
            _Conversores.Add("INEDRM", new ConversorFormatoEuroTotal()); //*
            _Conversores.Add("POEDRM", new ConversorFormatoEuroTotal()); //*
            _Conversores.Add("ESEDR2", new ConversorFormatoEuroTotal()); //*
            _Conversores.Add("ESEDSO", new ConversorFormatoEuroTotal()); //*
            _Conversores.Add("ININCL", new ConversorFormatoIncluye()); //*
            _Conversores.Add("ESINCL", new ConversorFormatoIncluye()); //*
            _Conversores.Add("POINCL", new ConversorFormatoIncluye()); //*
            _Conversores.Add("ESMVIC", new ConversorFormatoMVIncluye()); //*
            _Conversores.Add("INMVIC", new ConversorFormatoMVIncluye()); //*
            _Conversores.Add("POMVIC", new ConversorFormatoMVIncluye()); //*
            _Conversores.Add("ESMVIH", new ConversorFormatoMVIncluye()); //*
            _Conversores.Add("ESMVID", new ConversorFormatoMVIncluye()); //*
            _Conversores.Add("ESMVPO", new ConversorFormatoPorcentaje()); //*
            _Conversores.Add("ESHMIA", new ConversorFormatoPreposicion()); //*
            _Conversores.Add("ESHMVS", new ConversorFormatoPreposicion()); //*
            _Conversores.Add("INHMVS", new ConversorFormatoPreposicion()); //*
            _Conversores.Add("POHMVS", new ConversorFormatoPreposicion()); //*
            _Conversores.Add("ESRRSI", new ConversorFormatoRegular()); //*
            _Conversores.Add("ESMVSI", new ConversorFormatoSimple()); //*
            _Conversores.Add("ESMVIA", new ConversorFormatoSimple()); //*
            _Conversores.Add("ISTEXT", new ConversorFormatoTexto()); //*
            _Conversores.Add("ESDMV2", new ConversorFormatoEuroAE()); //*
            _Conversores.Add("INDMV2", new ConversorFormatoEuroAE()); //*
            _Conversores.Add("PODMV2", new ConversorFormatoEuroAE()); //*
            _Conversores.Add("GRAL", new ConversorFormatoGeneral());
            _Conversores.Add("ESIMVC", new ConversorFormatoCondicional());
            _Conversores.Add("ESIAMV", new ConversorFormatoCancelacion());
            _Conversores.Add("INIAMV", new ConversorFormatoCancelacion());
            _Conversores.Add("INMVCO", new ConversorFormatoCompuesto());
            _Conversores.Add("ESMVCE", new ConversorFormatoCompuesto());
            _Conversores.Add("ESCODO", new ConversorFormatoConsulta());
            _Conversores.Add("POHDDS", new ConversorFormatoDias());
            _Conversores.Add("ESHDDS", new ConversorFormatoDias());
            _Conversores.Add("INHDDS", new ConversorFormatoDias());
            _Conversores.Add("ESHDVC", new ConversorFormatoDias());
            _Conversores.Add("POAOMC", new ConversorFormatoEdad());
            _Conversores.Add("ESAOMC", new ConversorFormatoEdad());
            _Conversores.Add("INAOMC", new ConversorFormatoEdad());
            _Conversores.Add("INVOYS", new ConversorFormatoEdad());
            _Conversores.Add("ESVOYY", new ConversorFormatoEdad());
            _Conversores.Add("POVOYY", new ConversorFormatoEdad());
            _Conversores.Add("POVOMM", new ConversorFormatoEdad());
            _Conversores.Add("INADBU", new ConversorFormatoIndemnizacion());
            _Conversores.Add("ESADBU", new ConversorFormatoIndemnizacion());
            _Conversores.Add("POADBU", new ConversorFormatoIndemnizacion());
            _Conversores.Add("INDVPV", new ConversorFormatoJapan());
            _Conversores.Add("INMVID", new ConversorFormatoMVIncluye());
            _Conversores.Add("POMVID", new ConversorFormatoMVIncluye());
            _Conversores.Add("ESMVRU", new ConversorFormatoRubro());
            _Conversores.Add("ESMVRV", new ConversorFormatoRubro());
            _Conversores.Add("ESMVRA", new ConversorFormatoRubro());
            _Conversores.Add("INMVRU", new ConversorFormatoRubro());
            _Conversores.Add("INMVRV", new ConversorFormatoRubro());
            _Conversores.Add("INMVRA", new ConversorFormatoRubro());
            _Conversores.Add("POMVRU", new ConversorFormatoRubro());
            _Conversores.Add("POMVRV", new ConversorFormatoRubro());
            _Conversores.Add("POMVRA", new ConversorFormatoRubro());
            _Conversores.Add("ESMVSC", new ConversorFormatoSeguro());
            _Conversores.Add("INMVSC", new ConversorFormatoSeguro());
            _Conversores.Add("ESVATE", new ConversorFormatoValidezTerritorial());
            _Conversores.Add("INVATE", new ConversorFormatoValidezTerritorial());
            _Conversores.Add("POVATE", new ConversorFormatoValidezTerritorial());
        }

        #endregion

        public IConversorFormato Obtener(string Key)
        {
            if (_Conversores.Keys.Contains(Key.Trim()))
            {
                return _Conversores[Key.Trim()];
            }
            return _Conversores["GRAL"];
        }
    }
}
