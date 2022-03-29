using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;


namespace Backend.Dominio
{
    public class TipoOperacion : ObjetoNegocio
    {

        #region Constantes

        private const string NOMBRE = "TipoOperacion";

        #endregion

        public string Nombre { get; set; }
        public string Descripcion { get; set; }


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
    }
}
