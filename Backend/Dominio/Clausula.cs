using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class Clausula : ObjetoNegocio
    {
        #region Constantes

        private const string NOMBRE = "Clausula";

        public const string CLAUSULA_VALIDEZ_TERRITORIAL = "C.5.2.1";

        #endregion

        #region Propiedades

        public TipoClausula TipoClausula {get; set;}
        public string Codigo{get; set;}
        public IList<Clausula_Idioma> Clausula_Idioma {get; set;}
        public int OrdenPredefinido{get; set;}
        public decimal? Peso { get; set; }
        public decimal? Tasa { get; set; }

        #endregion

        #region Metodos Redefinidos

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOClausula.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion

        public string ObtenerTitulo(int IdIdioma)
        {
            if (Clausula_Idioma == null || Clausula_Idioma.Count == 0)
            {
                return "";
            }
            foreach (Clausula_Idioma Idioma in Clausula_Idioma)
            {
                if (Idioma.IdIdioma == IdIdioma)
                {
                    return Idioma.Texto;
                }
            }

            return Clausula_Idioma != null && Clausula_Idioma.Count > 0 ? Clausula_Idioma[0].Texto : "";
        }
    }

    




}
