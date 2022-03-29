using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Interfaces;
using Backend.Datos;

namespace Backend.Dominio
{
    public class Leyenda : ObjetoNegocio, ICopiable<Leyenda>
    {
        private const string NOMBRE = "Leyenda";

        #region Propiedades

        public int IdContenidoClausulaRango {get; set;}
        public int IdIdioma {get; set;}
        public string Texto {get; set;}
       
        #endregion

        public Leyenda()
        {
        }

        public Leyenda(int pIdIdioma, string pTexto)
        {
            IdIdioma = pIdIdioma;
            Texto = pTexto;
        }

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOLeyenda.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #region ICopiable<Leyenda> Members

        public Leyenda Copiar()
        {
            Leyenda Copia = new Leyenda();

            Copia.IdIdioma = IdIdioma;
            Copia.Texto = Texto;

            return Copia;
        }

        #endregion
    }
}
