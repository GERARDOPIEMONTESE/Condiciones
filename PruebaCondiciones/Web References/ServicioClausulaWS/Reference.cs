﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.4927
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=2.0.50727.4927.
// 
#pragma warning disable 1591

namespace PruebaCondiciones.ServicioClausulaWS {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicioClausulasWSSoap", Namespace="http://tempuri.org/")]
    public partial class ServicioClausulasWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ObtenerCondicionesXmlOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerDocumentosProductoXmlOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerDocumentosPaisXmlOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerComparacionesXmlOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerClausulasCoincidentesXmlOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServicioClausulasWS() {
            this.Url = global::PruebaCondiciones.Properties.Settings.Default.PruebaCondiciones_ServicioClausulaWS_ServicioClausulasWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ObtenerCondicionesXmlCompletedEventHandler ObtenerCondicionesXmlCompleted;
        
        /// <remarks/>
        public event ObtenerDocumentosProductoXmlCompletedEventHandler ObtenerDocumentosProductoXmlCompleted;
        
        /// <remarks/>
        public event ObtenerDocumentosPaisXmlCompletedEventHandler ObtenerDocumentosPaisXmlCompleted;
        
        /// <remarks/>
        public event ObtenerComparacionesXmlCompletedEventHandler ObtenerComparacionesXmlCompleted;
        
        /// <remarks/>
        public event ObtenerClausulasCoincidentesXmlCompletedEventHandler ObtenerClausulasCoincidentesXmlCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerCondicionesXml", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerCondicionesXml(string XmlConsulta, string Usuario, string Clave) {
            object[] results = this.Invoke("ObtenerCondicionesXml", new object[] {
                        XmlConsulta,
                        Usuario,
                        Clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerCondicionesXmlAsync(string XmlConsulta, string Usuario, string Clave) {
            this.ObtenerCondicionesXmlAsync(XmlConsulta, Usuario, Clave, null);
        }
        
        /// <remarks/>
        public void ObtenerCondicionesXmlAsync(string XmlConsulta, string Usuario, string Clave, object userState) {
            if ((this.ObtenerCondicionesXmlOperationCompleted == null)) {
                this.ObtenerCondicionesXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerCondicionesXmlOperationCompleted);
            }
            this.InvokeAsync("ObtenerCondicionesXml", new object[] {
                        XmlConsulta,
                        Usuario,
                        Clave}, this.ObtenerCondicionesXmlOperationCompleted, userState);
        }
        
        private void OnObtenerCondicionesXmlOperationCompleted(object arg) {
            if ((this.ObtenerCondicionesXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerCondicionesXmlCompleted(this, new ObtenerCondicionesXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerDocumentosProductoXml", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerDocumentosProductoXml(int CodigoPais, string Codigo, string Usuario, string Clave) {
            object[] results = this.Invoke("ObtenerDocumentosProductoXml", new object[] {
                        CodigoPais,
                        Codigo,
                        Usuario,
                        Clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerDocumentosProductoXmlAsync(int CodigoPais, string Codigo, string Usuario, string Clave) {
            this.ObtenerDocumentosProductoXmlAsync(CodigoPais, Codigo, Usuario, Clave, null);
        }
        
        /// <remarks/>
        public void ObtenerDocumentosProductoXmlAsync(int CodigoPais, string Codigo, string Usuario, string Clave, object userState) {
            if ((this.ObtenerDocumentosProductoXmlOperationCompleted == null)) {
                this.ObtenerDocumentosProductoXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerDocumentosProductoXmlOperationCompleted);
            }
            this.InvokeAsync("ObtenerDocumentosProductoXml", new object[] {
                        CodigoPais,
                        Codigo,
                        Usuario,
                        Clave}, this.ObtenerDocumentosProductoXmlOperationCompleted, userState);
        }
        
        private void OnObtenerDocumentosProductoXmlOperationCompleted(object arg) {
            if ((this.ObtenerDocumentosProductoXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerDocumentosProductoXmlCompleted(this, new ObtenerDocumentosProductoXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerDocumentosPaisXml", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerDocumentosPaisXml(int CodigoPais, string Usuario, string Clave) {
            object[] results = this.Invoke("ObtenerDocumentosPaisXml", new object[] {
                        CodigoPais,
                        Usuario,
                        Clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerDocumentosPaisXmlAsync(int CodigoPais, string Usuario, string Clave) {
            this.ObtenerDocumentosPaisXmlAsync(CodigoPais, Usuario, Clave, null);
        }
        
        /// <remarks/>
        public void ObtenerDocumentosPaisXmlAsync(int CodigoPais, string Usuario, string Clave, object userState) {
            if ((this.ObtenerDocumentosPaisXmlOperationCompleted == null)) {
                this.ObtenerDocumentosPaisXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerDocumentosPaisXmlOperationCompleted);
            }
            this.InvokeAsync("ObtenerDocumentosPaisXml", new object[] {
                        CodigoPais,
                        Usuario,
                        Clave}, this.ObtenerDocumentosPaisXmlOperationCompleted, userState);
        }
        
        private void OnObtenerDocumentosPaisXmlOperationCompleted(object arg) {
            if ((this.ObtenerDocumentosPaisXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerDocumentosPaisXmlCompleted(this, new ObtenerDocumentosPaisXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerComparacionesXml", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerComparacionesXml(string XmlConsulta, string Usuario, string Clave) {
            object[] results = this.Invoke("ObtenerComparacionesXml", new object[] {
                        XmlConsulta,
                        Usuario,
                        Clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerComparacionesXmlAsync(string XmlConsulta, string Usuario, string Clave) {
            this.ObtenerComparacionesXmlAsync(XmlConsulta, Usuario, Clave, null);
        }
        
        /// <remarks/>
        public void ObtenerComparacionesXmlAsync(string XmlConsulta, string Usuario, string Clave, object userState) {
            if ((this.ObtenerComparacionesXmlOperationCompleted == null)) {
                this.ObtenerComparacionesXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerComparacionesXmlOperationCompleted);
            }
            this.InvokeAsync("ObtenerComparacionesXml", new object[] {
                        XmlConsulta,
                        Usuario,
                        Clave}, this.ObtenerComparacionesXmlOperationCompleted, userState);
        }
        
        private void OnObtenerComparacionesXmlOperationCompleted(object arg) {
            if ((this.ObtenerComparacionesXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerComparacionesXmlCompleted(this, new ObtenerComparacionesXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerClausulasCoincidentesXml", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerClausulasCoincidentesXml(string XmlConsulta, string Usuario, string Clave) {
            object[] results = this.Invoke("ObtenerClausulasCoincidentesXml", new object[] {
                        XmlConsulta,
                        Usuario,
                        Clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerClausulasCoincidentesXmlAsync(string XmlConsulta, string Usuario, string Clave) {
            this.ObtenerClausulasCoincidentesXmlAsync(XmlConsulta, Usuario, Clave, null);
        }
        
        /// <remarks/>
        public void ObtenerClausulasCoincidentesXmlAsync(string XmlConsulta, string Usuario, string Clave, object userState) {
            if ((this.ObtenerClausulasCoincidentesXmlOperationCompleted == null)) {
                this.ObtenerClausulasCoincidentesXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerClausulasCoincidentesXmlOperationCompleted);
            }
            this.InvokeAsync("ObtenerClausulasCoincidentesXml", new object[] {
                        XmlConsulta,
                        Usuario,
                        Clave}, this.ObtenerClausulasCoincidentesXmlOperationCompleted, userState);
        }
        
        private void OnObtenerClausulasCoincidentesXmlOperationCompleted(object arg) {
            if ((this.ObtenerClausulasCoincidentesXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerClausulasCoincidentesXmlCompleted(this, new ObtenerClausulasCoincidentesXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void ObtenerCondicionesXmlCompletedEventHandler(object sender, ObtenerCondicionesXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerCondicionesXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerCondicionesXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void ObtenerDocumentosProductoXmlCompletedEventHandler(object sender, ObtenerDocumentosProductoXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerDocumentosProductoXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerDocumentosProductoXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void ObtenerDocumentosPaisXmlCompletedEventHandler(object sender, ObtenerDocumentosPaisXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerDocumentosPaisXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerDocumentosPaisXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void ObtenerComparacionesXmlCompletedEventHandler(object sender, ObtenerComparacionesXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerComparacionesXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerComparacionesXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void ObtenerClausulasCoincidentesXmlCompletedEventHandler(object sender, ObtenerClausulasCoincidentesXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerClausulasCoincidentesXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerClausulasCoincidentesXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591