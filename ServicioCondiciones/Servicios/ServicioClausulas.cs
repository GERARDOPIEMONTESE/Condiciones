using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Backend.Contextos;
using Backend.Dominio;
using Backend.Homes;
using CondicionesParser.Parser;
using ServicioCondiciones.Properties;
using Backend.Datos;
using CapaNegocioDatos.Servicios;
using BackendCondiciones.DTO;

namespace ServicioCondiciones
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.
    public class ServicioClausulas : IServicioClausulas
    {
        #region Singleton

        private static IServicioClausulas _Instancia;

        private ServicioClausulas()
        {
        }

        public static IServicioClausulas Instancia()
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

            //SLA
            Contexto.CodigoAgencia = Consulta.Agencia;
            Contexto.NumeroSucursal = Consulta.Sucursal;
            Contexto.IdTipoGrupoClausula = TipoGrupoClausulaHome.SLA().Id;
            //Fin SLA

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

        public bool SonEquivalentes(ContenidoClausulaRangoDTO Rango, ContenidoClausulaRangoDTO RangoNuevo)
        {
            bool Equivalentes = Rango.EdadMinima == RangoNuevo.EdadMinima;
            Equivalentes &= Rango.EdadMaxima == RangoNuevo.EdadMaxima;
            Equivalentes &= Rango.TipoPlan == RangoNuevo.TipoPlan;
            Equivalentes &= Rango.TipoModalidad == RangoNuevo.TipoModalidad;
            Equivalentes &= Rango.Categoria == RangoNuevo.Categoria;
            Equivalentes &= Rango.IdValidezTerritorial == RangoNuevo.IdValidezTerritorial;
            Equivalentes &= Rango.IdValidezTerritorialClausula == RangoNuevo.IdValidezTerritorialClausula;
            Equivalentes &= Rango.Contenido == RangoNuevo.Contenido;
            Equivalentes &= Rango.Peso == RangoNuevo.Peso;

            return Equivalentes;
        }

        //private bool ExisteRango(ContenidoClausulaDTO Dto, ContenidoClausulaRangoDTO RangoNuevo)
        private bool ExisteRango(IList<ContenidoClausulaRangoDTO> Rangos, ContenidoClausulaRangoDTO RangoNuevo)
        {
            //for (int I = 0; I < Dto.Rangos.Length; I++)
            foreach(ContenidoClausulaRangoDTO RangoDto in Rangos)
            {
                //ContenidoClausulaRangoDTO RangoDto = Dto.Rangos[I];
                if (RangoDto != null && SonEquivalentes(RangoDto, RangoNuevo))
                {
                    return true;
                }
            }

            return false;
        }

        private void CrearContenidoRangoDTO(ContenidoClausula Contenido, ContenidoClausulaDTO ContenidoDTO)
        {
            IList<ContenidoClausulaRangoDTO> RangosDTO = new List<ContenidoClausulaRangoDTO>();

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

                if (Rango.Peso == null || Rango.Peso == 0)
                    RangoDTO.Peso = Contenido.Clausula.Peso == null ? 0 : Contenido.Clausula.Peso;
                else
                    RangoDTO.Peso = Rango.Peso;

                RangoDTO.Tasa = 0;
                RangoDTO.Valor = 0;

                if (!ExisteRango(RangosDTO, RangoDTO))
                {
                    RangosDTO.Add(RangoDTO);
                }
            }

            ContenidoDTO.Rangos = RangosDTO.ToArray<ContenidoClausulaRangoDTO>();
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
            
            if(EsPaisConPoliza(Grupo))
                CalculoPorcentaje(Clausulas);

            GrupoDTO.Clausulas = Clausulas.ToArray<ContenidoClausulaDTO>();
        }

        private bool EsPaisConPoliza(GrupoClausula Grupo)
        {
            string[] paises = CapaNegocioDatos.CapaHome.CodigoActivadorHome.ObtenerPaisesConPoliza();
            Pais pais = PaisHome.ObtenerPorIdLocacion(Grupo.IdLocacion);

            foreach (string item in paises)
            {
                if (pais != null && pais.Id != 0)
                {
                    if (pais.Codigo.Equals(item))
                        return true;
                }
            }
            return false;
        }

        private void CalculoPorcentaje(IList<ContenidoClausulaDTO> Clausulas)
        {
            decimal? total = 0;
            foreach (ContenidoClausulaDTO clausula in Clausulas)
            {
                if (clausula.Rangos[0].Peso > 0 && clausula.Clausula.CodigoTipoClausula == "SEGU")
                { total = total + clausula.Rangos[0].Peso; }
            }

            foreach (ContenidoClausulaDTO clausula in Clausulas)
            {
                if (clausula.Rangos[0].Peso != null && clausula.Rangos[0].Peso > 0)
                {
                    clausula.Rangos[0].Tasa = (clausula.Rangos[0].Peso * 100) / total;
                    clausula.Rangos[0].Valor = ObtenerMonto(clausula.Rangos[0]);
                }
            }
        }

        private decimal? ObtenerMonto(ContenidoClausulaRangoDTO rango)
        {
            string[] palabras = rango.Contenido.Split(null); decimal monto;

            foreach (string item in palabras)
            {
                if (decimal.TryParse(item, out monto))
                    return monto = decimal.Parse(item);
            }

            return 0;
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
                //if (Original.Documento.Id == Asociacion.Documento.Id)
                if (Original.Documento.TipoDocumento != null && 
                    Asociacion.Documento.TipoDocumento != null &&
                    Original.Documento.Idioma != null &&
                    Asociacion.Documento.Idioma.Id != null &&
                    Original.Documento.TipoDocumento.Id == Asociacion.Documento.TipoDocumento.Id && 
                    Original.Documento.Idioma.Id == Asociacion.Documento.Idioma.Id)
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
                        if (!ContieneDocumento(Grupo, DocumentoUpgrade)) {
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

        //SLA
        private IList<GrupoClausula> ObtenerCondicionesSLA(ConsultaCondicionesDTO Consulta)
        {
            IList<GrupoClausula> GruposSLA = GrupoClausulaHome.BuscarSLA(CrearContextoConsulta(Consulta));

            foreach (GrupoClausula Grupo in GruposSLA)
            {
                foreach (ContenidoClausula Contenido in Grupo.Contenidos)
                {
                    Contenido.CodigoTipoGrupo = TipoGrupoClausulaHome.SLA().Nombre;
                }
            }

            return GruposSLA;
        }
        //SLA


        public GruposClausulaDTO ObtenerCondiciones(ConsultaCondicionesDTO Consulta, string Usuario, string Clave)
        {
            IList<GrupoClausula> Grupos = GrupoClausulaHome.Buscar(
                CrearContextoConsulta(Consulta));

            //Busqueda y merge de clausulas upgrades

            MergearClausulas(Grupos, ObtenerCondicionesUpgrade(Consulta));

            //SLA
            if (!Consulta.Agencia.Equals(string.Empty) && Consulta.Sucursal != -1)
                MergearClausulas(Grupos, ObtenerCondicionesSLA(Consulta));
            //Fin SLA

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
                    XmlConsulta, Type.GetType("ServicioCondiciones.ConsultaCondicionesDTO"));

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
            TipoAsociacionDocumento TipoAsociacion = TipoAsociacionDocumentoHome.Pais();

            Pais Pais = PaisHome.ObtenerPorCodigo(CodigoPais);

            IList<AsociacionDocumento> Documentos = AsociacionDocumentoHome.BuscarPorObjeto(Convert.ToInt32(Pais.Codigo), TipoAsociacion.Id);

            return ObtenerDocumentos(Documentos);
        }

        #region ICondicionesService Members

        public string ConvertirConsulta(ConsultaCondicionesDTO Consulta)
        {
            return ServicioConversionXml.Instancia().SerializeObjectISO(Consulta);
        }

        public string ConvertirGrupos(GruposClausulaDTO Grupos)
        {
            return ServicioConversionXml.Instancia().SerializeObjectISO(Grupos);
        }

        public string ObtenerDocumentosXml(int CodigoPais, string Codigo, 
            string Usuario, string Clave)
        {
            return ServicioConversionXml.Instancia().SerializeObjectISO(
                ObtenerDocumentos(CodigoPais, Codigo));
        }

        public string ObtenerDocumentosXml(int CodigoPais, string Usuario, string Clave)
        {
            try 
            {
                return ServicioConversionXml.Instancia().SerializeObjectISO(
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
                    XmlConsulta, Type.GetType("ServicioCondiciones.ConsultasCondicionesDTO"));

                ConjuntoGruposClausulaDTO Conjunto = new ConjuntoGruposClausulaDTO();

                Conjunto.Grupos = new GrupoClausulaDTO[Consultas.Consultas.Length];
                int I = 0;

                foreach (ConsultaCondicionesDTO Consulta in Consultas.Consultas)
                {

                    GruposClausulaDTO Grupos = ObtenerCondicionesSimple(Consulta, Usuario, Clave);

                    Conjunto.Grupos[I] = Grupos.Grupos[0];
                    I++;
                }

                return ServicioConversionXml.Instancia().SerializeObjectISO(Conjunto);
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
                    XmlConsulta, Type.GetType("ServicioCondiciones.ConsultasCondicionesDTO"));

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

                return ServicioConversionXml.Instancia().SerializeObjectISO(Conjunto);
            }
            catch (Exception e)
            {
                throw new Exception("**** MESSAGE: " + e.Message + "**** STACK: " + e.StackTrace, e);
            }
        }

        #region IServicioClausulas Members


        public string ObtenerCondicionesXml(string CodigoPais, string Producto, string Tarifa, string Usuario, string Clave)
        {
            try
            {
                ConsultaCondicionesDTO Consulta = new ConsultaCondicionesDTO();

                Pais Pais = PaisHome.ObtenerPorCodigoISO2(CodigoPais);

                Consulta.CodigoProducto = Producto;
                Consulta.CodigoTarifa = Tarifa;
                Consulta.CodigoPais = Int32.Parse(Pais.Codigo);
                Consulta.Edad = 30;
                Consulta.IdTipoPlan = 1;
                Consulta.IdTipoModalidad = 1;
                Consulta.ConsultaPadre = new ConsultaCondicionesDTO();
                Consulta.ConsultaPadre.CodigoPais = Consulta.CodigoPais;
                Consulta.ConsultaPadre.CodigoProducto = Consulta.CodigoProducto;
                Consulta.ConsultaPadre.CodigoTarifa = Consulta.CodigoTarifa;
                Consulta.ConsultaPadre.Edad = Consulta.Edad;
                Consulta.ConsultaPadre.IdTipoPlan = Consulta.IdTipoPlan;
                Consulta.ConsultaPadre.IdTipoModalidad = Consulta.IdTipoModalidad;

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

        public GrupoClausulaDTO ObtenerCondiciones(string CodigoPais, string Producto, string Tarifa, int Edad)
        {
            try
            {
                ConsultaCondicionesDTO Consulta = new ConsultaCondicionesDTO();

                Pais Pais = PaisHome.ObtenerPorCodigoISO2(CodigoPais);

                Consulta.CodigoProducto = Producto;
                Consulta.CodigoTarifa = Tarifa;
                Consulta.CodigoPais = Int32.Parse(Pais.Codigo);
                Consulta.Edad = Edad;
                Consulta.IdTipoPlan = 1;
                Consulta.IdTipoModalidad = 1;
                Consulta.ConsultaPadre = new ConsultaCondicionesDTO();
                Consulta.ConsultaPadre.CodigoPais = Consulta.CodigoPais;
                Consulta.ConsultaPadre.CodigoProducto = Consulta.CodigoProducto;
                Consulta.ConsultaPadre.CodigoTarifa = Consulta.CodigoTarifa;
                Consulta.ConsultaPadre.Edad = Consulta.Edad;
                Consulta.ConsultaPadre.IdTipoPlan = Consulta.IdTipoPlan;
                Consulta.ConsultaPadre.IdTipoModalidad = Consulta.IdTipoModalidad;

                GruposClausulaDTO Grupos = ObtenerCondiciones(Consulta, "", "");

                return Grupos.Grupos[0];
            }
            catch (Exception e)
            {
                throw new Exception("**** MESSAGE: " + e.Message + "**** STACK: " + e.StackTrace, e);
            }
        }

        public GrupoClausulaDTO ObtenerCondiciones(int CodigoPais, string Producto, string Tarifa, int Edad, bool Anual, int IdTipoPlan)
        {
            try
            {
                ConsultaCondicionesDTO Consulta = new ConsultaCondicionesDTO();

                Consulta.CodigoProducto = Producto;
                Consulta.CodigoTarifa = Tarifa;
                Consulta.CodigoPais = CodigoPais;
                Consulta.Edad = Edad;
                Consulta.IdTipoPlan = IdTipoPlan;
                Consulta.IdTipoModalidad = 1;
                Consulta.Anual = Anual;
                Consulta.ConsultaPadre = new ConsultaCondicionesDTO();
                Consulta.ConsultaPadre.CodigoPais = Consulta.CodigoPais;
                Consulta.ConsultaPadre.CodigoProducto = Consulta.CodigoProducto;
                Consulta.ConsultaPadre.CodigoTarifa = Consulta.CodigoTarifa;
                Consulta.ConsultaPadre.Edad = Consulta.Edad;
                Consulta.ConsultaPadre.IdTipoPlan = Consulta.IdTipoPlan;
                Consulta.ConsultaPadre.IdTipoModalidad = Consulta.IdTipoModalidad;

                GruposClausulaDTO Grupos = ObtenerCondiciones(Consulta, "", "");

                return Grupos.Grupos[0];
            }
            catch (Exception e)
            {
                throw new Exception("**** MESSAGE: " + e.Message + "**** STACK: " + e.StackTrace, e);
            }
        }
        #endregion

        public string GetPrintedBenefits(string xml, string Usuario, string Clave)
        {
            try
            {
                ServicioBroker.Instancia().ObtenerServicioUsuario().ValidarUsuario(Usuario, Clave);

                //string xmlTest = "<ConsultaCondicionesDTO>  <CodigoISOPais>US</CodigoISOPais>  <CodigoProducto>Z1</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <Anual>false</Anual>  <Edad>30</Edad>  <Agencia>99099</Agencia>  <Sucursal>0</Sucursal>  <Idioma>ES</Idioma>  <TipoModalidad>NA</TipoModalidad></ConsultaCondicionesDTO>";
                
                BackendCondiciones.DTO.ConsultaCondicionesDTO objeto = new BackendCondiciones.DTO.ConsultaCondicionesDTO();
                objeto = (BackendCondiciones.DTO.ConsultaCondicionesDTO)ServicioConversionXml.Instancia().DeserializeObject(xml, objeto.GetType());
                
                ConsultaCondicionesDTO consulta = new ConsultaCondicionesDTO();
                int pais = consulta.CodigoPais = Convert.ToInt32(PaisHome.ObtenerPorCodigoISO2(objeto.CodigoISOPais).Codigo);
                string producto = consulta.CodigoProducto = objeto.CodigoProducto;
                string tarifa = consulta.CodigoTarifa = objeto.CodigoTarifa;
                bool anual = consulta.Anual = objeto.Anual;
                int edad = consulta.Edad = objeto.Edad;
                string agencia = consulta.Agencia = objeto.Agencia;
                int sucursal = consulta.Sucursal = objeto.Sucursal;
                string idioma = objeto.Idioma;
                int idIdioma = 0;
                consulta.IdTipoModalidad = TipoModalidadHome.Obtener(objeto.TipoModalidad).Id;
                
                switch (idioma.ToLower())
                {
                    case "es":
                        idIdioma = 1;
                        break;
                    case "en":
                        idIdioma = 2;
                        break;
                    case "pt":
                        idIdioma = 3;
                        break;
                    default:
                        idIdioma = 2;
                        break;
                }

                GrupoClausulasImpresasDTO grupoImpresas = new GrupoClausulasImpresasDTO();

                GruposClausulaDTO grupoClausula = ObtenerCondiciones(consulta, Usuario, Clave);

                string respuesta = "";

                if (grupoClausula.Grupos.Count() > 0)
                {
                    grupoImpresas.ClausulasImpresas = ObtenerClausulasImpresas(grupoClausula, idIdioma).ToArray();

                    grupoImpresas.Documentos = ObtenerDocumentosImpresos(grupoClausula, idIdioma).ToArray();

                    return respuesta = ServicioConversionXml.Instancia().SerializeObject(grupoImpresas);
                }
                else 
                {
                    GrupoClausulasImpresasDTO grupoError = new GrupoClausulasImpresasDTO();
                    grupoError.Estado = "No group of conditions was found.";
                    return respuesta = ServicioConversionXml.Instancia().SerializeObject(grupoError);
                }
            }
            catch (Exception ex)
            {
                GrupoClausulasImpresasDTO grupoError = new GrupoClausulasImpresasDTO();
                grupoError.Estado = ex.Message;
                string respuesta = ServicioConversionXml.Instancia().SerializeObject(grupoError);
                return respuesta;
            }
        }

        public IList<ClausulaImpresaDTO> ObtenerClausulasImpresas(GruposClausulaDTO grupoClausula, int idIdioma)
        {
            IList<ClausulaImpresaDTO> iClausulaImpresaDTO = new List<ClausulaImpresaDTO>();

            foreach (ContenidoClausulaDTO contenidoClausulaDto in grupoClausula.Grupos[0].Clausulas)
            {
                if (contenidoClausulaDto.ShowClause())
                {
                    string codigo = contenidoClausulaDto.GetIdClause(idIdioma);
                    string titulo = contenidoClausulaDto.GetTitleClause(idIdioma);
                    string contenido = contenidoClausulaDto.GetContentClause(idIdioma);
                    string tipoClausula = contenidoClausulaDto.Clausula.CodigoTipoClausula;

                    ClausulaImpresaDTO clausula = new ClausulaImpresaDTO(codigo, titulo, contenido, tipoClausula);

                    iClausulaImpresaDTO.Add(clausula);
                }
            }

            return iClausulaImpresaDTO;
        }

        public IList<DocumentoDTO> ObtenerDocumentosImpresos(GruposClausulaDTO grupoClausula, int idIdioma)
        {
            IList<DocumentoDTO> documentos = new List<DocumentoDTO>();

            foreach (DocumentoDTO documentoDTO in grupoClausula.Grupos[0].Documentos)
            {
                if (documentoDTO.IdIdioma == idIdioma)
                {
                    documentos.Add(documentoDTO);
                }
            }

            return documentos;
        }
    }
}
    