using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using CapaNegocioDatos.CapaNegocio;

namespace Backend.DTO
{
    public class GrupoClausulaDTO
    {
        
        #region Propiedades

        public int IdGrupoClausula {get;set;}
        public TipoGrupoClausula TipoGrupoClausula {get;set;}
        public int CodigoPais {get;set;}
        public Producto Producto {get;set;}
        public IList<Tarifa> Tarifas {get;set;}
        public IList<Sucursal> Sucursales { get; set; }
        public bool Anual {get; set;}
        public int DiasConsecutivos  {get; set;}
        public IDictionary<string, ClausulaDTO> Clausulas  {get; set;}
        public IList<AdjuntoDTO> Adjuntos {get; set;}
        public IList<AsociacionTexto> Textos {get; set;}
        public int IdUsuario {get; set;}
        
        

        #endregion

        public ClausulaDTO Obtener(string Codigo)
        {
            if (Clausulas.Keys.Contains(Codigo.Trim()))
            {
                return Clausulas[Codigo.Trim()];
            }

            return new ClausulaDTO();
        }

        public bool ContieneClausula(string Codigo)
        {
            return Clausulas.Keys.Contains(Codigo.Trim());
        }
    }
}
