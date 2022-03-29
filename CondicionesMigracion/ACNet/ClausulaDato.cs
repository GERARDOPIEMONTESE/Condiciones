using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using CondicionesMigracion.ACNetDatos;

namespace CondicionesMigracion.ACNet
{
    public class ClausulaDato : ObjetoPersistido
    {
        private const string NOMBRE = "CLAUSULA_DATO";

        public const string DIAS_CONSECUTIVOS_INTERNACIONAL = "C.5.4.1";

        public const string DIAS_CONSECUTIVOS_NACIONAL = "C.5.4.2";

        #region Atributos

        private int _IdGrupo;

        private string _IdClausula;

        private int _PosicionRegistro;

        private int _Edad1;

        private int _Edad2;

        private int _Posicion;

        private string _Formato;

        private int _Dias;
        
        private int _IdTexto;

        private string _Moneda;

        private int _Valor;

        private string _ClausulaAsociada;

        private string _Area;

        private string _Destinado;

        private int _MontoDeducible;

        private int _Huespedes;

        private string _UnidadMedicion;

        private int _ValorCompuesto;

        private string _Rubro;

        private int _Condicional;

        private string _InformacionAdicional;

        private string _Seguros;

        private int _Consultas;

        private int _VigenciaCompleta;

        private int _Adicional;

        private int _Bultos;

        private int _EdadA;

        private int _EdadB;

        private int _CondicionEdad;

        private int _LimiteTerritorial;

        private int _ValorTope;

        private int _PorcentajeAntes;

        private int _PorcentajeDespues;

        private int _ReferenciaPolizas;

        private int _PosicionFormato;

        private int _IdRate;

        private string _ClausulasDependencias;

        private string _ZonasVigencia;

        private int _EventosAnioGf;

        private string _EsNacional;

        private int _Categoria;

        #endregion

        #region Propiedades

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

        public string IdClausula
        {
            get
            {
                return _IdClausula;
            }
            set
            {
                _IdClausula = value;
            }
        }

        public int PosicionRegistro
        {
            get
            {
                return _PosicionRegistro;
            }
            set
            {
                _PosicionRegistro = value;
            }
        }

        public int Edad1
        {
            get
            {
                return _Edad1;
            }
            set
            {
                _Edad1 = value;
            }
        }

        public int Edad2
        {
            get
            {
                return _Edad2;
            }
            set
            {
                _Edad2 = value;
            }
        }
        
        public int Posicion
        {
            get
            {
                return _Posicion;
            }
            set
            {
                _Posicion = value;
            }
        }

        public string Formato
        {
            get
            {
                return _Formato;
            }
            set
            {
                _Formato = value;
            }
        }

        public int Dias
        {
            get
            {
                return _Dias;
            }
            set
            {
                _Dias = value;
            }
        }

        public int IdTexto 
        {
            get
            {
                return _IdTexto;
            }
            set
            {
                _IdTexto = value;
            }
        }

        public string Moneda
        {
            get
            {
                return _Moneda;
            }
            set
            {
                _Moneda = value;
            }
        }

        public int Valor
        {
            get
            {
                return _Valor;
            }
            set
            {
                _Valor = value;
            }
        }

        public string ClausulaAsociada
        {
            get
            {
                return _ClausulaAsociada;
            }
            set
            {
                _ClausulaAsociada = value;
            }
        }

        public string Area
        {
            get
            {
                return _Area;
            }
            set
            {
                _Area = value;
            }
        }

        public string Destinado
        {
            get
            {
                return _Destinado;
            }
            set
            {
                _Destinado = value;
            }
        }

        public int MontoDeducible
        {
            get
            {
                return _MontoDeducible;
            }
            set
            {
                _MontoDeducible = value;
            }
        }

        public int Huespedes
        {
            get
            {
                return _Huespedes;
            }
            set
            {
                _Huespedes = value;
            }
        }

        public string UnidadMedicion
        {
            get
            {
                return _UnidadMedicion;
            }
            set
            {
                _UnidadMedicion = value;
            }
        }

        public int ValorCompuesto
        {
            get
            {
                return _ValorCompuesto;
            }
            set
            {
                _ValorCompuesto = value;
            }
        }

        public string Rubro
        {
            get
            {
                return _Rubro;
            }
            set
            {
                _Rubro = value;
            }
        }

        public int Condicional
        {
            get
            {
                return _Condicional;
            }
            set
            {
                _Condicional = value;
            }
        }

        public string InformacionAdicional
        {
            get
            {
                return _InformacionAdicional;
            }
            set
            {
                _InformacionAdicional = value;
            }
        }

        public string Seguros
        {
            get
            {
                return _Seguros;
            }
            set
            {
                _Seguros = value;
            }
        }

        public int Consultas
        {
            get
            {
                return _Consultas;
            }
            set
            {
                _Consultas = value;
            }
        }

        public int VigenciaCompleta
        {
            get
            {
                return _VigenciaCompleta;
            }
            set
            {
                _VigenciaCompleta = value;
            }
        }

        public int Adicional
        {
            get
            {
                return _Adicional;
            }
            set
            {
                _Adicional = value;
            }
        }

        public int Bultos
        {
            get
            {
                return _Bultos;
            }
            set
            {
                _Bultos = value;
            }
        }

        public int EdadA
        {
            get
            {
                return _EdadA;
            }
            set
            {
                _EdadA = value;
            }
        }

        public int EdadB
        {
            get
            {
                return _EdadB;
            }
            set
            {
                _EdadB = value;
            }
        }

        public int CondicionEdad
        {
            get
            {
                return _CondicionEdad;
            }
            set
            {
                _CondicionEdad = value;
            }
        }

        public int LimiteTerritorial
        {
            get
            {
                return _LimiteTerritorial;
            }
            set
            {
                _LimiteTerritorial = value;
            }
        }

        public int ValorTope
        {
            get
            {
                return _ValorTope;
            }
            set
            {
                _ValorTope = value;
            }
        }

        public int PorcentajeAntes
        {
            get
            {
                return _PorcentajeAntes;
            }
            set
            {
                _PorcentajeAntes = value;
            }
        }

        public int PorcentajeDespues
        {
            get
            {
                return _PorcentajeDespues;
            }
            set
            {
                _PorcentajeDespues = value;
            }
        }

        public int ReferenciaPolizas
        {
            get
            {
                return _ReferenciaPolizas;
            }
            set
            {
                _ReferenciaPolizas = value;
            }
        }

        public int PosicionFormato
        {
            get
            {
                return _PosicionFormato;
            }
            set
            {
                _PosicionFormato = value;
            }
        }

        public int IdRate
        {
            get
            {
                return _IdRate;
            }
            set
            {
                _IdRate = value;
            }
        }

        public string ClausulasDependencias
        {
            get
            {
                return _ClausulasDependencias;
            }
            set
            {
                _ClausulasDependencias = value;
            }
        }

        public string ZonasVigencia
        {
            get
            {
                return _ZonasVigencia;
            }
            set
            {
                _ZonasVigencia = value;
            }
        }

        public int EventosAnioGf
        {
            get
            {
                return _EventosAnioGf;
            }
            set
            {
                _EventosAnioGf = value;
            }
        }

        public string EsNacional
        {
            get
            {
                return _EsNacional;
            }
            set
            {
                _EsNacional = value;
            }
        }

        public int Categoria
        {
            get
            {
                return _Categoria;
            }
            set
            {
                _Categoria = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public ClausulaTarifaGrupo ObtenerGrupo()
        {
            return DAOClausulaTarifaGrupo.Instancia().Buscar(IdGrupo)[0];
        }
    }
}
