using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendCondiciones.DTO
{
    class ClausulaImpresaDTO
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string TipoImpresion { get; set; }

        public ClausulaImpresaDTO() { }

    }
}
