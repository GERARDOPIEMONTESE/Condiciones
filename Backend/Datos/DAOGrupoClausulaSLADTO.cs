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
    public class DAOGrupoClausulaSLADTO : DAOObjetoPersistido<GrupoClausulaSLADTO>
    {
        #region Singleton

        private static DAOGrupoClausulaSLADTO _Instancia;

        private DAOGrupoClausulaSLADTO()
        {
        }

        public static DAOGrupoClausulaSLADTO Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOGrupoClausulaSLADTO();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(GrupoClausulaSLADTO ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["Id"]);
            ObjetoPersistido.NombreLocacion = dr["NombreLocacion"].ToString();
            ObjetoPersistido.Agencia = dr["Agencia"].ToString();
            ObjetoPersistido.Sucursal = dr["Sucursal"].ToString();
        }

        public IList<GrupoClausulaSLADTO> Buscar(int IdTipoGrupoClausula, int CodigoPais, string Agencia, int Sucursal)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);

            if (Agencia == null)
                Parametros.AgregarParametro("Agencia", null);
            else
                Parametros.AgregarParametro("Agencia", "%" + Agencia + "%");
            
            Parametros.AgregarParametro("Sucursal", Sucursal);

            return Buscar(new Filtro(Parametros, "dbo.GrupoClausula_SLA_Tx_AgenciaSucursal"));
        }

    }
}
