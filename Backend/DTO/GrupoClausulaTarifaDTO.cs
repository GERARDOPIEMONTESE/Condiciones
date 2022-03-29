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
    public class GrupoClausulaTarifaDTO : ObjetoPersistido
    {
        private const string NOMBRE = "GrupoClausula";

        public string NombreTipoGrupoClausula {get; set;}
        public string NombreLocacion{get; set;}
        public string NombreTextoResumen{get; set;}
        public string Producto {get; set;}
        public string Tarifa {get; set;}
        public string Sufijo {get; set;}
        public bool Anual {get; set;}
        public string TipoModalidad {get; set;}
        public string EsAnual
        {
            get
            {
                return Anual ? "Si" : "No";
            }
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }

}
