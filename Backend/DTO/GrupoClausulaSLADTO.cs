using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using Backend.Dominio;

namespace Backend.DTO
{
    public class GrupoClausulaSLADTO : ObjetoPersistido
    {
        private const string NOMBRE = "GrupoClausula";

        public string NombreLocacion{get; set;}
        public string Agencia {get; set;}
        public string Sucursal {get; set;}

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }

}
