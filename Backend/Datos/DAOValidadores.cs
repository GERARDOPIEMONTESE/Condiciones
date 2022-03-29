using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOValidadores : DAOObjetoNegocio<Validadores>
    {
        private static DAOValidadores _Instancia;

        private const string CONNECTIONSTRING = "Condiciones";

        private DAOValidadores()
        {
        }

        public static DAOValidadores Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOValidadores();
            }
            return _Instancia;
        }

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(Validadores objetoNegocio)
        {
            throw new NotImplementedException();
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(Validadores objetoNegocio)
        {
            throw new NotImplementedException();
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(Validadores ObjetoNegocio)
        {
            throw new NotImplementedException();
        }

        protected override void Completar(Validadores ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = (int)dr["IdValidador"];
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.TipoDato = dr["TipoDato"].ToString();
        }

        public IList<Validadores> FindAll()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.Validadores_TT"));
        }

        public IList<Validadores> FindAllVisible()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.Validadores_Tx_Visible"));
        }

        public Validadores FindById(int id)
        {
            Parametros p = new Parametros();
            p.AgregarParametro("IdValidador", id);

            Filtro Filtro = new Filtro(p, "dbo.Validadores_Tx_IdValidador");
            return Obtener(Filtro);
        }
    }
}
