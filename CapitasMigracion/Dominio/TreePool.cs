using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace CapitasMigracion.Dominio
{
    public class TreePool : ObjetoPersistido
    {
        private const string NOMBRE = "ACCGGTreePool";

        #region Atributos

        private string _ParametersToEvaluate;

        private int _CountryCode;
        
        private int _IdPlan;

        private int _IdBusiness;

        private IList<Pool> _Pools = new List<Pool>();

        #endregion

        #region Propiedades

        public string ParametersToEvaluate
        {
            get
            {
                return _ParametersToEvaluate;
            }
            set
            {
                _ParametersToEvaluate = value;
            }
        }

        public int CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        public int IdPlan
        {
            get
            {
                return _IdPlan;
            }
            set
            {
                _IdPlan = value;
            }
        }

        public int IdBusiness
        {
            get
            {
                return _IdBusiness;
            }
            set
            {
                _IdBusiness = value;
            }
        }

        public IList<Pool> Pools
        {
            get
            {
                return _Pools;
            }
            set
            {
                _Pools = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public ArrayList ObtenerListado()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(ArrayList));

                return (ArrayList)xs.Deserialize(new StringReader(ParametersToEvaluate));
            }
            catch (Exception)
            {
                return new ArrayList();
            }
        }

        public int EdadMinima()
        {
            ArrayList Listado = new ArrayList(ObtenerListado());

            int Edad = 0;

            if (Listado.Count >= 6)
            {
                return (int)Listado[3];
            }

            if (Listado.Count >= 3)
            {
                Int32.TryParse(Listado[2].ToString(), out Edad);
            }

            return Edad;
        }

        public int EdadMaxima()
        {
            ArrayList Listado = new ArrayList(ObtenerListado());

            int Edad = 120;

            if (Listado.Count >= 6)
            {
                return (int)Listado[4];
            }

            if (Listado.Count >= 4)
            {
                Int32.TryParse(Listado[3].ToString(), out Edad);
            }
            
            return Edad;
        }

        public IList<TreePoolDaysByLocation> ObtenerDaysByLocation()
        {
            IList<TreePoolDaysByLocation> Ids = new List<TreePoolDaysByLocation>();

            ArrayList Listado = new ArrayList(ObtenerListado());

            if (Listado.Count == 0)
            {
                return Ids;
            }

            if (Listado.Count < 6)
            {
                Ids.Add(new TreePoolDaysByLocation((int)Listado[1], (int) Listado[0]));
            }
            else
            {
                ArrayList Dias = (ArrayList)Listado[0];
                ArrayList Validez = (ArrayList)Listado[1];

                for (int I = 0; I < Validez.Count; I++)
                {
                    Ids.Add(new TreePoolDaysByLocation((int)Validez[I], (int)Dias[I]));
                }
            }
            
            return Ids;
        }
        
    }

    public class TreePoolDaysByLocation
    {
        private int _IdLocationGroup;

        private int _ConsecutiveDays;

        public TreePoolDaysByLocation(int IdLocationGroup, int ConsecutiveDays)
        {
            _IdLocationGroup = IdLocationGroup;
            _ConsecutiveDays = ConsecutiveDays;
        }

        public int IdLocationGroup
        {
            get
            {
                return _IdLocationGroup;
            }
            set
            {
                _IdLocationGroup = value;
            }
        }

        public int ConsecutiveDays
        {
            get
            {
                return _ConsecutiveDays;
            }
            set
            {
                _ConsecutiveDays = value;
            }
        }

    }

}
