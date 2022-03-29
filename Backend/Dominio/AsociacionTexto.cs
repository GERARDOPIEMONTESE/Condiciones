using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;
using Backend.Interfaces;

namespace Backend.Dominio
{
    public class AsociacionTexto : ObjetoNegocio, ICopiable<AsociacionTexto>
    {
        private const string NOMBRE = "GrupoClausula_R_Texto";


        #region Propiedades

        public int IdGrupoClausula { get; set; }
        public int IdTexto {get; set;}
        public int IdTipoTexto {get; set;}
        public int IdTipoPlan {get; set;}
        

        #endregion

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOAsociacionTexto.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #region ICopiable<AsociacionTexto> Members

        public AsociacionTexto Copiar()
        {
            AsociacionTexto Copia = new AsociacionTexto();

            Copia.IdGrupoClausula = this.IdGrupoClausula;
            Copia.IdTexto = this.IdTexto;
            Copia.IdTipoTexto = this.IdTipoTexto;
            Copia.IdTipoPlan = this.IdTipoPlan;

            return Copia;
        }

        #endregion
    }
}
