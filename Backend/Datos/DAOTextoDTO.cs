using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using System.Transactions;
using FrameworkDAC.Negocio;
using Backend.DTO;

namespace Backend.Datos
{
    public class DAOTextoDTO : DAOObjetoPersistido<TextoDTO>
    {
        #region Singleton

        private static DAOTextoDTO _Instancia;

        private DAOTextoDTO()
        {
        }

        public static DAOTextoDTO Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTextoDTO();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TextoDTO ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTexto"]);
            ObjetoPersistido.IdIdioma = Convert.ToInt32(dr["IdIdioma"]);
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
            ObjetoPersistido.Texto = dr["Texto"].ToString();
        }

        public IList<TextoDTO> Buscar(string Nombre, int IdTipoTexto, int IdIdioma)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Nombre", Nombre);
            Parametros.AgregarParametro("IdTipoTexto", IdTipoTexto);
            Parametros.AgregarParametro("IdIdioma", IdIdioma);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.Texto_R_Idioma_Parametros"));
        }
    }
}
