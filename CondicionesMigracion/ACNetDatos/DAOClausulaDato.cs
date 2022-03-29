using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOClausulaDato : DAOObjetoPersistido<ClausulaDato>
    {
        //private const string GENERAL = "SELECT CLAUSULA_DATO.*, (SELECT CATEGORIA FROM ICARD.CLAUSULA_TARIFA_GRUPO CTG WHERE CTG.ID_GRUPO = ICARD.CLAUSULA_DATO.ID_GRUPO AND ROWNUM = 1) CATEGORIA FROM ICARD.CLAUSULA_DATO WHERE 1 = 1";
        private const string GENERAL = "SELECT * FROM ICARD.CLAUSULA_DATO WHERE 1 = 1";

        #region Singleton

        private static DAOClausulaDato _Instancia;

        private DAOClausulaDato()
        {
        }

        public static DAOClausulaDato Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausulaDato();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ClausulaDato ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        protected override void Completar(ClausulaDato ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.IdGrupo = Convert.ToInt32(dr["ID_GRUPO"]);
            ObjetoPersistido.IdClausula = dr["ID_CLAUSULA"].ToString();
            ObjetoPersistido.PosicionRegistro = Convert.ToInt32(dr["POSICION_REGISTRO"]);
            ObjetoPersistido.Edad1 = DBNull.Value.Equals(dr["EDAD1"]) ? 
                0 : Convert.ToInt32(dr["EDAD1"]);
            ObjetoPersistido.Edad2 = DBNull.Value.Equals(dr["EDAD2"]) ? 
                0 : Convert.ToInt32(dr["EDAD2"]);
            ObjetoPersistido.Formato = dr["FORMATO"].ToString();
            ObjetoPersistido.Posicion = DBNull.Value.Equals(dr["POSICION"]) ? 
                0 :Convert.ToInt32(dr["POSICION"]);
            ObjetoPersistido.IdTexto = DBNull.Value.Equals(dr["ID_TEXTO"]) ? 
                0 : Convert.ToInt32(dr["ID_TEXTO"]);
            ObjetoPersistido.Moneda = DBNull.Value.Equals(dr["MONEDA"]) ? 
                "" : dr["MONEDA"].ToString();
            ObjetoPersistido.Valor = DBNull.Value.Equals(dr["VALOR"]) ? 
                0 :Convert.ToInt32(dr["VALOR"]);
            ObjetoPersistido.ClausulaAsociada = DBNull.Value.Equals(dr["CLAUSULA_ASOCIADA"]) ? 
                "" : dr["CLAUSULA_ASOCIADA"].ToString();
            ObjetoPersistido.Area = DBNull.Value.Equals(dr["AREA"]) ? 
                "" : dr["AREA"].ToString();
            ObjetoPersistido.Destinado = DBNull.Value.Equals(dr["DESTINADO"]) ? 
                "" : dr["DESTINADO"].ToString();
            ObjetoPersistido.MontoDeducible = DBNull.Value.Equals(dr["MONTOS_DEDUCIBLES"]) ? 
                0 :Convert.ToInt32(dr["MONTOS_DEDUCIBLES"]);
            ObjetoPersistido.Huespedes = DBNull.Value.Equals(dr["HUESPEDES"]) ? 
                0 :Convert.ToInt32(dr["HUESPEDES"]);
            ObjetoPersistido.Dias = DBNull.Value.Equals(dr["DIAS"]) ?
                0 : Convert.ToInt32(dr["DIAS"]);
            ObjetoPersistido.InformacionAdicional = DBNull.Value.Equals(dr["INFORMACION_ADICIONAL"]) ?
                "" : dr["INFORMACION_ADICIONAL"].ToString();
            ObjetoPersistido.UnidadMedicion = DBNull.Value.Equals(dr["UNIDAD_MEDICION"]) ?
                "" : dr["UNIDAD_MEDICION"].ToString();
            ObjetoPersistido.ValorCompuesto = DBNull.Value.Equals(dr["VALOR_COMPUESTO"]) ?
                0 : Convert.ToInt32(dr["VALOR_COMPUESTO"]);
            ObjetoPersistido.Rubro = DBNull.Value.Equals(dr["RUBRO"]) ?
                "" : dr["RUBRO"].ToString();
            ObjetoPersistido.Condicional = DBNull.Value.Equals(dr["CONDICIONAL"]) ?
                0 : Convert.ToInt32(dr["CONDICIONAL"]);
            ObjetoPersistido.Seguros = DBNull.Value.Equals(dr["SEGUROS"]) ?
                "" : dr["SEGUROS"].ToString();
            ObjetoPersistido.Consultas = DBNull.Value.Equals(dr["CONSULTAS"]) ?
                0 : Convert.ToInt32(dr["CONSULTAS"]);
            ObjetoPersistido.VigenciaCompleta = DBNull.Value.Equals(dr["VIGENCIA_COMPLETA"]) ?
                0 : Convert.ToInt32(dr["VIGENCIA_COMPLETA"]);
            ObjetoPersistido.Adicional = DBNull.Value.Equals(dr["ADICIONAL"]) ?
                0 : Convert.ToInt32(dr["ADICIONAL"]);
            ObjetoPersistido.Bultos = DBNull.Value.Equals(dr["BULTOS"]) ?
                0 : Convert.ToInt32(dr["BULTOS"]);
            ObjetoPersistido.EdadA = DBNull.Value.Equals(dr["EDADA"]) ?
                0 : Convert.ToInt32(dr["EDADA"]);
            ObjetoPersistido.EdadB = DBNull.Value.Equals(dr["EDADB"]) ?
                0 : Convert.ToInt32(dr["EDADB"]);
            ObjetoPersistido.CondicionEdad = DBNull.Value.Equals(dr["CONDICION_EDAD"]) ?
                0 : Convert.ToInt32(dr["CONDICION_EDAD"]);
            ObjetoPersistido.LimiteTerritorial = DBNull.Value.Equals(dr["LIMITE_TERRITORIAL"]) ?
                0 : Convert.ToInt32(dr["LIMITE_TERRITORIAL"]);
            ObjetoPersistido.ValorTope = DBNull.Value.Equals(dr["VALOR_TOPE"]) ?
                0 : Convert.ToInt32(dr["VALOR_TOPE"]);
            ObjetoPersistido.PorcentajeAntes = DBNull.Value.Equals(dr["PORCENTAJE_ANTES"]) ?
                0 : Convert.ToInt32(dr["PORCENTAJE_ANTES"]);
            ObjetoPersistido.PorcentajeDespues = DBNull.Value.Equals(dr["PORCENTAJE_DESPUES"]) ?
                0 : Convert.ToInt32(dr["PORCENTAJE_DESPUES"]);
            ObjetoPersistido.ReferenciaPolizas = DBNull.Value.Equals(dr["REFERENCIA_POLIZAS"]) ?
                0 : Convert.ToInt32(dr["REFERENCIA_POLIZAS"]);
            ObjetoPersistido.PosicionFormato = DBNull.Value.Equals(dr["POSICION_FORMATO"]) ?
                0 : Convert.ToInt32(dr["POSICION_FORMATO"]);
            ObjetoPersistido.IdRate = DBNull.Value.Equals(dr["ID_RATE"]) ?
                0 : Convert.ToInt32(dr["ID_RATE"]);
            ObjetoPersistido.EventosAnioGf = DBNull.Value.Equals(dr["EVENTOS_ANIO_GF"]) ?
                0 : Convert.ToInt32(dr["EVENTOS_ANIO_GF"]);
            ObjetoPersistido.ClausulasDependencias = DBNull.Value.Equals(dr["CLAUSULAS_DEPENDENCIAS"]) ?
                "" : dr["CLAUSULAS_DEPENDENCIAS"].ToString();
            ObjetoPersistido.ZonasVigencia = DBNull.Value.Equals(dr["ZONAS_VIGENCIA"]) ?
                "" : dr["ZONAS_VIGENCIA"].ToString();
            ObjetoPersistido.EsNacional = DBNull.Value.Equals(dr["ES_NACIONAL"]) ?
                "" : dr["ES_NACIONAL"].ToString();
            //ObjetoPersistido.Categoria = DBNull.Value.Equals(dr["CATEGORIA"]) ?
            //    0 : Convert.ToInt32(dr["CATEGORIA"]);
        }

        private string ObtenerIdGrupo(int IdGrupo)
        {
            return " AND ID_GRUPO = " + IdGrupo + " ";
        }

        private string ObtenerIdClausula(string IdClausula)
        {
            return " AND ID_CLAUSULA = '" + IdClausula + "' ";
        }

        private string ObtenerOrderBy(string Campo)
        {
            return " ORDER BY " + Campo;
        }

        public ClausulaDato Obtener(int IdGrupo, string IdClausula)
        {
            return ObtenerOracle(GENERAL + ObtenerIdGrupo(IdGrupo) + 
                ObtenerIdClausula(IdClausula), false);
        }

        public IList<ClausulaDato> Buscar(int IdGrupo)
        {
            return BuscarOracle(GENERAL + 
                ObtenerIdGrupo(IdGrupo) + ObtenerOrderBy("ID_CLAUSULA, POSICION"));
        }

        public IList<ClausulaDato> Buscar(IList<ClausulaTarifaGrupo> Grupos)
        {
            IList<ClausulaDato> Datos = new List<ClausulaDato>();

            foreach (ClausulaTarifaGrupo Grupo in Grupos)
            {
                IList<ClausulaDato> DatosGrupo = BuscarOracle(GENERAL +
                    ObtenerIdGrupo(Grupo.IdGrupo) + ObtenerOrderBy("ID_CLAUSULA, POSICION"));
                foreach (ClausulaDato Dato in DatosGrupo)
                {
                    Datos.Add(Dato);
                }
            }
            return Datos;
        }

    }
}
