using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;
using Backend.Interfaces;

namespace Backend.Dominio
{
    public class AsociacionDocumento : ObjetoNegocio, ICopiable<AsociacionDocumento>
    {
        private const string NOMBRE = "AsociacionDocumento";


        #region Propiedades

        public int IdObjeto  {get; set;}
        public Documento Documento {get; set;}
        public TipoAsociacionDocumento TipoAsociacionDocumento {get; set;}
        
        #endregion

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOAsociacionDocumento.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #region ICopiable<AsociacionDocumento> Members

        public AsociacionDocumento Copiar()
        {
            AsociacionDocumento Copia = new AsociacionDocumento();

            Copia.IdObjeto = IdObjeto;
            Copia.TipoAsociacionDocumento = TipoAsociacionDocumento;
            Copia.Documento = Documento;

            return Copia;
        }

        #endregion
    }
}
