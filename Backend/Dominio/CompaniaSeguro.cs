using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class CompaniaSeguro:ObjetoNegocio
    {
        private const string NOMBRE = "CompaniaSeguro";

        #region Propiedades

        public string Descripcion { get; set; }
  
        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOCompaniaSeguro.Instancia();
        }
    }
}
