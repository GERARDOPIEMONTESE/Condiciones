using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Parametro;
using FrameworkDAC.Dato;
using FrameworkDAC.Negocio;

namespace Backend.Datos
{
    public class DAOTarifa : DAOObjetoNegocio<Tarifa>
    {
        #region Singleton

        private static DAOTarifa _Instancia;

        private DAOTarifa()
        {
        }

        public static DAOTarifa Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTarifa();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        #region Implemented methods

        protected override void Completar(Tarifa ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTarifa"]);
            ObjetoPersistido.CodigoPais = Convert.ToInt32(dr["CodigoPais"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
            ObjetoPersistido.IdTipoGrupoClausula = Convert.ToInt32(dr["IdTipoGrupoClausula"]);
            ObjetoPersistido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
            ObjetoPersistido.Sufijo = dr["Sufijo"] == null ? null : dr["Sufijo"].ToString();
            ObjetoPersistido.Anual = Convert.ToBoolean(dr["Anual"]);
            ObjetoPersistido.Activa = Convert.ToBoolean(dr["Activa"]);
            ObjetoPersistido.IdTipoModalidad = Convert.ToInt32(dr["IdTipoModalidad"]);
        }

        protected override Parametros ParametrosCrear(Tarifa ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.IdTipoGrupoClausula);
            Parametros.AgregarParametro("IdProducto", ObjetoNegocio.IdProducto);
            Parametros.AgregarParametro("CodigoPais", ObjetoNegocio.CodigoPais);
            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("Sufijo", ObjetoNegocio.Sufijo);
            Parametros.AgregarParametro("Anual", ObjetoNegocio.Anual);
            Parametros.AgregarParametro("Activa", ObjetoNegocio.Activa);
            Parametros.AgregarParametro("IdTipoModalidad", ObjetoNegocio.IdTipoModalidad);

            return Parametros;
        }

        protected override Parametros ParametrosEliminar(Tarifa ObjetoNegocio)
        {
            throw new NotImplementedException();
        }

        protected override Parametros ParametrosModificar(Tarifa ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTarifa", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("Sufijo", ObjetoNegocio.Sufijo);
            Parametros.AgregarParametro("Activa", ObjetoNegocio.Activa);
            Parametros.AgregarParametro("IdTipoModalidad", ObjetoNegocio.IdTipoModalidad);

            return Parametros;
        }

        #endregion

        #region Search methods

        [Obsolete("Menor precision de busqueda ya que busca por codigoPais + codigoProducto. Utilizar el otro Obtener por IdProducto. ")]
        public Tarifa Obtener(int CodigoPais, string CodigoProducto, string Codigo, bool Anual)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("CodigoProducto", CodigoProducto);
            Parametros.AgregarParametro("Codigo", Codigo);
            Parametros.AgregarParametro("Anual", Anual);

            return Obtener(new Filtro(Parametros, "dbo.Tarifa_Tx_Codigo"));
        }

        public Tarifa Obtener(int idProducto, int codigoPais, string codigoTarifa, bool anual)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdProducto", idProducto);
            Parametros.AgregarParametro("CodigoPais", codigoPais);
            Parametros.AgregarParametro("CodigoTarifa", codigoTarifa);
            Parametros.AgregarParametro("Anual", anual);

            return Obtener(new Filtro(Parametros, "dbo.Tarifa_Tx_IdProductoCodigo"));
        }

        public IList<Tarifa> Buscar(int CodigoPais, int IdProducto, bool Anual)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("Anual", Anual);
            //Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());
            
            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_IdProducto");
            return Buscar(Filtro);
        }

        public IList<Tarifa> Buscar(int CodigoPais, int IdProducto, string CodigoTarifa, bool Activa, string sufijo, bool Anual)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("Codigo", CodigoTarifa);
            Parametros.AgregarParametro("Anual", Anual);
            Parametros.AgregarParametro("Activa", Activa);
            //Marce: Le agregue este parametro
            Parametros.AgregarParametro("Sufijo", sufijo);
            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_IdProducto");
            return Buscar(Filtro);
        }

        public IList<Tarifa> Buscar(int CodigoPais, int IdProducto, string CodigoTarifa)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("Codigo", CodigoTarifa);

            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_IdProducto");
            return Buscar(Filtro);
        }

        public IList<Tarifa> BuscarPorGrupo(int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("Sufijo", sufijo);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());
            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_IdProducto_IdGrupoClausula");
            return Buscar(Filtro);
        }

        public IList<Tarifa> Buscar(int CodigoPais, int IdProducto, string CodigoTarifa, int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("Codigo", CodigoTarifa);
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("Sufijo", sufijo);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_IdProducto_Not_Grupo");
            return Buscar(Filtro);
        }

        public IList<Tarifa> Buscar(int CodigoPais, int IdProducto, string CodigoTarifa, int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo, bool Anual)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("Codigo", CodigoTarifa);
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("Anual", Anual);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());
            Parametros.AgregarParametro("Sufijo", sufijo);

            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_IdProducto_Not_Grupo");
            return Buscar(Filtro);
        }

        public IList<Tarifa> Buscar(int CodigoPais, int IdProducto)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);

            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_IdProducto");
            return Buscar(Filtro);
        }

        public IList<Tarifa> Buscar(string CodigoParcial, string SufijoParcial, int Cantidad, int IdProducto)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoParcial", CodigoParcial);
            Parametros.AgregarParametro("SufijoParcial", SufijoParcial);
            Parametros.AgregarParametro("Cantidad", Cantidad);
            Parametros.AgregarParametro("IdProducto", IdProducto);

            Filtro Filtro = new Filtro(Parametros, "dbo.Tarifa_Tx_CodigoParcial");
            return Buscar(Filtro);
        }

        public IList<Tarifa> BuscarObtener(int CodigoPais, string CodigoProducto, string Codigo, bool Anual)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("CodigoProducto", CodigoProducto);
            Parametros.AgregarParametro("Codigo", Codigo);
            Parametros.AgregarParametro("Anual", Anual);

            return Buscar(new Filtro(Parametros, "dbo.Tarifa_Tx_Codigo"));
        }

        #endregion
    }
}
