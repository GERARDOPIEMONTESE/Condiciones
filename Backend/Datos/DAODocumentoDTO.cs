using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace BackendCondiciones.Datos
{
    public class DAODocumentoDTO : DAOObjetoPersistido<DocumentoDTO>
    {
        #region Singleton

        private static DAODocumentoDTO _Instancia;

        private DAODocumentoDTO()
        {
        }

        public static DAODocumentoDTO Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAODocumentoDTO();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(DocumentoDTO ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdDocumento"]);
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
            ObjetoPersistido.IdIdioma = Convert.ToInt32(dr["IdIdioma"].ToString());
            ObjetoPersistido.IdTipoDoc= Convert.ToInt32(dr["IdTipoDocumento"].ToString());
        }

        public IList<DocumentoDTO> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.Documento_Tx_BuscarPorParametros"));
        }
    }
}
