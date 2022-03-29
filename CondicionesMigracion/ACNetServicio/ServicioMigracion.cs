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
    public class ServicioMigracion
    {
        private const string ANUAL = "365";

        #region Singleton

        private static ServicioMigracion _Instancia;

        private ServicioMigracion()
        {
        }

        public static ServicioMigracion Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioMigracion();
            }
            return _Instancia;
        }

        #endregion

        private void CargarTextoResumen(Backend.DTO.GrupoClausulaDTO Dto, ClausulaTarifaGrupo GrupoReferencia)
        {
            //if (GrupoReferencia.IdTextoVoucher != 0)
            //{
            //    TextoResumen TextoResumen = DAOTextoResumen.Instancia().
            //        Obtener(GrupoReferencia.IdTextoVoucher);

            //    Texto Texto = TextoHome.Obtener(Texto.RESUMEN, TextoResumen.Nombre);

            //    AsociacionTexto Asociacion = new AsociacionTexto();
            //    Asociacion.IdTexto = Texto.Id;
            //    Asociacion.IdTipoTexto = Texto.TipoTexto.Id;
            //    Asociacion.IdTipoPlan = "|A6|A7|A8|A9|AA|AB|AC|AD|B6|B7|B8|B9|BA|BB|D6|D7|D8|D9|DA|DB|E6|E7|E8|E9|EA|EB|F6|F7|F8|F9|FA|FB|MA|MB|MC|MD|ME|MF|MG|MH|MI|MJ|R1|R2|R3|R4|R5|R6|R7|XU|".Contains(GrupoReferencia.Producto) 
            //        ? TipoPlanHome.Obtener(TipoPlan.PLAN_INDIVIDUAL).Id : 
            //        TipoPlanHome.Obtener(TipoPlan.CODIGO_TODOS).Id;

            //    Dto.Textos.Add(Asociacion);
            //}
        }

        private void CargarRangos(ClausulaTarifaGrupo Grupo, IList<ClausulaDato> DatosDto, Backend.DTO.ClausulaDTO DatoDto, IConversorFormato Conversor)
        {
            DatoDto.Contenidos = Conversor.GenerarConversion(Grupo, DatosDto);
        }

        private string NombreClausula(ClausulaDato Dato)
        {
            return Dato.IdClausula.Trim().Replace("..", ".");
        }

        private void CargarContenido(Backend.DTO.GrupoClausulaDTO Dto, ClausulaTarifaGrupo GrupoReferncia)
        {
            IList<ClausulaDato> ClausulasDato = DAOClausulaDato.Instancia().Buscar(GrupoReferncia.IdGrupo);

            IList<ClausulaDato> Rangos = new List<ClausulaDato>();

            Backend.DTO.ClausulaDTO DatoDtoAnterior = new Backend.DTO.ClausulaDTO();
            string FormatoAnterior = "";

            foreach (ClausulaDato Dato in ClausulasDato)
            {
                Backend.DTO.ClausulaDTO DatoDto = Dto.Obtener(Dato.IdClausula.Trim());

                if (Dato.IdClausula.Trim().Equals("D.2.2"))
                {
                    int i = 0;
                    i++;
                }

                if (!Dto.ContieneClausula(Dato.IdClausula.Trim()))
                {
                    if (FormatoAnterior.Length > 0)
                    {
                        CargarRangos(GrupoReferncia, Rangos, DatoDtoAnterior,
                            ConversorFormatoContainer.Instancia().Obtener(FormatoAnterior));
                    }

                    Rangos.Clear();

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
                Rangos.Add(Dato);
                
                DatoDtoAnterior = DatoDto;
                FormatoAnterior = Dato.Formato;
            }

            CargarRangos(GrupoReferncia, Rangos, DatoDtoAnterior,
                ConversorFormatoContainer.Instancia().Obtener(FormatoAnterior));
        }

        private Backend.DTO.GrupoClausulaDTO CrearDto(int IdGrupo, string Discriminador)
        {
            IList<ClausulaTarifaGrupo> Grupos = DAOClausulaTarifaGrupo.
                Instancia().Buscar(IdGrupo, Discriminador);

            Backend.DTO.GrupoClausulaDTO Dto = new Backend.DTO.GrupoClausulaDTO();
            Dto.TipoGrupoClausula = ObtenerTipoGrupo(Discriminador);

            ClausulaDato ClausulaDato = DAOClausulaDato.Instancia().
                Obtener(IdGrupo, ClausulaDato.DIAS_CONSECUTIVOS_INTERNACIONAL);

            if (ClausulaDato.Id == 0)
            {
                ClausulaDato = DAOClausulaDato.Instancia().
                    Obtener(IdGrupo, ClausulaDato.DIAS_CONSECUTIVOS_NACIONAL);
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

            CargarTextoResumen(Dto, Grupos[0]);
            CargarContenido(Dto, Grupos[0]);

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

        private void CrearGrupos(int IdGrupo, string Discriminador)
        {
            ServicioGrupoClausula.Crear(CrearDto(IdGrupo, Discriminador));
        }

        public void Migrar(string Discriminador)
        {
            IList<int> IdsGrupo = DAOClausulaTarifaGrupo.Instancia().
                BuscarIds(Discriminador);
            int i = 1;
            try
            {
                foreach (int IdGrupo in IdsGrupo)
                {
                    //if (i >= 4154)
                    //{
                    CrearGrupos(IdGrupo, Discriminador.ToUpper());
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
