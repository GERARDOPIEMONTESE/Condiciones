using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using Backend.Dominio;
using Backend.Datos;
using Backend.Homes;
using CapaNegocioDatos.CapaNegocio;

namespace Backend.Servicios
{
    public class ServicioGrupoClausula
    {
        private static string ObtenerKey(Backend.DTO.GrupoClausulaDTO GrupoClausulaDTO, string IdentificacionPadre)
        {
            foreach (string Key in GrupoClausulaDTO.Clausulas.Keys)
            {
                if (Key.Split(' ')[0].Equals(IdentificacionPadre.Split(' ')[0]))
                {
                    return Key;
                }
            }
            return "";
        }
        
        private static void GenerarGrupo (GrupoClausula Grupo, Backend.DTO.GrupoClausulaDTO GrupoClausulaDTO)
        {
            Grupo.TipoGrupoClausula = GrupoClausulaDTO.TipoGrupoClausula;
            Grupo.Anual = GrupoClausulaDTO.Anual;
            Grupo.DiasConsecutivos = GrupoClausulaDTO.DiasConsecutivos;

            Grupo.IdLocacion = DAOPais.Instancia().ObtenerPorCodigo(GrupoClausulaDTO.CodigoPais).IdLocacion;

            Grupo.Textos = GrupoClausulaDTO.Textos;
            Grupo.IdUsuario = GrupoClausulaDTO.IdUsuario;
        
            //Asociacion de objetos
            Grupo.Objetos.Clear();
            if (GrupoClausulaDTO.Tarifas != null)
            {
                foreach (Tarifa Tarifa in GrupoClausulaDTO.Tarifas)
                {
                    ObjetoAgrupadorClausula Objeto = new ObjetoAgrupadorClausula();

                    Objeto.IdLocacion = Grupo.IdLocacion;
                    Objeto.IdObjetoAgrupador = Tarifa.Id;
                    Objeto.TipoGrupoClausula = Grupo.TipoGrupoClausula;

                    Grupo.Objetos.Add(Objeto);
                }
            }
            else if (GrupoClausulaDTO.Sucursales != null)
            {
                foreach (Sucursal Sucursal in GrupoClausulaDTO.Sucursales)
                {
                    ObjetoAgrupadorClausula Objeto = new ObjetoAgrupadorClausula();

                    Objeto.IdLocacion = Grupo.IdLocacion;
                    Objeto.IdObjetoAgrupador = Sucursal.Id;
                    Objeto.TipoGrupoClausula = Grupo.TipoGrupoClausula;

                    Grupo.Objetos.Add(Objeto);
                }
            }

            //Clausulas
            Grupo.Contenidos.Clear();
            foreach (Backend.DTO.ClausulaDTO ClausulaDTO in GrupoClausulaDTO.Clausulas.Values)
            {
                ContenidoClausula Contenido = new ContenidoClausula();

                Contenido.TipoCobertura = ClausulaDTO.TipoCobertura;
                
                Contenido.IdClausula = ClausulaDTO.IdClausula;
                Contenido.TipoImpresionClausula = TipoImpresionClausulaHome.Obtener(
                    ClausulaDTO.IdTipoImpresionClausula);
                Contenido.TipoContenidoImpresion = TipoContenidoImpresionHome.Obtener(
                    ClausulaDTO.IdTipoContenidoImpresion);
                Contenido.EvaluableEnAsistencia = ClausulaDTO.EvaluableEnAsistencia;
                Contenido.VisibleEnAsistencia = ClausulaDTO.VisibleEnAsistencia;
                Contenido.Orden = ClausulaDTO.Orden;

                foreach (string IdentificacionPadre in ClausulaDTO.TextosIdentificatorioPadre)
                {
                    string Key = ObtenerKey(GrupoClausulaDTO, IdentificacionPadre);
                    if (Key.Length > 0)
                    {
                        Backend.DTO.ClausulaDTO Padre = GrupoClausulaDTO.Clausulas[Key];
                        
                        Contenido.Padres.Add(new AsociacionContenidoClausula(
                            Padre.ContenidoClausula));
                    }
                }

                foreach (ContenidoRangoDTO RangoDTO in ClausulaDTO.Contenidos)
                {
                    ContenidoClausulaRango Rango = new ContenidoClausulaRango();

                    Rango.EdadMinima = RangoDTO.EdadMinima;
                    Rango.EdadMaxima = RangoDTO.EdadMaxima;
                    Rango.TipoPlan = DAOTipoPlan.Instancia().Obtener(RangoDTO.IdTipoPlan);
                    Rango.TipoModalidad = DAOTipoModalidad.Instancia().Obtener(
                        RangoDTO.IdTipoModalidad);
                    Rango.Categoria = RangoDTO.Categoria;
                    Rango.Contenido = RangoDTO.Contenido;
                    Rango.ValidezTerritorialClausula = ValidezTerritorialClausulaHome.
                        Obtener(RangoDTO.IdValidezTerritorialClausula);
                    Rango.ValidezTerritorial = ValidezTerritorialHome.Obtener(
                        RangoDTO.IdValidezTerritorial);
                    Rango.Peso = RangoDTO.Peso;
                    
                    Rango.Leyendas = RangoDTO.Leyendas;

                    Contenido.Contenidos.Add(Rango);
                }

                Grupo.Contenidos.Add(Contenido);
                ClausulaDTO.ContenidoClausula = Contenido;
            }

            //Documentos
            Grupo.Documentos.Clear();
            foreach (AdjuntoDTO Adjunto in GrupoClausulaDTO.Adjuntos)
            {
                AsociacionDocumento AsociacionDocumento = new AsociacionDocumento();
                AsociacionDocumento.TipoAsociacionDocumento = 
                    TipoAsociacionDocumentoHome.Grupo();
                AsociacionDocumento.Documento = DocumentoHome.Obtener(Adjunto.IdDocumento);

                Grupo.Documentos.Add(AsociacionDocumento);
            }

            Grupo.Textos = GrupoClausulaDTO.Textos;

            try
            {
                Grupo.Persistir();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void Editar(Backend.DTO.GrupoClausulaDTO GrupoClausulaDTO)
        {
            GenerarGrupo(DAOGrupoClausula.Instancia().
                Obtener(GrupoClausulaDTO.IdGrupoClausula), GrupoClausulaDTO);
        }

        public static void Editar(GrupoClausula GrupoClausula, IList<Tarifa> Tarifas)
        {
            GrupoClausula.Objetos.Clear();
            foreach (Tarifa Tarifa in Tarifas)
            {
                ObjetoAgrupadorClausula Objeto = new ObjetoAgrupadorClausula();

                Objeto.IdLocacion = GrupoClausula.IdLocacion;
                Objeto.IdObjetoAgrupador = Tarifa.Id;
                Objeto.TipoGrupoClausula = GrupoClausula.TipoGrupoClausula;

                GrupoClausula.Objetos.Add(Objeto);
            }

            GrupoClausula.Persistir();
        }

        public static void Crear(Backend.DTO.GrupoClausulaDTO GrupoClausulaDTO)
        {
            GenerarGrupo(new GrupoClausula(), GrupoClausulaDTO);
        }
    }
}
