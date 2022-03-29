using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;
using System.Data.OracleClient;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOClausulaTarifaGrupo : DAOObjetoPersistido<ClausulaTarifaGrupo>
    {
        #region Singleton

        private static DAOClausulaTarifaGrupo _Instancia;

        private DAOClausulaTarifaGrupo()
        {
        }

        public static DAOClausulaTarifaGrupo Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausulaTarifaGrupo();
            }
            return _Instancia;
        }

        #endregion

        //private const string TODOS = "SELECT * FROM ICARD.CLAUSULA_TARIFA_GRUPO CTG WHERE CTG.FECHA_BAJA IS NULL AND EXISTS (SELECT 1 FROM ICARD.CLAUSULA_DATO CD WHERE CD.ID_GRUPO = CTG.ID_GRUPO AND CD.FORMATO IN ('ESAGSI','ESDMV2','ESEDR2','ESEDRM','ESEDSO','ESEVMV','ESEVMZ','ESHMIA','ESHMVS','ESINCL','ESMVCO','ESMVIA','ESMVIC','ESMVID','ESMVIH','ESMVSI','ESRRSI','INDMV2','INEDRM','INHMVS','ININCL','INMVIC','ISTEXT','PODMV2','POEDRM','POHMVS','POINCL','POMVIC'))";
        private const string TODOS = "SELECT * FROM ICARD.CLAUSULA_TARIFA_GRUPO CTG WHERE CTG.FECHA_BAJA IS NULL AND TARIFA_PLAN_FAMILIAR = 0 ";

        private const string PRIMER_GRUPO_UPGRADE = "SELECT DISTINCT MIN(ID_GRUPO) ID_GRUPO, PAIS, PRODUCTO, TARIFA, CANT_DIAS, '' SUFIJO, 0 ID_TEXTO_VOUCHER, 'UPGRADE' DISCRIMINADOR, 0 CATEGORIA, 0 TARIFA_PLAN_FAMILIAR FROM ICARD.CLAUSULA_TARIFA_GRUPO WHERE FECHA_BAJA IS NULL AND DISCRIMINADOR = 'UPGRADE' GROUP BY PAIS, PRODUCTO, TARIFA, CANT_DIAS";

        private const string POR_ID_GRUPO = "SELECT * FROM ICARD.CLAUSULA_TARIFA_GRUPO WHERE FECHA_BAJA IS NULL AND ID_GRUPO = ";

        private const string POR_PARAMETROS = "SELECT * FROM ICARD.CLAUSULA_TARIFA_GRUPO WHERE FECHA_BAJA IS NULL ";

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ClausulaTarifaGrupo ObjetoPersistido, OracleDataReader dr)
        {
            ObjetoPersistido.Pais = Convert.ToInt32(dr["PAIS"]);
            ObjetoPersistido.Producto = dr["PRODUCTO"].ToString();
            ObjetoPersistido.Tarifa = dr["TARIFA"].ToString();
            ObjetoPersistido.CantidadDias = dr["CANT_DIAS"].ToString();
            ObjetoPersistido.IdGrupo = Convert.ToInt32(dr["ID_GRUPO"]);
            ObjetoPersistido.Sufijo = dr["SUFIJO"].ToString();
            ObjetoPersistido.IdTextoVoucher = DBNull.Value.Equals(dr["ID_TEXTO_VOUCHER"]) ? 
                0 : Convert.ToInt32(dr["ID_TEXTO_VOUCHER"]);
            ObjetoPersistido.Discriminador = dr["DISCRIMINADOR"].ToString();
            ObjetoPersistido.Categoria = Convert.ToInt32(dr["CATEGORIA"]);
            ObjetoPersistido.TarifaPlanFamiliar = Convert.ToInt32(dr["TARIFA_PLAN_FAMILIAR"]);
        }

        private string AgregarDiscriminador(string Discriminador)
        {
            return " AND DISCRIMINADOR = '" + Discriminador + "' ";
        }

        private string AgregarPais(int Pais)
        {
            return " AND PAIS = " + Pais + " ";
        }

        private string AgregarProducto(string Producto)
        {
            return " AND PRODUCTO = '" + Producto + "' ";
        }

        private string AgregarTarifa(string Tarifa)
        {
            return " AND TARIFA = '" + Tarifa + "' ";
        }

        private string AgregarCantidadDias(string CantidadDias)
        {
            return " AND CANT_DIAS = '" + CantidadDias + "' ";
        }

        protected override void Completar(ClausulaTarifaGrupo ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        public IList<ClausulaTarifaGrupo> Buscar(string Discriminador)
        {
            return BuscarOracle(TODOS + AgregarDiscriminador(Discriminador));
        }

        public IList<ClausulaTarifaGrupo> Buscar(int IdGrupo, string Discriminador)
        {
            return BuscarOracle(POR_ID_GRUPO + IdGrupo + AgregarDiscriminador(Discriminador));
        }

        public IList<ClausulaTarifaGrupo> Buscar(int IdGrupo)
        {
            return BuscarOracle(POR_ID_GRUPO + IdGrupo);
        }

        public IList<ClausulaTarifaGrupo> Buscar(int Pais, string Producto, string Tarifa, string CantidadDias, string Discriminador)
        {
            return BuscarOracle(POR_PARAMETROS + AgregarPais(Pais) 
                + AgregarProducto(Producto) + AgregarTarifa(Tarifa)
                + AgregarCantidadDias(CantidadDias) + AgregarDiscriminador(Discriminador));
        }

        public IList<int> BuscarIds(string Discriminador)
        {
            IList<int> Ids = new List<int>();

            IList<ClausulaTarifaGrupo> Grupos = Buscar(Discriminador);

            foreach (ClausulaTarifaGrupo Grupo in Grupos)
            {
                if (!Ids.Contains(Grupo.IdGrupo))
                {
                    Ids.Add(Grupo.IdGrupo);
                }                
            }

            return Ids;
        }

        public IList<ClausulaTarifaGrupo> BuscarGruposUpgrades()
        {
            return BuscarOracle(PRIMER_GRUPO_UPGRADE);
        }
    }
}
