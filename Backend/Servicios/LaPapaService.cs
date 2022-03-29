using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Homes;
using FrameworkDAC.Negocio;
using FrameworkDAC.Dato;


namespace Backend.Servicios
{
    public class LaPapaService
    {
        private IDictionary<string, IObjetoCodificadoHome> _Homes = new Dictionary<string, IObjetoCodificadoHome>();

        private static LaPapaService _Instancia;

        private LaPapaService()
        {
            _Homes.Add(typeof(TipoClausula).Name, new TipoClausulaHome());
            _Homes.Add(typeof(TipoAsociacionDocumento).Name, new TipoAsociacionDocumentoHome());
            _Homes.Add(typeof(TipoCobertura).Name, new TipoCoberturaHome());
            _Homes.Add(typeof(TipoContenidoImpresion).Name, new TipoContenidoImpresionHome());
            _Homes.Add(typeof(TipoDocumento).Name, new TipoDocumentoHome());
            _Homes.Add(typeof(TipoGrupoClausula).Name, new TipoGrupoClausulaHome());
            _Homes.Add(typeof(TipoImpresionClausula).Name, new TipoImpresionClausulaHome());
            _Homes.Add(typeof(TipoModalidad).Name, new TipoModalidadHome());
            _Homes.Add(typeof(TipoPlan).Name, new TipoPlanHome());
        }

        public static LaPapaService Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new LaPapaService();
            }
            return _Instancia;
        }

        public IObjetoCodificadoHome ObtenerHome(string Codigo)
        {
            if (_Homes.Keys.Contains(Codigo))
            {
                return _Homes[Codigo];
            }
            return null;
        }

        public void Persistir(ObjetoCodificado Objeto, string Codigo, string ConectionString)
        {
            string Sql = Objeto.Id == 0 ?
                LaPapaService.Instancia().ObtenerHome(Codigo).InsertQuery(Objeto) :
                LaPapaService.Instancia().ObtenerHome(Codigo).UpdateQuery(Objeto);

            QueryExecutor.Ejecutar(Sql, ConectionString);
        }

        public void Eliminar(ObjetoCodificado Objeto, string Codigo, string ConectionString)
        {
            QueryExecutor.Ejecutar(LaPapaService.Instancia().
                ObtenerHome(Codigo).DeleteQuery(Objeto), ConectionString);
        }

    }
}