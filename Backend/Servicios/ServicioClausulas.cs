using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Homes;
using Backend.Contextos;
using CondicionesParser.Parser;
using BackendCondiciones.Properties;

namespace Backend.Servicios
{
    public class ServicioClausulas : IServicioClausulas
    {
        #region Singleton

        private static ServicioClausulas _Instancia;

        private ServicioClausulas()
        {
        }

        public static ServicioClausulas Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioClausulas();
            }
            return _Instancia;
        }

        #endregion

        #region ICondicionesService Members

        public ContextoGrupoPorRango CrearContextoConsulta(ConsultaCondicionesDTO Consulta)
        {
            ContextoGrupoPorRango Contexto = new ContextoGrupoPorRango();

            Contexto.CodigoPais = Consulta.CodigoPais;
            Contexto.CodigoProducto = Consulta.CodigoProducto;
            Contexto.CodigoTarifa = Consulta.CodigoTarifa;
            Contexto.Anual = Consulta.Anual;
            Contexto.Edad = Consulta.Edad;
            Contexto.IdTipoPlan = Consulta.IdTipoPlan;
            Contexto.IdTipoModalidad = Consulta.IdTipoModalidad;
            //Contexto.Categoria = Consulta.Categoria;

            return Contexto;
        }

        public ContextoGrupoPorRango CrearContextoConsulta(ConsultaCondicionesDTO Consulta,
            ConsultaCondicionesUpgradeDTO ConsultaUpgrade)
        {
            ContextoGrupoPorRango Contexto = new ContextoGrupoPorRango();

            Contexto.CodigoPais = Consulta.CodigoPais;
            Contexto.CodigoProducto = ConsultaUpgrade.CodigoUpgrade;
            Contexto.CodigoTarifa = ConsultaUpgrade.CodigoTarifa;
            Contexto.Anual = Consulta.Anual;
            Contexto.Edad = Consulta.Edad;
            Contexto.IdTipoPlan = Consulta.IdTipoPlan;
            Contexto.IdTipoModalidad = Consulta.IdTipoModalidad;
            Contexto.Categoria = ConsultaUpgrade.Categoria;

            return Contexto;
        }

        /**
         * Este metodo hay que quitarlo cuando en AC-Net y AC-Com
         * se implemente la evaluacion de tipo impresion de cada clausula
         */
        //private string ObtenerCodigo(Clausula Clausula, ContenidoClausula Contenido)
        //{
        //    return TipoContenidoImpresion.CONTENIDO.Equals(Contenido.TipoContenidoImpresion.Codigo) ||
        //        TipoContenidoImpresion.DESC_CONT.Equals(Contenido.TipoContenidoImpresion.Codigo) ||
        //        TipoClausula.GENERAL_EKIT.Equals(Clausula.TipoClausula.Codigo) ||
        //        TipoClausula.GENERAL_NO_EKIT.Equals(Clausula.TipoClausula.Codigo)
        //        ? "" : Clausula.Codigo;
        //}

        private void CrearClausulaDTO(ContenidoClausula Contenido, ContenidoClausulaDTO ContenidoDTO)
        {
            ClausulaDTO ClausulaDTO = new ClausulaDTO();

            ClausulaDTO.CodigoTipoClausula = Contenido.Clausula.TipoClausula.Codigo;
            ClausulaDTO.NombreTipoClausula = Contenido.Clausula.TipoClausula.Nombre;
            //ClausulaDTO.Codigo = Contenido.Clausula.Codigo;
            ClausulaDTO.Codigo = Contenido.Clausula.Codigo;//ObtenerCodigo(Contenido.Clausula, Contenido);

            ClausulaDTO.ClausulaIdioma = new ClausulaIdiomaDTO[
                Contenido.Clausula.Clausula_Idioma.Count];

            int I = 0;
            foreach (Clausula_Idioma Idioma in Contenido.Clausula.Clausula_Idioma)
            {
                ClausulaIdiomaDTO IdiomaDTO = new ClausulaIdiomaDTO();

                //IdiomaDTO.Texto = "<![CDATA[" + Idioma.Texto + "]]>";
                IdiomaDTO.Texto = Idioma.Texto;
                IdiomaDTO.IdIdioma = Idioma.IdIdioma;

                ClausulaDTO.ClausulaIdioma[I] = IdiomaDTO;
                I++;
            }

            ContenidoDTO.Clausula = ClausulaDTO;
        }

        private void CrearContenidoRangoDTO(ContenidoClausula Contenido, ContenidoClausulaDTO ContenidoDTO)
        {
            int I = 0;
            ContenidoDTO.Rangos = new ContenidoClausulaRangoDTO[Contenido.Contenidos.Count];

            foreach (ContenidoClausulaRango Rango in Contenido.Contenidos)
            {
                ContenidoClausulaRangoDTO RangoDTO = new ContenidoClausulaRangoDTO();
                RangoDTO.EdadMinima = Rango.EdadMinima;
                RangoDTO.EdadMaxima = Rango.EdadMaxima;
                RangoDTO.TipoPlan = Rango.TipoPlan.Codigo;
                RangoDTO.TipoModalidad = Rango.TipoModalidad.Codigo;
                RangoDTO.Categoria = Rango.Categoria;
                RangoDTO.Contenido = Rango.Contenido;
                RangoDTO.IdValidezTerritorial = Rango.ValidezTerritorial != null ?
                    Rango.ValidezTerritorial.Id : 0;
                RangoDTO.IdValidezTerritorialClausula = Rango.ValidezTerritorialClausula != null ?
                    Rango.ValidezTerritorialClausula.Id : 0;
                RangoDTO.Leyendas = ObtenerLeyendas(Rango);

                ContenidoDTO.Rangos[I] = RangoDTO;
                I++;
            }
        }

        private void CrearPadresDTO(ContenidoClausula Contenido, ContenidoClausulaDTO ContenidoDTO)
        {
            ContenidoDTO.Padres = new ContenidoClausulaDTO[Contenido.Padres.Count];

            int I = 0;
            foreach (AsociacionContenidoClausula Padre in Contenido.Padres)
            {
                ContenidoDTO.Padres[I] = CrearContenidoDTO(Padre.CodigoClausulaPadre);
                I++;
            }
        }

        private LeyendaDTO[] ObtenerLeyendas(ContenidoClausulaRango Contenido)
        {
            LeyendaDTO[] LeyendasDTO = new LeyendaDTO[Contenido.Leyendas.Count];

            int I = 0;
            foreach (Leyenda Leyenda in Contenido.Leyendas)
            {
                LeyendasDTO[I] = new LeyendaDTO(Leyenda.IdIdioma, Leyenda.Texto);
                I++;
            }
            return LeyendasDTO;
        }

        private ContenidoClausulaDTO CrearContenidoDTO(ContenidoClausula Contenido)
        {
            ContenidoClausulaDTO ContenidoDTO = new ContenidoClausulaDTO();

            CrearClausulaDTO(Contenido, ContenidoDTO);

            ContenidoDTO.CodigoTipoImpresionClausula = Contenido.TipoImpresionClausula.Codigo;
            ContenidoDTO.CodigoTipoContenidoImpresion = Contenido.TipoContenidoImpresion.Codigo;
            ContenidoDTO.EvaluableEnAsistencia = Contenido.EvaluableEnAsistencia;
            ContenidoDTO.VisibleEnAsistencia = Contenido.VisibleEnAsistencia;
            ContenidoDTO.TipoCobertura = Contenido.TipoCobertura.Codigo;
            ContenidoDTO.CodigoTipoGrupo = Contenido.CodigoTipoGrupo;

            CrearContenidoRangoDTO(Contenido, ContenidoDTO);
            CrearPadresDTO(Contenido, ContenidoDTO);

            IDictionary<string, string> Parametros = LenguajeCondicionesParser.Instancia(
                Settings.Default.Ubicacion).ObtenerParametros(
                ObtenerCondicionesRango(Contenido));

            ContenidoDTO.CondicionesEvaluacion = new CondicionEvaluacion[Parametros.Keys.Count];

            int I = 0;
            foreach (string Key in Parametros.Keys)
            {
                ContenidoDTO.CondicionesEvaluacion[I] = new CondicionEvaluacion(Key, Parametros[Key]);
                I++;
            }

            return ContenidoDTO;
        }

        private ContenidoClausulaDTO CrearContenidoDTO(string CodigoClausula)
        {
            ContenidoClausulaDTO ContenidoDTO = new ContenidoClausulaDTO();

            ContenidoDTO.Clausula = new ClausulaDTO();

            ContenidoDTO.Clausula.Codigo = CodigoClausula;

            return ContenidoDTO;
        }


        private IList<string> ObtenerCondicionesRango(ContenidoClausula Contenido)
        {
            IList<string> CondicionesEvaluacion = new List<string>();

            foreach (ContenidoClausulaRango Rango in Contenido.Contenidos)
            {
                CondicionesEvaluacion.Add(Rango.Contenido);
            }

            return CondicionesEvaluacion;
        }

        private void CrearContenidosClausula(GrupoClausula Grupo, GrupoClausulaDTO GrupoDTO)
        {
            IList<ContenidoClausulaDTO> Clausulas = new List<ContenidoClausulaDTO>();

            //GrupoDTO.Clausulas = new ContenidoClausulaDTO[Grupo.Contenidos.Count];

            //            int I = 0;
            foreach (ContenidoClausula Contenido in Grupo.Contenidos)
            {
                if (Contenido.Contenidos != null && Contenido.Contenidos.Count > 0)
                {
                    Clausulas.Add(CrearContenidoDTO(Contenido));
                }
                //I++;
            }
            GrupoDTO.Clausulas = Clausulas.ToArray<ContenidoClausulaDTO>();
        }

        private void CrearTarifas(GrupoClausula Grupo, GrupoClausulaDTO GrupoDTO)
        {
            GrupoDTO.Tarifas = new TarifaDTO[Grupo.Objetos.Count];

            int I = 0;
            foreach (ObjetoAgrupadorClausula Objeto in Grupo.Objetos)
            {
                TarifaDTO TarifaDTO = new TarifaDTO();

                Tarifa Tarifa = TarifaHome.Obtener(Objeto.IdObjetoAgrupador);
                Producto Producto = ProductoHome.Obtener(Tarifa.IdProducto);

                TarifaDTO.CodigoPais = Tarifa.CodigoPais;
                TarifaDTO.CodigoProducto = Producto.Codigo;
                TarifaDTO.CodigoTarifa = Tarifa.Codigo;
                TarifaDTO.Sufijo = Tarifa.Sufijo;

                GrupoDTO.Tarifas[I] = TarifaDTO;

                I++;
            }
        }

        private DocumentoDTO ObtenerDocumentoDTO(AsociacionDocumento Documento)
        {
            DocumentoDTO DocumentoDTO = new DocumentoDTO();

            DocumentoDTO.IdTipoDocumento = Documento.Documento.TipoDocumento.Id;
            DocumentoDTO.Nombre = Documento.Documento.Nombre;
            DocumentoDTO.Observaciones = Documento.Documento.Observaciones;
            DocumentoDTO.IdDocumento = Documento.Documento.Id;
            DocumentoDTO.CodigoValidacion = Documento.Documento.CodigoValidacion.ToString();
            DocumentoDTO.DocumentoDimension = Documento.Documento.DocumentoDimension;
            DocumentoDTO.DocumentoTipoContenido = Documento.Documento.DocumentoTipoContenido;
            DocumentoDTO.IdIdioma = Documento.Documento.Idioma.Id;

            return DocumentoDTO;
        }

        private void CrearDocumentos(GrupoClausula Grupo, GrupoClausulaDTO GrupoDTO)
        {
            GrupoDTO.Documentos = new DocumentoDTO[Grupo.Documentos.Count];

            int I = 0;
            foreach (AsociacionDocumento Documento in Grupo.Documentos)
            {
                DocumentoDTO DocumentoDTO = ObtenerDocumentoDTO(Documento);

                GrupoDTO.Documentos[I] = DocumentoDTO;

                I++;
            }
        }

        private GrupoClausulaDTO CrearGrupoClausulaDTO(GrupoClausula Grupo)
        {
            GrupoClausulaDTO GrupoDTO = new GrupoClausulaDTO();
            GrupoDTO.IdLocacion = Grupo.IdLocacion;
            GrupoDTO.TipoGrupoClausula = Grupo.TipoGrupoClausula.Nombre;
            GrupoDTO.TipoTextoResumen = Grupo.Textos != null && Grupo.Textos.Count > 0 ?
                TextoHome.Obtener(Grupo.Textos[0].IdTexto).TipoTextoResumen.Codigo : "";
            GrupoDTO.Texto = Grupo.Textos != null && Grupo.Textos.Count > 0 ?
                TextoHome.Obtener(Grupo.Textos[0].IdTexto).ContenidoTexto : "";
            //GrupoDTO.Anual = Grupo.Anual;
            GrupoDTO.DiasConsecutivos = Grupo.DiasConsecutivos;

            CrearContenidosClausula(Grupo, GrupoDTO);
            CrearTarifas(Grupo, GrupoDTO);
            CrearDocumentos(Grupo, GrupoDTO);

            return GrupoDTO;
        }

        private bool ContieneDocumento(GrupoClausula Grupo, AsociacionDocumento Asociacion)
        {
            foreach (AsociacionDocumento Original in Grupo.Documentos)
            {
                if (Original.Documento.Id == Asociacion.Documento.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private void MergearClausulas(IList<GrupoClausula> Grupos, IList<GrupoClausula> GruposUpgrade)
        {
            foreach (GrupoClausula Grupo in Grupos)
            {
                foreach (GrupoClausula GrupoUpgrade in GruposUpgrade)
                {
                    Grupo.MergearClausulas(GrupoUpgrade);
                    foreach (AsociacionDocumento DocumentoUpgrade in GrupoUpgrade.Documentos)
                    {
                        if (!ContieneDocumento(Grupo, DocumentoUpgrade))
                        {
                            Grupo.Documentos.Add(DocumentoUpgrade);
                        }
                    }
                }
            }
        }

        private IList<GrupoClausula> ObtenerCondicionesUpgrade(ConsultaCondicionesDTO Consulta)
        {
            IList<GrupoClausula> GruposUpgrade = new List<GrupoClausula>();

            if (Consulta.Upgrades != null && Consulta.Upgrades.Length > 0)
            {
                foreach (ConsultaCondicionesUpgradeDTO ConsultaUpgrade in Consulta.Upgrades)
                {
                    IList<GrupoClausula> GruposObtenidos = GrupoClausulaHome.Buscar(
                        CrearContextoConsulta(Consulta, ConsultaUpgrade));
                    if (GruposObtenidos != null && GruposObtenidos.Count > 0)
                    {
                        GruposUpgrade.Add(GruposObtenidos[0]);
                    }
                }
            }

            foreach (GrupoClausula Grupo in GruposUpgrade)
            {
                foreach (ContenidoClausula Contenido in Grupo.Contenidos)
                {
                    Contenido.CodigoTipoGrupo = TipoGrupoClausulaHome.Upgrade().Nombre;
                }
            }

            return GruposUpgrade;
        }

        public GruposClausulaDTO ObtenerCondiciones(ConsultaCondicionesDTO Consulta, string Usuario, string Clave)
        {
            IList<GrupoClausula> Grupos = GrupoClausulaHome.Buscar(
                CrearContextoConsulta(Consulta));

            //Busqueda y merge de clausulas upgrades

            MergearClausulas(Grupos, ObtenerCondicionesUpgrade(Consulta));

            GruposClausulaDTO GruposDTO = new GruposClausulaDTO();

            GruposDTO.Grupos = new GrupoClausulaDTO[Grupos.Count];

            int I = 0;
            foreach (GrupoClausula Grupo in Grupos)
            {
                GruposDTO.Grupos[I] = CrearGrupoClausulaDTO(Grupo);
                I++;
            }

            if (Consulta.ConsultaPadre != null &&
                (GruposDTO.Grupos == null || GruposDTO.Grupos.Length == 0))
            {
                if (Consulta.Upgrades != null && Consulta.Upgrades.Length > 0)
                {
                    Consulta.ConsultaPadre.Upgrades = Consulta.Upgrades;
                }

                return ObtenerCondiciones(Consulta.ConsultaPadre, Usuario, Clave);
            }

            return GruposDTO;
        }

        public GruposClausulaDTO ObtenerCondicionesSimple(ConsultaCondicionesDTO Consulta, string Usuario, string Clave)
        {
            IList<GrupoClausula> Grupos = GrupoClausulaHome.BuscarSimple(
                CrearContextoConsulta(Consulta));

            //Busqueda y merge de clausulas upgrades

            MergearClausulas(Grupos, ObtenerCondicionesUpgrade(Consulta));

            GruposClausulaDTO GruposDTO = new GruposClausulaDTO();

            GruposDTO.Grupos = new GrupoClausulaDTO[Grupos.Count];

            int I = 0;
            foreach (GrupoClausula Grupo in Grupos)
            {
                GruposDTO.Grupos[I] = CrearGrupoClausulaDTO(Grupo);
                I++;
            }

            if (Consulta.ConsultaPadre != null &&
                (GruposDTO.Grupos == null || GruposDTO.Grupos.Length == 0))
            {
                if (Consulta.Upgrades != null && Consulta.Upgrades.Length > 0)
                {
                    Consulta.ConsultaPadre.Upgrades = Consulta.Upgrades;
                }

                return ObtenerCondicionesSimple(Consulta.ConsultaPadre, Usuario, Clave);
            }

            return GruposDTO;
        }

        public string ObtenerCondicionesXml(string XmlConsulta, string Usuario, string Clave)
        {
            try
            {
                ConsultaCondicionesDTO Consulta = (ConsultaCondicionesDTO)
                    ServicioConversionXml.Instancia().DeserializeObject(
                    XmlConsulta, Type.GetType("Backend.Servicios.ConsultaCondicionesDTO"));

                GruposClausulaDTO Grupos = ObtenerCondiciones(Consulta, Usuario, Clave);

                foreach (GrupoClausulaDTO Grupo in Grupos.Grupos)
                {
                    Grupo.Texto = "<![CDATA[" + Grupo.Texto + "]]>";
                }

                return ServicioConversionXml.Instancia().SerializeObject(Grupos);
            }
            catch (Exception e)
            {
                throw new Exception("**** MESSAGE: " + e.Message + "**** STACK: " + e.StackTrace, e);
            }
        }

        #endregion

        private DocumentosDTO ObtenerDocumentos(IList<AsociacionDocumento> Asociaciones)
        {
            int I = 0;

            DocumentosDTO Documentos = new DocumentosDTO();
            Documentos.Documentos = new DocumentoDTO[Asociaciones.Count];

            foreach (AsociacionDocumento Asociacion in Asociaciones)
            {
                Documentos.Documentos[I] = ObtenerDocumentoDTO(Asociacion);

                I++;
            }

            return Documentos;
        }

        private DocumentosDTO ObtenerDocumentos(int CodigoPais, string Codigo)
        {
            TipoAsociacionDocumento TipoAsociacion =
                TipoAsociacionDocumentoHome.Producto();

            Producto Producto = ProductoHome.Obtener(CodigoPais, Codigo);

            IList<AsociacionDocumento> Documentos = AsociacionDocumentoHome.
                BuscarPorObjeto(Producto.Id, TipoAsociacion.Id);

            return ObtenerDocumentos(Documentos);
        }

        private DocumentosDTO ObtenerDocumentos(int CodigoPais)
        {
            TipoAsociacionDocumento TipoAsociacion =
                TipoAsociacionDocumentoHome.Pais();

            Pais Pais = PaisHome.ObtenerPorCodigo(CodigoPais);

            IList<AsociacionDocumento> Documentos = AsociacionDocumentoHome.
                BuscarPorObjeto(Pais.Id, TipoAsociacion.Id);

            return ObtenerDocumentos(Documentos);
        }

        #region ICondicionesService Members

        public string ConvertirConsulta(ConsultaCondicionesDTO Consulta)
        {
            return ServicioConversionXml.Instancia().SerializeObject(Consulta);
        }

        public string ConvertirGrupos(GruposClausulaDTO Grupos)
        {
            return ServicioConversionXml.Instancia().SerializeObject(Grupos);
        }

        public string ObtenerDocumentosXml(int CodigoPais, string Codigo,
            string Usuario, string Clave)
        {
            return ServicioConversionXml.Instancia().SerializeObject(
                ObtenerDocumentos(CodigoPais, Codigo));
        }

        public string ObtenerDocumentosXml(int CodigoPais, string Usuario, string Clave)
        {
            try
            {
                return ServicioConversionXml.Instancia().SerializeObject(
                    ObtenerDocumentos(CodigoPais));
            }
            catch (Exception e)
            {
                throw new Exception("**** MESSAGE: " + e.Message + "**** STACK: " + e.StackTrace, e);
            }
        }

        public string ObtenerComparacionesXml(string XmlConsulta, string Usuario, string Clave)
        {
            try
            {
                ConsultasCondicionesDTO Consultas = (ConsultasCondicionesDTO)
                    ServicioConversionXml.Instancia().DeserializeObject(
                    XmlConsulta, Type.GetType("Backend.Servicios.ConsultasCondicionesDTO"));

                ConjuntoGruposClausulaDTO Conjunto = new ConjuntoGruposClausulaDTO();

                Conjunto.Grupos = new GrupoClausulaDTO[Consultas.Consultas.Length];
                int I = 0;

                foreach (ConsultaCondicionesDTO Consulta in Consultas.Consultas)
                {

                    GruposClausulaDTO Grupos = ObtenerCondicionesSimple(Consulta, Usuario, Clave);

                    Conjunto.Grupos[I] = Grupos.Grupos[0];
                    I++;
                }

                return ServicioConversionXml.Instancia().SerializeObject(Conjunto);
            }
            catch (Exception e)
            {
                throw new Exception("**** MESSAGE: " + e.Message + "**** STACK: " + e.StackTrace, e);
            }

        }

        #endregion

        private void ObtenerCodigos(GrupoClausulaDTO Grupo, IList<string> ICodigo)
        {
            foreach (ContenidoClausulaDTO Contenido in Grupo.Clausulas)
            {
                if (!ICodigo.Contains(Contenido.Clausula.Codigo))
                {
                    ICodigo.Add(Contenido.Clausula.Codigo);
                }
            }
        }

        private void FiltrarCondiciones(ConjuntoGruposClausulaDTO Conjunto, IList<string> ICodigo)
        {
            foreach (GrupoClausulaDTO Grupo in Conjunto.Grupos)
            {
                Grupo.Clausulas = Grupo.Clausulas.Where(x => ICodigo.Contains(x.Clausula.Codigo)).ToArray();
            }
        }

        public string ObtenerClausulasCoincidentesXml(string XmlConsulta, string Usuario, string Clave)
        {
            try
            {
                ConsultasCondicionesDTO Consultas = (ConsultasCondicionesDTO)
                    ServicioConversionXml.Instancia().DeserializeObject(
                    XmlConsulta, Type.GetType("Backend.Servicios.ConsultasCondicionesDTO"));

                ConjuntoGruposClausulaDTO Conjunto = new ConjuntoGruposClausulaDTO();

                Conjunto.Grupos = new GrupoClausulaDTO[Consultas.Consultas.Length];
                int I = 0;

                IList<string> ICodigo = new List<string>();

                foreach (ConsultaCondicionesDTO Consulta in Consultas.Consultas)
                {
                    GruposClausulaDTO Grupos = ObtenerCondicionesSimple(Consulta, Usuario, Clave);

                    Conjunto.Grupos[I] = Grupos.Grupos[0];
                    ObtenerCodigos(Conjunto.Grupos[I], ICodigo);

                    I++;
                }

                FiltrarCondiciones(Conjunto, ICodigo);

                return ServicioConversionXml.Instancia().SerializeObject(Conjunto);
            }
            catch (Exception e)
            {
                throw new Exception("**** MESSAGE: " + e.Message + "**** STACK: " + e.StackTrace, e);
            }
        }

        #region IServicioClausulas Members


        public string ObtenerDocumentosProductoXml(int CodigoPais, string Codigo, string Usuario, string Clave)
        {
            return ServicioClausulas.Instancia().
                ObtenerDocumentosXml(CodigoPais, Codigo, Usuario, Clave);
        }

        public string ObtenerDocumentosPaisXml(int CodigoPais, string Usuario, string Clave)
        {
            return ServicioClausulas.Instancia().
                ObtenerDocumentosXml(CodigoPais, Usuario, Clave);
        }

        #endregion
    }
}
