using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOAyuda : DAOObjetoPersistido<Ayuda>
    {
        #region Singleton

        private static DAOAyuda _Instancia;

        private DAOAyuda()
        {
        }

        public static DAOAyuda Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOAyuda();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(Ayuda ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdAyuda"]);
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        public IList<Ayuda> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.Ayuda_Tx_Nombre"));
        }
    }
}
