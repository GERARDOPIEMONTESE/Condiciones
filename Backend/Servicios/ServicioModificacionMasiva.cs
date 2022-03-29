using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Homes;
using Backend.Contextos;
using Backend.Datos;
using Backend.DTO;

namespace Backend.Servicios
{
    public class ServicioModificacionMasiva
    {
        public static void AsociarTextoResumen(ContextoModificacionMasiva Contexto)
        {
            foreach (TextoResumenDTO TextoDto in Contexto.TextosResumen)
            {
                Texto Texto = TextoHome.Obtener(TextoDto.IdTextoResumen);

                foreach (int IdGrupoClausula in Contexto.IdsGrupoClausula)
                {
                    GrupoClausula Grupo = GrupoClausulaHome.Obtener(IdGrupoClausula);

                    AsociacionTexto Asociacion = new AsociacionTexto();
                    Asociacion.IdTexto = Texto.Id;
                    Asociacion.IdTipoTexto = Texto.TipoTexto.Id;
                    //ver que esto debe ser seleccionado por el usuario.
                    Asociacion.IdTipoPlan = TipoPlanHome.Obtener(TextoDto.IdTipoPlan).Id;

                    Grupo.Textos.Add(Asociacion);

                    Grupo.Modificar();
                }
            }
        }

        public static void ModificarDocumentos(ContextoModificacionMasiva Contexto)
        {
            foreach (int IdGrupoClausula in Contexto.IdsGrupoClausula)
            {
                GrupoClausula Grupo = GrupoClausulaHome.Obtener(IdGrupoClausula);

                foreach (ContextoModificacionDocumento Documento in Contexto.Documentos)
                {
                    Grupo.Modificar(Documento.IdTipoDocumento, Documento.IdDocumento);
                }
            }
        }

        public static void ModificarCondicion(ContextoModificacionMasiva Contexto)
        {
            foreach (int IdGrupoClausula in Contexto.IdsGrupoClausula)
            {
                foreach (int IdClausula in Contexto.IdsClausula)
                {
                    foreach (ContextoModificacionRango Rango in Contexto.Rangos)
                    {
                        DAOContenidoClausulaRango.Instancia().Modificar(
                            Rango, IdGrupoClausula, IdClausula, Rango.Contenido);
                        DAOContenidoClausulaRango.Instancia().Modificar(
                            Rango, IdGrupoClausula, IdClausula, Rango.Leyendas);
                    }
                }
            }
        }

        public static void EliminarCondicion(ContextoModificacionMasiva Contexto)
        {
            foreach (int IdGrupoClausula in Contexto.IdsGrupoClausula)
            {
                foreach (int IdClausula in Contexto.IdsClausula)
                {
                    ContenidoClausula ContenidoClausula = DAOContenidoClausula.Instancia().Obtener(
                         IdGrupoClausula, IdClausula);

                    if (ContenidoClausula != null && ContenidoClausula.Id != 0)
                    {
                        ContenidoClausula.Eliminar();
                    }
                }
            }
        }

        private static ContenidoClausulaRango ObtenerContenido(ContextoModificacionRango Contexto)
        {
            ContenidoClausulaRango Rango = new ContenidoClausulaRango();

            Rango.EdadMinima = Contexto.EdadMinima;
            Rango.EdadMaxima = Contexto.EdadMaxima;
            Rango.TipoPlan = TipoPlanHome.Obtener(Contexto.IdTipoPlan);
            Rango.TipoModalidad = TipoModalidadHome.Obtener(Contexto.IdTipoModalidad);
            Rango.Categoria = Contexto.Categoria;
            Rango.Contenido = Contexto.Contenido;
            Rango.ValidezTerritorialClausula = ValidezTerritorialClausulaHome.Obtener(
                Contexto.IdValidezTerritorialClausula);
            Rango.ValidezTerritorial = ValidezTerritorialHome.Obtener(
                Contexto.IdValidezTerritorial);
            //Rango.TipoDestino = TipoDestinoHome.Obtener(Contexto.IdTipoDestino);
            Rango.Leyendas = Contexto.Leyendas;

            return Rango;
        }

        private static ContenidoClausula ObtenerContenido(ContextoModificacionMasiva Contexto, int IdClausula)
        {
            ContenidoClausula ContenidoClausula = new ContenidoClausula();

            ContenidoClausula.IdClausula = IdClausula;
            ContenidoClausula.TipoImpresionClausula = TipoImpresionClausulaHome.Obtener(
                Contexto.IdTipoImpresionClausula);
            ContenidoClausula.TipoContenidoImpresion = TipoContenidoImpresionHome.Obtener(
                Contexto.IdTipoContenidoClausula);
            ContenidoClausula.EvaluableEnAsistencia = Contexto.EvaluableEnAsistencia;
            ContenidoClausula.VisibleEnAsistencia = Contexto.VisibleEnAsistencia;
            ContenidoClausula.Orden = Contexto.Orden;
            ContenidoClausula.TipoCobertura = TipoCoberturaHome.Obtener(
                Contexto.IdTipoCobertura);

            foreach (ContextoModificacionRango ContextoRango in Contexto.Rangos)
            {
                ContenidoClausula.Contenidos.Add(ObtenerContenido(ContextoRango));
            }

            return ContenidoClausula;
        }

        private static void ModificarANoPersistido(ContenidoClausula Contenido)
        {
            Contenido.Id = 0;
            Contenido.Padres.Clear();

            foreach (ContenidoClausulaRango Rango in Contenido.Contenidos)
            {
                Rango.Id = 0;
                foreach (Leyenda Leyenda in Rango.Leyendas)
                {
                    Leyenda.Id = 0;
                }
            }
        }

        private static ContenidoClausula ObtenerPadre(IList<ContenidoClausula> Contenidos, int IdClausula)
        {
            foreach (ContenidoClausula Contenido in Contenidos)
            {
                if (Contenido.Clausula.Id == IdClausula)
                {
                    return Contenido;
                }
            }
            return null;
        }

        private static void SetearPadres(ContenidoClausula Contenido,
            ContextoModificacionMasiva Contexto, int IdGrupoClausula)
        {
            GrupoClausula GrupoClausula = GrupoClausulaHome.Obtener(IdGrupoClausula);

            foreach(int IdClausula in Contexto.IdsPadre) 
            {
                ContenidoClausula Padre = ObtenerPadre(
                    GrupoClausula.Contenidos, IdClausula);

                if (Padre != null)
                {
                    Contenido.Padres.Add(new AsociacionContenidoClausula(Padre));
                }
            }            
        }

        public static void AgregarCondicion(ContextoModificacionMasiva Contexto)
        {
            foreach (int IdClausula in Contexto.IdsClausula)
            {
                ContenidoClausula ContenidoClausula = ObtenerContenido(Contexto, IdClausula);

                foreach (int IdGrupoClausula in Contexto.IdsGrupoClausula)
                {
                    ModificarANoPersistido(ContenidoClausula);
                    ContenidoClausula.IdGrupoClausula = IdGrupoClausula;

                    SetearPadres(ContenidoClausula, Contexto, IdGrupoClausula);

                    ContenidoClausula.Persistir();                    
                }
            }
        }


    }
}
