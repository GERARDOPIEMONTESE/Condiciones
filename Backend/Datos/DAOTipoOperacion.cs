using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoOperacion : DAOObjetoNegocio<TipoOperacion>
    {
        #region Singleton

        private static DAOTipoOperacion _Instancia;

        private DAOTipoOperacion()
        {
        }

        public static DAOTipoOperacion Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoOperacion();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(TipoOperacion ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("Descripcion", ObjetoNegocio.Descripcion );
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(TipoOperacion ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTipoOperacion", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("Descripcion", ObjetoNegocio.Descripcion);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(TipoOperacion ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTipoOperacion", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }



        protected override void Completar(TipoOperacion ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoOperacion"]);
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"]);
            ObjetoPersistido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
        }

        public IList<TipoOperacion> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoOperacion_TT"));
        }

    }
}
