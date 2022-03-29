using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;
using Backend.Interfaces;

namespace Backend.Dominio
{
    public class ObjetoAgrupadorClausula : ObjetoNegocio, ICopiable<ObjetoAgrupadorClausula>
    {
        private const string NOMBRE = "ObjetoAgrupadorClausula";

        #region Propiedades

        public int IdLocacion {get; set;}
        public int IdObjetoAgrupador {get; set;}
        public TipoGrupoClausula TipoGrupoClausula {get; set;}
        public int IdGrupoClausula  {get; set;}
 
        #endregion

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOObjetoAgrupadorClausula.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #region ICopiable<ObjetoAgrupadorClausula> Members

        public ObjetoAgrupadorClausula Copiar()
        {
            ObjetoAgrupadorClausula Copia = new ObjetoAgrupadorClausula();

            Copia.IdLocacion = IdLocacion;
            Copia.IdObjetoAgrupador = IdObjetoAgrupador;
            Copia.TipoGrupoClausula = TipoGrupoClausula;

            return Copia;
        }

        #endregion
    }
}
