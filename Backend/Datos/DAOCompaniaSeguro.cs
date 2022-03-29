using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOCompaniaSeguro : DAOObjetoNegocio<CompaniaSeguro>
    {
          #region Singleton

        private static DAOCompaniaSeguro _Instancia;

        private DAOCompaniaSeguro()
        {
        }

        public static DAOCompaniaSeguro Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOCompaniaSeguro();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }
        protected override void Completar(CompaniaSeguro ObjetoPersistido,
          System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdCompania"]);
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        protected override Parametros ParametrosCrear(CompaniaSeguro ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("Descripcion", ObjetoNegocio.Descripcion);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", 25000);
            return Parametros;
        }

        protected override Parametros ParametrosEliminar(CompaniaSeguro ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdCompania", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", 25002);
            return Parametros;
        }

        protected override Parametros ParametrosModificar(CompaniaSeguro ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdCompania", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Descripcion", ObjetoNegocio.Descripcion);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", 25001);
            return Parametros;
        }
        protected override Parametros ParametrosGrabarLog(CompaniaSeguro ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdCompania", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Descripcion", ObjetoNegocio.Descripcion);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }
        public IList<CompaniaSeguro> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.CompaniaSeguro_TT"));
        }

        public  CompaniaSeguro Obtener(int IDCompaniaSeguro)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdCompania", IDCompaniaSeguro);

            return Obtener(new Filtro(Parametros, "dbo.CompaniaSeguro_Tx_IdCompaniaSeguro"));
        }
    }
}
