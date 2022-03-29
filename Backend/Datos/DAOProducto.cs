using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOProducto : DAOObjetoNegocio<Producto>
    {
        #region Singleton

        private static DAOProducto _Instancia;

        private DAOProducto()
        {
        }

        public static DAOProducto Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOProducto();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }
        
        protected override void Completar(Producto ObjetoPersistido, 
            System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdProducto"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
            ObjetoPersistido.IdTipoGrupoClausula = Convert.ToInt32(dr["IdTipoGrupoClausula"]);
            ObjetoPersistido.CodigoPais = Convert.ToInt32(dr["CodigoPais"]);
        }

        public IList<Producto> Buscar(int CodigoPais)
        {
            return Buscar(CodigoPais, 0);
        }

        public IList<Producto> Buscar(int CodigoPais, int IdTipoGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro(new Parametro("CodigoPais", CodigoPais));
            Parametros.AgregarParametro(new Parametro("IdTipoGrupoClausula", IdTipoGrupoClausula));

            Filtro Filtro = new Filtro(Parametros, "dbo.Producto_Tx_CodigoPais");
            return Buscar(Filtro);
        }

        public IList<Producto> BuscarOrdenadoNombre(int CodigoPais, int IdTipoGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro(new Parametro("CodigoPais", CodigoPais));
            Parametros.AgregarParametro(new Parametro("IdTipoGrupoClausula", IdTipoGrupoClausula));

            Filtro Filtro = new Filtro(Parametros, "dbo.Producto_Tx_CodigoPais_Ordenado");
            return Buscar(Filtro);
        }

        public IList<Producto> BuscarPorTipo(int IdTipoGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);

            return Buscar(new Filtro(Parametros, "dbo.Producto_Tx_IdTipoGrupoClausula"));
        }

        public Producto Obtener(int IdTipoGrupoClausula, string Codigo, int CodigoPais)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("Codigo", Codigo);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);

            return Obtener(new Filtro(Parametros, "dbo.Producto_Tx_Codigo"));
        }

        public Producto Obtener(string Codigo, int CodigoPais)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);

            return Obtener(new Filtro(Parametros, "dbo.Producto_Tx_Codigo"));
        }

        public Producto Obtener(string Codigo, int CodigoPais, int IdTipoGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);

            return Obtener(new Filtro(Parametros, "dbo.Producto_Tx_Codigo"));
        }

        #region Persistencia - Para Migracion

        protected override Parametros ParametrosCrear(Producto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", ObjetoNegocio.CodigoPais);

            return Parametros;
        }

        protected override Parametros ParametrosEliminar(Producto ObjetoNegocio)
        {
            throw new NotImplementedException();
        }

        protected override Parametros ParametrosModificar(Producto ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdProducto", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Codigo", ObjetoNegocio.Codigo);
            Parametros.AgregarParametro("Nombre", ObjetoNegocio.Nombre);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", ObjetoNegocio.CodigoPais);

            return Parametros;
        }

        #endregion
    }
}
