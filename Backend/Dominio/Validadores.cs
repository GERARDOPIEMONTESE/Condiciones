using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Interfaces;
using Backend.Datos;

namespace Backend.Dominio
{
    public class Validadores : ObjetoNegocio
    {
        private const string NOMBRE = "Validadores";

        public string Codigo { get; set; }
        public string TipoDato { get; set; }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOValidadores.Instancia();
        }
    }
}
