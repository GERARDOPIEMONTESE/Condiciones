using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class ClausulaCodigoPaisGrupo : ObjetoPersistido
    {
        private const string NOMBRE = "ICARD.GRUPO_PAIS";

        private int _IdGrupo;

        private int _CodigoPais;

        public int IdGrupo
        {
            get
            {
                return _IdGrupo;
            }
            set
            {
                _IdGrupo = value;
            }
        }

        public int CodigoPais
        {
            get
            {
                return _CodigoPais;
            }
            set
            {
                _CodigoPais = value;
            }
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
