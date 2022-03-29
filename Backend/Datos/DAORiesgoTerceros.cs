using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAORiesgoTerceros : DAOObjetoNegocio<RiesgoTerceros>
    {
          #region Singleton

        private static DAORiesgoTerceros _Instancia;

        private DAORiesgoTerceros()
        {
        }

        public static DAORiesgoTerceros Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAORiesgoTerceros();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }
        protected override void Completar(RiesgoTerceros ObjetoPersistido,
          System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdRiesgoTerceros"]);
            ObjetoPersistido.IdPais = Convert.ToInt32(dr["IdPais"]);
            ObjetoPersistido.DescripcionPais = dr["DescripcionPais"].ToString();
            ObjetoPersistido.TipoNegocio = dr["TipoNegocio"].ToString();
            if (!string.IsNullOrEmpty(dr["Codigo"].ToString()))
            {
                ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            }
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
            ObjetoPersistido.IdCompaniaSeguro = Convert.ToInt32(dr["IdCompaniaSeguro"]);
            ObjetoPersistido.CompaniaSeguro = dr["CompaniaSeguro"].ToString();
            ObjetoPersistido.Riesgo = dr["Riesgo"].ToString();
            if (!string.IsNullOrEmpty(dr["FechaInicioVigencia"].ToString()))
            {
                ObjetoPersistido.FechaInicioVigencia = Convert.ToDateTime(dr["FechaInicioVigencia"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["FechaFinVigencia"].ToString()))
            {
                ObjetoPersistido.FechaFinVigencia = Convert.ToDateTime(dr["FechaFinVigencia"].ToString());
            }
        }

        protected override Parametros ParametrosCrear(RiesgoTerceros ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdPais", ObjetoNegocio.IdPais);
            Parametros.AgregarParametro("DescripcionPais", ObjetoNegocio.DescripcionPais);
            Parametros.AgregarParametro("TipoNegocio", ObjetoNegocio.TipoNegocio);
            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("Descripcion", ObjetoNegocio.Descripcion);
            Parametros.AgregarParametro("IdCompaniaSeguro", ObjetoNegocio.IdCompaniaSeguro);
            Parametros.AgregarParametro("CompaniaSeguro", ObjetoNegocio.CompaniaSeguro);
            Parametros.AgregarParametro("Riesgo", ObjetoNegocio.Riesgo);
            Parametros.AgregarParametro("FechaInicioVigencia", ObjetoNegocio.FechaInicioVigencia);
            Parametros.AgregarParametro("FechaFinVigencia", ObjetoNegocio.FechaFinVigencia);
            Parametros.AgregarParametro("IdEstado", 25000);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);

            return Parametros;
        }

        protected override Parametros ParametrosEliminar(RiesgoTerceros ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdRiesgoTerceros", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", 25002);

            return Parametros;
        }

        protected override Parametros ParametrosModificar(RiesgoTerceros ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdRiesgoTerceros", ObjetoNegocio.Id);
            Parametros.AgregarParametro("FechaInicioVigencia", ObjetoNegocio.FechaInicioVigencia);
            Parametros.AgregarParametro("FechaFinVigencia", ObjetoNegocio.FechaFinVigencia);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", 25001);
            return Parametros;
        }
        protected override Parametros ParametrosGrabarLog(RiesgoTerceros ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdPais", ObjetoNegocio.IdPais);
            Parametros.AgregarParametro("DescripcionPais", ObjetoNegocio.DescripcionPais);
            Parametros.AgregarParametro("TipoNegocio", ObjetoNegocio.TipoNegocio);
            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("Descripcion", ObjetoNegocio.Descripcion);
            Parametros.AgregarParametro("IdCompaniaSeguro", ObjetoNegocio.IdCompaniaSeguro);
            Parametros.AgregarParametro("CompaniaSeguro", ObjetoNegocio.CompaniaSeguro);
            Parametros.AgregarParametro("Riesgo", ObjetoNegocio.Riesgo);
            Parametros.AgregarParametro("FechaInicioVigencia", ObjetoNegocio.FechaInicioVigencia);
            Parametros.AgregarParametro("FechaFinVigencia", ObjetoNegocio.FechaFinVigencia);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);

            return Parametros;
        }
        public IList<RiesgoTerceros> Buscar(int Idpais, string TipoNegocio, int? IdCompaniaSeguro)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdPais", Idpais);
            Parametros.AgregarParametro("TipoNegocio", TipoNegocio);
            Parametros.AgregarParametro("IdCompaniaSeguro", IdCompaniaSeguro);
            return Buscar(new Filtro(Parametros, "dbo.RiesgoTerceros_Tx_Filtro"));
        }

        public RiesgoTerceros Obtener(int Id)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdRiesgoTerceros", Id);
            return Obtener(new Filtro(Parametros, "dbo.RiesgoTerceros_Tx_IdRiesgoTerceros"));
        }

        public RiesgoTerceros SearchByIdCompania(int Id)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdCompaniaSeguro", Id);
            return Obtener(new Filtro(Parametros, "dbo.RiesgoTerceros_Tx_IdCompaniaSeguro"));
        }
    }
}
