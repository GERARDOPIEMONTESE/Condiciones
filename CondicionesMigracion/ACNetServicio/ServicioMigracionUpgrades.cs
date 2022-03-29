using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNetDatos;
using CondicionesMigracion.ACNet;
using Backend.Dominio;
using Backend.Homes;
using Backend.DTO;
using Backend.Servicios;
using System.Text.RegularExpressions;
using CondicionesMigracion.ACNetFormatos;


namespace CondicionesMigracion.ACNetServicio
{
    class ServicioMigracionUpgrades 
    {
        private const string ANUAL = "365";

        #region Singleton

        private static ServicioMigracionUpgrades _Instancia;

        private ServicioMigracionUpgrades()
        {
        }

        public static ServicioMigracionUpgrades Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioMigracionUpgrades();
            }
            return _Instancia;
        }

        #endregion

        private void CargarTextoResumen(Backend.DTO.GrupoClausulaDTO Dto, ClausulaTarifaGrupo GrupoReferencia)
        {
            if (GrupoReferencia.IdTextoVoucher != 0)
            {
                TextoResumen TextoResumen = DAOTextoResumen.Instancia().
                    Obtener(GrupoReferencia.IdTextoVoucher);

                //Dto.TextoResumen = TextoHome.Obtener(Texto.RESUMEN, TextoResumen.Nombre);
                Texto Texto = TextoHome.Obtener(Texto.RESUMEN, TextoResumen.Nombre);

                AsociacionTexto Asociacion = new AsociacionTexto();
                Asociacion.IdTexto = Texto.Id;
                Asociacion.IdTipoTexto = Texto.TipoTexto.Id;
                Asociacion.IdTipoPlan = TipoPlanHome.Obtener(TipoPlan.CODIGO_TODOS).Id;

                Dto.Textos.Add(Asociacion);

            }
        }

        private void CargarRangos(ClausulaTarifaGrupo Grupo, IList<ClausulaDato> DatosDto, Backend.DTO.ClausulaDTO DatoDto, IConversorFormato Conversor)
        {
            if (DatoDto.Contenidos == null)
            {
                DatoDto.Contenidos = new List<ContenidoRangoDTO>();
            }

            IList<ContenidoRangoDTO> Rangos = Conversor.GenerarConversion(Grupo, DatosDto);
            foreach (ContenidoRangoDTO Rango in Rangos)
            {
                DatoDto.Contenidos.Add(Rango);
            }
        }

        private string NombreClausula(ClausulaDato Dato)
        {
            return Dato.IdClausula.Trim().Replace("..", ".");
        }

        private void CargarContenido(Backend.DTO.GrupoClausulaDTO Dto, IList<ClausulaTarifaGrupo> Grupos)
        {
            IList<ClausulaDato> ClausulasDato = DAOClausulaDato.Instancia().Buscar(Grupos);

            foreach (ClausulaDato Dato in ClausulasDato)
            {
                Backend.DTO.ClausulaDTO DatoDto = Dto.Obtener(Dato.IdClausula.Trim());

                if (!Dto.ContieneClausula(Dato.IdClausula.Trim()))
                {

                    DatoDto.NombreClausula = NombreClausula(Dato);
                    DatoDto.TextoIdentificatorio = DatoDto.NombreClausula;
                    DatoDto.IdClausula = ClausulaHome.Obtener(DatoDto.NombreClausula).Id;
                    DatoDto.IdTipoClausula = DatoDto.NombreClausula.Contains("C.") ?
                        TipoClausulaHome.Obtener(TipoClausula.SERVICIO).Id :
                        DatoDto.NombreClausula.Contains("D.") ? TipoClausulaHome.Obtener(TipoClausula.SEGURO).Id :
                        TipoClausulaHome.Obtener(TipoClausula.GENERAL).Id;
                    DatoDto.Orden = Dato.Posicion;
                    DatoDto.TipoCobertura = TipoCoberturaHome.Obtener(
                        ServicioCompatibilidadTipoCobertura.Instancia().
                        ObtenerCodigo(Dato.IdRate));

                    //Datos nuevos
                    DatoDto.IdTipoImpresionClausula = TipoImpresionClausulaHome.Obtener(TipoImpresionClausula.COMPLETO).Id;
                    DatoDto.IdTipoContenidoImpresion = TipoContenidoImpresionHome.Obtener(TipoContenidoImpresion.COMPLETO).Id;
                    DatoDto.VisibleEnAsistencia = true;
                    DatoDto.EvaluableEnAsistencia = true;

                    Dto.Clausulas.Add(DatoDto.NombreClausula, DatoDto);
                }
            }

            foreach (Backend.DTO.ClausulaDTO DatoDto in Dto.Clausulas.Values)
            {
                IList<ClausulaDato> DatosClausula = ObtenerDatos(DatoDto.NombreClausula, ClausulasDato);

                foreach (ClausulaTarifaGrupo Grupo in Grupos)
                {
                    IDictionary<string, IList<ClausulaDato>> Datos = ObtenerDatos(Grupo, DatosClausula);

                    foreach (string Key in Datos.Keys)
                    {
                        CargarRangos(Grupo, Datos[Key], DatoDto,
                            ConversorFormatoContainer.Instancia().Obtener(Key));
                    }
                }
            }
        }

        private IList<ClausulaDato> ObtenerDatos(string IdClausula, IList<ClausulaDato> DatosOriginal)
        {
            IList<ClausulaDato> Datos = new List<ClausulaDato>();

            foreach (ClausulaDato Dato in DatosOriginal)
            {
                if (Dato.IdClausula.Equals(IdClausula)) 
                {
                    Datos.Add(Dato);
                }
            }

            return Datos;
        }
        private IDictionary<string, IList<ClausulaDato>> ObtenerDatos(ClausulaTarifaGrupo Grupo, IList<ClausulaDato> DatosOriginal)
        {
            IDictionary<string, IList<ClausulaDato>> Datos = new Dictionary<string, IList<ClausulaDato>>();

            foreach (ClausulaDato Dato in DatosOriginal)
            {
                if (Dato.IdGrupo == Grupo.IdGrupo)
                {
                    if (!Datos.Keys.Contains(Dato.Formato))
                    {
                        Datos.Add(Dato.Formato, new List<ClausulaDato>());
                    }

                    Datos[Dato.Formato].Add(Dato);                    
                }
            }

            return Datos;
        }

        private Backend.DTO.GrupoClausulaDTO CrearDto(ClausulaTarifaGrupo Grupo, string Discriminador)
        {
            //Aca busco todos los grupos que corresponden a ese upgrade.
            IList<ClausulaTarifaGrupo> Grupos = DAOClausulaTarifaGrupo.
                Instancia().Buscar(Grupo.Pais, Grupo.Producto, 
                Grupo.Tarifa, Grupo.CantidadDias.Trim(), Discriminador);

            if (Grupos.Count > 1)
            {
                int I = 0;
                I++;
            }

            Backend.DTO.GrupoClausulaDTO Dto = new Backend.DTO.GrupoClausulaDTO();
            Dto.TipoGrupoClausula = ObtenerTipoGrupo(Discriminador);

            ClausulaDato ClausulaDato = DAOClausulaDato.Instancia().
                Obtener(Grupo.IdGrupo, ClausulaDato.DIAS_CONSECUTIVOS_INTERNACIONAL);

            if (ClausulaDato.Id == 0)
            {
                ClausulaDato = DAOClausulaDato.Instancia().
                    Obtener(Grupo.IdGrupo, ClausulaDato.DIAS_CONSECUTIVOS_NACIONAL);
            }

            Dto.DiasConsecutivos = ClausulaDato.Dias;

            foreach (ClausulaTarifaGrupo GrupoOriginal in Grupos)
            {
                Tarifa Tarifa = TarifaHome.Obtener(GrupoOriginal.Pais, GrupoOriginal.Producto,
                    GrupoOriginal.Tarifa, ANUAL.Equals(GrupoOriginal.CantidadDias.Trim()));

                if (Dto.CodigoPais == 0)
                {
                    Dto.CodigoPais = Tarifa.CodigoPais;
                    Dto.Anual = GrupoOriginal.Anual;
                }

                Dto.Tarifas.Add(Tarifa);
            }

            CargarTextoResumen(Dto, Grupo);
            CargarContenido(Dto, Grupos);

            return Dto;
        }

        private TipoGrupoClausula ObtenerTipoGrupo(string Discriminador)
        {
            if (ClausulaTarifaGrupo.PRODUCTO.Equals(Discriminador))
            {
                return TipoGrupoClausulaHome.Producto();
            }

            return TipoGrupoClausulaHome.Upgrade();
        }

        private void CrearGrupos(ClausulaTarifaGrupo Grupo, string Discriminador)
        {
            ServicioGrupoClausula.Crear(CrearDto(Grupo, Discriminador));
        }

        public void Migrar(string Discriminador)
        {
            IList<ClausulaTarifaGrupo> Grupos = DAOClausulaTarifaGrupo.Instancia().BuscarGruposUpgrades();
            int i = 1;
            try
            {
                foreach (ClausulaTarifaGrupo Grupo in Grupos)
                {
                    //if (i >= 3973)
                    //{
                    ClausulaTarifaGrupo GrupoReferencia = DAOClausulaTarifaGrupo.Instancia().Buscar(Grupo.IdGrupo, Discriminador)[0];

                    CrearGrupos(GrupoReferencia, Discriminador.ToUpper());
                    //}                    
                    i++;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error en i: " + i, e);
            }
        }
    }
}
