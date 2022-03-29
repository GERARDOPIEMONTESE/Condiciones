using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Backend.Datos;
using FrameworkDAC.Negocio;
using Backend.Interfaces;

namespace Backend.Dominio
{
    public class Documento : ObjetoNegocio, ICopiable<Documento>
    {
        #region Constantes

        private const string NOMBRE = "Documento";

        #endregion

        #region Propiedades

        public TipoDocumento TipoDocumento {get; set;}
        public string Nombre {get; set;}
        public byte[] DocumentoContenido {get; set;}
        public Int64 DocumentoDimension {get; set;}
        public string DocumentoTipoContenido {get; set;}
        public Guid CodigoValidacion {get; set;}
        public string Observaciones {get; set;}
        public Idioma Idioma {get; set;}
        
        #endregion

        #region Metodos Redefinidos

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAODocumento.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion

        #region ICopiable<Documento> Members

        public Documento Copiar()
        {
            Documento Copia = new Documento();

            Copia.TipoDocumento = TipoDocumento;
            Copia.Nombre = Nombre;
            Copia.DocumentoContenido = DocumentoContenido;
            Copia.DocumentoDimension = DocumentoDimension;
            Copia.DocumentoTipoContenido = DocumentoTipoContenido;
            Copia.CodigoValidacion = CodigoValidacion;
            Copia.Idioma = Idioma;

            return Copia;
        }

        #endregion
    }

    
}
