using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using Backend.Dominio;
using Backend.DTO;


namespace Backend.Datos
{
    public class DAOGrupoClausulaTarifaDTO : DAOObjetoPersistido<GrupoClausulaTarifaDTO>
    {
        #region Singleton

        private static DAOGrupoClausulaTarifaDTO _Instancia;

        private DAOGrupoClausulaTarifaDTO()
        {
        }

        public static DAOGrupoClausulaTarifaDTO Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOGrupoClausulaTarifaDTO();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(GrupoClausulaTarifaDTO ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["Id"]);
            ObjetoPersistido.NombreTipoGrupoClausula = dr["NombreTipoGrupoClausula"].ToString();
            ObjetoPersistido.NombreLocacion = dr["NombreLocacion"].ToString();
            ObjetoPersistido.NombreTextoResumen = dr["NombreTextoResumen"].ToString();
            ObjetoPersistido.Producto = dr["Producto"].ToString();
            ObjetoPersistido.Tarifa = dr["Tarifa"].ToString();
            ObjetoPersistido.Sufijo = dr["Sufijo"].ToString();
            ObjetoPersistido.Anual = Convert.ToBoolean(dr["Anual"]);
            ObjetoPersistido.TipoModalidad = dr["TipoModalidad"].ToString();
        }

        public IList<GrupoClausulaTarifaDTO> Buscar(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, string Sufijo, string CodigoTarifa)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("Sufijo", Sufijo);
            Parametros.AgregarParametro("CodigoTarifa", CodigoTarifa);
            //Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.GrupoClausula_Tarifa_Tx_Producto"));
        }

        public IList<GrupoClausulaTarifaDTO> Buscar(int IdTipoGrupoClausula, int CodigoPais,
            string CodigoProducto, string Sufijo, string CodigoTarifa)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("CodigoProducto", CodigoProducto);
            Parametros.AgregarParametro("Sufijo", Sufijo);
            Parametros.AgregarParametro("CodigoTarifa", CodigoTarifa);

            return Buscar(new Filtro(Parametros, "dbo.GrupoClausula_Tarifa_Tx_Producto"));
        }

        

    }
}
