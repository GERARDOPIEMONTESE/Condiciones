using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class ClausulaTarifaGrupo : ObjetoPersistido
    {
        private const string NOMBRE = "CLAUSULA_TARIFA_GRUPO";

        public const string PRODUCTO = "PRODUCTO";

        public const string UPGRADE = "UPGRADE";

        public const string ANUAL = "365";

        #region Atributos

        private int _Pais;

        private string _Producto;

        private string _Tarifa;

        private string _CantidadDias;

        private int _IdGrupo;

        private string _Sufijo;

        private int _IdTextoVoucher;

        private string _Discriminador;

        private int _Categoria;

        private int _TarifaPlanFamiliar;

        #endregion

        #region Propiedades

        public int Pais
        {
            get
            {
                return _Pais;
            }
            set
            {
                _Pais = value;
            }
        }

        public string Producto
        {
            get
            {
                return _Producto;
            }
            set
            {
                _Producto = value;
            }
        }

        public string Tarifa
        {
            get
            {
                return _Tarifa;
            }
            set
            {
                _Tarifa = value;
            }
        }

        public string CantidadDias
        {
            get
            {
                return _CantidadDias;
            }
            set
            {
                _CantidadDias = value;
            }
        }

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

        public string Sufijo
        {
            get
            {
                return _Sufijo;
            }
            set
            {
                _Sufijo = value;
            }
        }

        public int IdTextoVoucher
        {
            get
            {
                return _IdTextoVoucher;
            }
            set
            {
                _IdTextoVoucher = value;
            }
        }

        public string Discriminador
        {
            get
            {
                return _Discriminador;
            }
            set
            {
                _Discriminador = value;
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

        public int TarifaPlanFamiliar
        {
            get
            {
                return _TarifaPlanFamiliar;
            }
            set
            {
                _TarifaPlanFamiliar = value;
            }
        }

        public bool Anual
        {
            get
            {
                return ANUAL.Equals(CantidadDias);
            }
        }

        #endregion 

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
