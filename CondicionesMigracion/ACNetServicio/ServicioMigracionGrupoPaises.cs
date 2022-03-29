using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using CondicionesMigracion.ACNetDatos;
using FrameworkDAC.Dato;
using System.Configuration;
using Backend.Dominio;
using Backend.Homes;

namespace CondicionesMigracion.ACNetServicio
{
    public class ServicioMigracionGrupoPaises
    {

        #region Singleton

        private static ServicioMigracionGrupoPaises _Instancia;

        private ServicioMigracionGrupoPaises()
        {
        }

        public static ServicioMigracionGrupoPaises Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioMigracionGrupoPaises();
            }
            return _Instancia;
        }

        #endregion

        private string InsertLocacion(ClausulaPaisGrupo Grupo)
        {
            string Sql = "INSERT INTO Locacion.Locacion (IdTipoLocacion, Nombre, IdMonedaImpresion, IdMonedaFacturacion, IdEstado) VALUES(";
            Sql += "10, '" + Grupo.Nombre + "', -1, -1, 25000)";

            return Sql;
        }

        private string InsertLocacionRLocacion(int IdLocacion, int IdLocacionPadre)
        {
            string Sql = "INSERT INTO Locacion.Locacion_R_Locacion (IdLocacion, IdLocacionPadre) VALUES(";
            Sql += IdLocacion + ", " + IdLocacionPadre + ")";

            return Sql;
        }

        private string ExisteLocacionRLocacion(int IdLocacion, int IdLocacionPadre)
        {
            string Sql = "SELECT * FROM Locacion.Locacion_R_Locacion ";
            Sql += "WHERE IdLocacion = " + IdLocacion;
            Sql += "AND IdLocacionPadre = " + IdLocacionPadre;

            return Sql;
        }

        public void Migrar()
        {
            IList<ClausulaPaisGrupo> Grupos = DAOClausulaPaisGrupo.Instancia().Buscar();

            foreach (ClausulaPaisGrupo Grupo in Grupos)
            {
                //Inserto el grupo
                QueryExecutor.Ejecutar(InsertLocacion(Grupo), 
                    ConfigurationManager.ConnectionStrings["Portal"].ToString());

                ValidezTerritorial ValidezTerritorial = ValidezTerritorialHome.Obtener(Grupo.Nombre);

                if (ValidezTerritorial.Id != 0)
                {
                    IList<ClausulaCodigoPaisGrupo> Paises = DAOClausulaCodigoPaisGrupo
                        .Instancia().Buscar(Grupo.Id);

                    foreach (ClausulaCodigoPaisGrupo Pais in Paises)
                    {
                        int IdLocacion = PaisHome.ObtenerPorCodigo(Pais.CodigoPais).IdLocacion;

                        bool Existe = QueryExecutor.Existe(
                            ExisteLocacionRLocacion(IdLocacion, ValidezTerritorial.Id), 
                            ConfigurationManager.ConnectionStrings["Portal"].ToString());

                        if (!Existe && IdLocacion != 0)
                        {
                            QueryExecutor.Ejecutar(
                                InsertLocacionRLocacion(IdLocacion, ValidezTerritorial.Id),
                                ConfigurationManager.ConnectionStrings["Portal"].ToString());
                        }
                    }
                }
            }
        }
    }
}
