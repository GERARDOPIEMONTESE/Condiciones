//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.4927
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaCondiciones.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://172.17.1.111:8027/ServicioClausulasWS.asmx")]
        public string PruebaCondiciones_ServicioClausulaTestingWS_ServicioClausulasWS {
            get {
                return ((string)(this["PruebaCondiciones_ServicioClausulaTestingWS_ServicioClausulasWS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://serviciocondiciones.assist-card.com/ServicioClausulasWS.asmx")]
        public string PruebaCondiciones_ServicioClausulasWSProduccion_ServicioClausulasWS {
            get {
                return ((string)(this["PruebaCondiciones_ServicioClausulasWSProduccion_ServicioClausulasWS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://172.17.0.111:8027/ServicioTarifaWS.asmx")]
        public string PruebaCondiciones_ServicioTarifaTestingWS_ServicioTarifaWS {
            get {
                return ((string)(this["PruebaCondiciones_ServicioTarifaTestingWS_ServicioTarifaWS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4179/ServicioTarifaWS.asmx")]
        public string PruebaCondiciones_ServicioTarifaWS_ServicioTarifaWS {
            get {
                return ((string)(this["PruebaCondiciones_ServicioTarifaWS_ServicioTarifaWS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://prendarios.prestamolibre.com.ar/prendariowsmobile/mobile.asmx")]
        public string PruebaCondiciones_PREND_Servicios {
            get {
                return ((string)(this["PruebaCondiciones_PREND_Servicios"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:3046/ServicioClausulasWS.asmx")]
        public string PruebaCondiciones_ServicioClausulaWS_ServicioClausulasWS {
            get {
                return ((string)(this["PruebaCondiciones_ServicioClausulaWS_ServicioClausulasWS"]));
            }
        }
    }
}
