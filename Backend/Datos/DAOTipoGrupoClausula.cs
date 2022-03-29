using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoGrupoClausula : DAOObjetoCodificado<TipoGrupoClausula>
    {
        #region Singleton

        private static DAOTipoGrupoClausula _Instancia;

        private DAOTipoGrupoClausula()
        {
        }

        public static DAOTipoGrupoClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoGrupoClausula();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoGrupoClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoGrupoClausula"]);
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
        }

        public IList<TipoGrupoClausula> Buscar()
        {
            Filtro Filtro = new Filtro(new Parametros(), "dbo.TipoGrupoClausula_Tx_Nombre");

            return Buscar(Filtro);
        }

        public IList<TipoGrupoClausula> Buscar(string Nombre)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Nombre", Nombre);

            return Buscar(new Filtro(Parametros, "dbo.TipoGrupoClausula_Tx_Nombre"));
        }
    }
}
