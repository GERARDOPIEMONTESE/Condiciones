﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Condiciones.ServicioTarifaLocal {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TarifaWS", Namespace="http://schemas.datacontract.org/2004/07/ServicioConsultaClausulas")]
    [System.SerializableAttribute()]
    public partial class TarifaWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActivaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AnualField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoPaisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoTarifaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTipoGrupoClausulaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Condiciones.ServicioTarifaLocal.ProductoWS ProductoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SufijoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Activa {
            get {
                return this.ActivaField;
            }
            set {
                if ((this.ActivaField.Equals(value) != true)) {
                    this.ActivaField = value;
                    this.RaisePropertyChanged("Activa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Anual {
            get {
                return this.AnualField;
            }
            set {
                if ((this.AnualField.Equals(value) != true)) {
                    this.AnualField = value;
                    this.RaisePropertyChanged("Anual");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CodigoPais {
            get {
                return this.CodigoPaisField;
            }
            set {
                if ((this.CodigoPaisField.Equals(value) != true)) {
                    this.CodigoPaisField = value;
                    this.RaisePropertyChanged("CodigoPais");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoTarifa {
            get {
                return this.CodigoTarifaField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoTarifaField, value) != true)) {
                    this.CodigoTarifaField = value;
                    this.RaisePropertyChanged("CodigoTarifa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTipoGrupoClausula {
            get {
                return this.IdTipoGrupoClausulaField;
            }
            set {
                if ((this.IdTipoGrupoClausulaField.Equals(value) != true)) {
                    this.IdTipoGrupoClausulaField = value;
                    this.RaisePropertyChanged("IdTipoGrupoClausula");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Condiciones.ServicioTarifaLocal.ProductoWS Producto {
            get {
                return this.ProductoField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductoField, value) != true)) {
                    this.ProductoField = value;
                    this.RaisePropertyChanged("Producto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sufijo {
            get {
                return this.SufijoField;
            }
            set {
                if ((object.ReferenceEquals(this.SufijoField, value) != true)) {
                    this.SufijoField = value;
                    this.RaisePropertyChanged("Sufijo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductoWS", Namespace="http://schemas.datacontract.org/2004/07/ServicioConsultaClausulas")]
    [System.SerializableAttribute()]
    public partial class ProductoWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoProductoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoProducto {
            get {
                return this.CodigoProductoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoProductoField, value) != true)) {
                    this.CodigoProductoField = value;
                    this.RaisePropertyChanged("CodigoProducto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioTarifaLocal.IServicioTarifa")]
    public interface IServicioTarifa {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTarifa/AgregarTarifa", ReplyAction="http://tempuri.org/IServicioTarifa/AgregarTarifaResponse")]
        void AgregarTarifa(Condiciones.ServicioTarifaLocal.TarifaWS TarifaWS);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IServicioTarifaChannel : Condiciones.ServicioTarifaLocal.IServicioTarifa, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ServicioTarifaClient : System.ServiceModel.ClientBase<Condiciones.ServicioTarifaLocal.IServicioTarifa>, Condiciones.ServicioTarifaLocal.IServicioTarifa {
        
        public ServicioTarifaClient() {
        }
        
        public ServicioTarifaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioTarifaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioTarifaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioTarifaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AgregarTarifa(Condiciones.ServicioTarifaLocal.TarifaWS TarifaWS) {
            base.Channel.AgregarTarifa(TarifaWS);
        }
    }
}