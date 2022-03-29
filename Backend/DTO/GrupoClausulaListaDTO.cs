using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Homes;
using Backend.Datos;

namespace Backend.DTO
{
    public class GrupoClausulaListaDTO
    {
        #region Propiedades

        public GrupoClausula Grupo {get; set;}
        public IList<TarifaDTO> Tarifas{get; set;}
        public int Id
        {
            get
            {
                return Grupo.Id;
            }
        }
        public string NombreTipoGrupoClausula
        {
            get
            {
                return Grupo.NombreTipoGrupoClausula;
            }
        }
        public string NombreLocacion
        {
            get
            {
                return Grupo.NombreLocacion;
            }
        }
        public string NombreTextoResumen
        {
            get
            {
                return Grupo.NombreTextoResumen == null || 
                    Grupo.NombreTextoResumen.Length == 0 ? "-" : Grupo.NombreTextoResumen;
            }
        }

        public string Producto
        {
            get
            {
                if (Tarifas != null && Tarifas.Count > 0)
                {
                    Producto Producto = ProductoHome.Obtener(Tarifas[0].Tarifa.IdProducto);

                    return Producto.Nombre + " (" + Producto.Codigo + ")";
                }

                return "-";
            }
        }

        #endregion

        public GrupoClausulaListaDTO(GrupoClausula pGrupo)
        {
            Grupo = pGrupo;
            
            Grupo.Objetos = DAOObjetoAgrupadorClausula.Instancia().Buscar(Grupo.Id);
            foreach (ObjetoAgrupadorClausula Objeto in Grupo.Objetos)
            {
                Tarifas.Add(new TarifaDTO(
                    TarifaHome.Obtener(Objeto.IdObjetoAgrupador)));
            }            
        }
    }
}
