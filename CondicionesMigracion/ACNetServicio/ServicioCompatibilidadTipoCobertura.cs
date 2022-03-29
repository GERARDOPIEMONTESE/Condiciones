using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesMigracion.ACNetServicio
{
    public class ServicioCompatibilidadTipoCobertura
    {
        #region Singleton

        private static ServicioCompatibilidadTipoCobertura _Instancia;

        private IDictionary<int, string> _Compatibilidades = new Dictionary<int, string>();

        private ServicioCompatibilidadTipoCobertura()
        {
            Inicializar();
        }

        public static ServicioCompatibilidadTipoCobertura Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioCompatibilidadTipoCobertura();
            }

            return _Instancia;
        }

        private void Inicializar()
        {
            _Compatibilidades.Add(0, "NO");
            _Compatibilidades.Add(1, "TAR");
            _Compatibilidades.Add(2, "DIA");
            _Compatibilidades.Add(3, "MES");
            _Compatibilidades.Add(4, "SEM");
            _Compatibilidades.Add(5, "ANIO");
            _Compatibilidades.Add(6, "VIAJ");
            _Compatibilidades.Add(7, "EVEN");
        }

        #endregion

        public string ObtenerCodigo(int IdRate)
        {
            return _Compatibilidades[IdRate];
        }
    }
}
