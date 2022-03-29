using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;
using Backend.Interfaces;

namespace Backend.Dominio
{
    public class AsociacionContenidoClausula : ObjetoNegocio, ICopiable<AsociacionContenidoClausula>
    {
        private const string NOMBRE = "AsociacionContenidoClausula";

        #region Constructores

        public AsociacionContenidoClausula()
        {
        }

        public AsociacionContenidoClausula(ContenidoClausula pContenidoClausulaPadre)
        {
            this.ContenidoClausulaPadre = pContenidoClausulaPadre;
            this.IdContenidoClausulaPadre = pContenidoClausulaPadre.Id;
            this.CodigoClausulaPadre = pContenidoClausulaPadre.Clausula.Codigo;
        }

        #endregion

        #region Propiedades

        public ContenidoClausula ContenidoClausulaPadre {get; set;}
        public int IdClausulaPadre {get; set;}
        public int IdContenidoClausulaPadre {get; set;}
        public string CodigoClausulaPadre  {get; set;}
        public int IdContenidoClausulaHijo {get; set;}
        
        #endregion

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOAsociacionContenidoClausula.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #region ICopiable<AsociacionContenidoClausula> Members

        public AsociacionContenidoClausula Copiar()
        {
            AsociacionContenidoClausula Copia = new AsociacionContenidoClausula();

            return Copia;
        }

        #endregion
    }
}
