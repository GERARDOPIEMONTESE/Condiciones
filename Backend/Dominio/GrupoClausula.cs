using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;
using Backend.Interfaces;
using Backend.Homes;

namespace Backend.Dominio
{
    public class GrupoClausula : ObjetoNegocio, ICopiable<GrupoClausula>
    {
        private const string NOMBRE = "GrupoClausula";

        #region Atributos

        private int _IdLocacion;

        private TipoGrupoClausula _TipoGrupoClausula;

        //private Texto _TextoResumen;
        private IList<AsociacionTexto> _Textos = new List<AsociacionTexto>(); 

        private bool _Anual;

        private int _DiasConsecutivos;

        private IList<ContenidoClausula> _Contenidos = new List<ContenidoClausula>();

        private IList<ObjetoAgrupadorClausula> _Objetos = new List<ObjetoAgrupadorClausula>();

        private IList<AsociacionDocumento> _Documentos = new List<AsociacionDocumento>();

        #endregion

        #region Propiedades

        public int IdLocacion
        {
            get
            {
                return _IdLocacion;
            }
            set
            {
                _IdLocacion = value;
            }
        }

        public string NombreLocacion
        {
            get
            {
                return DAOPais.Instancia().ObtenerPorIdLocacion(IdLocacion).Nombre;
            }
            set
            {
            }
        }

        //public Texto TextoResumen
        //{
        //    get
        //    {
        //        return _TextoResumen;
        //    }
        //    set
        //    {
        //        _TextoResumen = value;
        //    }
        //}
        public IList<AsociacionTexto> Textos
        {
            get
            {
                return _Textos;
            }
            set
            {
                _Textos = value;
            }
        }

        public string NombreTextoResumen
        {
            get
            {
                return Textos != null && Textos.Count > 0 ? 
                    TextoHome.Obtener(Textos[0].IdTexto).Nombre : "";
            }
            set
            {
            }
        }

        public bool Anual
        {
            get
            {
                return _Anual;
            }
            set
            {
                _Anual = value;
            }
        }

        public int DiasConsecutivos
        {
            get
            {
                return _DiasConsecutivos;
            }
            set
            {
                _DiasConsecutivos = value;
            }
        }

        public TipoGrupoClausula TipoGrupoClausula
        {
            get
            {
                return _TipoGrupoClausula;
            }
            set
            {
                _TipoGrupoClausula = value;
            }
        }

        public string NombreTipoGrupoClausula
        {
            get
            {
                return TipoGrupoClausula.Nombre;
            }
            set
            {
            }
        }

        public IList<ContenidoClausula> Contenidos
        {
            get
            {
                return _Contenidos;
            }
            set
            {
                _Contenidos = value;
            }
        }

        public IList<ObjetoAgrupadorClausula> Objetos
        {
            get
            {
                return _Objetos;
            }
            set
            {
                _Objetos = value;
            }
        }

        public IList<AsociacionDocumento> Documentos
        {
            get
            {
                return _Documentos;
            }
            set
            {
                _Documentos = value;
            }
        }

        #endregion

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOGrupoClausula.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        public int BuscarPorIdClausula(int IdClausula)
        {
            foreach (ContenidoClausula ContenidoClausula in Contenidos)
            {
                if (ContenidoClausula.IdClausula == IdClausula)
                {
                    return ContenidoClausula.Id;
                }
            }

            return 0;
        }

        public ContenidoClausula BuscarContenidoPorIdClausula(int IdClausula)
        {
            foreach (ContenidoClausula ContenidoClausula in Contenidos)
            {
                if (ContenidoClausula.IdClausula == IdClausula)
                {
                    return ContenidoClausula;
                }
            }

            return null;
        }

        public ContenidoClausula ObtenerPorIdClausula(int IdClausula)
        {
            foreach (ContenidoClausula ContenidoClausula in Contenidos)
            {
                if (ContenidoClausula.IdClausula == IdClausula)
                {
                    return ContenidoClausula;
                }
            }

            return new ContenidoClausula();
        }

        public ContenidoClausula BuscarPorIdPadre(int IdContenidoClausulaPadre)
        {
            foreach (ContenidoClausula ContenidoClausula in Contenidos)
            {
                if (ContenidoClausula.Id == IdContenidoClausulaPadre)
                {
                    return ContenidoClausula;
                }
            }

            return new ContenidoClausula();
        }

        public void Modificar(Texto TextoResumen)
        {
            
        }

        public void Modificar(int IdTipoDocumento, int IdDocumento)
        {

        }

        #region ICopiable<GrupoClausula> Members

        private ContenidoClausula ObtenerContenidoClausula(int IdContenidoClausula)
        {
            foreach (ContenidoClausula ContenidoClausula in this.Contenidos)
            {
                if (ContenidoClausula.Id == IdContenidoClausula)
                {
                    return ContenidoClausula;
                }
            }

            return new ContenidoClausula();
        }

        public GrupoClausula Copiar()
        {
            GrupoClausula Copia = new GrupoClausula();
            Copia.IdLocacion = IdLocacion;
            Copia.TipoGrupoClausula = TipoGrupoClausula;
            Copia.Anual = Anual;

            foreach (AsociacionTexto Texto in Textos)
            {
                Copia.Textos.Add(Texto.Copiar());
            }

            foreach (ContenidoClausula Contenido in Contenidos)
            {
                ContenidoClausula CopiaContenido = Contenido.Copiar();

                foreach (AsociacionContenidoClausula Padre in Contenido.Padres)
                {
                    AsociacionContenidoClausula Asociacion = new AsociacionContenidoClausula();

                    ContenidoClausula ContenidoPadre = ObtenerContenidoClausula(Padre.IdContenidoClausulaPadre);

                    Asociacion.ContenidoClausulaPadre = Copia.BuscarContenidoPorIdClausula(
                        ContenidoPadre.Clausula.Id);

                    if (Asociacion.ContenidoClausulaPadre != null)
                    {
                        CopiaContenido.Padres.Add(Asociacion);
                    }
                }

                Copia.Contenidos.Add(CopiaContenido);
            }

            foreach (AsociacionDocumento Documento in Documentos)
            {
                Copia.Documentos.Add(Documento.Copiar());
            }

            return Copia;
        }

        #endregion

        public int IndexOfClausula(Clausula Clausula)
        {
            int Index = 0;
            foreach (ContenidoClausula Contenido in Contenidos)
            {
                if (Contenido.Clausula.Id == Clausula.Id)
                {
                    return Index;
                }
                Index++;
            }
            return -1;
        }

        public int IndexOfClausula(string Codigo)
        {
            int Index = 0;
            foreach (ContenidoClausula Contenido in Contenidos)
            {
                if (Contenido.Clausula.Codigo == Codigo)
                {
                    return Index;
                }
                Index++;
            }
            return -1;
        }

        private void SetearValidezTerritorial(ContenidoClausula ContenidoAMergear)
        {
            int Index = IndexOfClausula(Clausula.CLAUSULA_VALIDEZ_TERRITORIAL);
            if (Index > -1)
            {
                foreach (ContenidoClausulaRango RangoMerge in ContenidoAMergear.Contenidos)
                {
                    if (Contenidos[Index].Contenidos.Count > 0)
                    {
                        RangoMerge.ValidezTerritorialClausula =
                            Contenidos[Index].Contenidos[0].ValidezTerritorialClausula;
                        RangoMerge.ValidezTerritorial =
                            Contenidos[Index].Contenidos[0].ValidezTerritorial;
                    }
                }
            }
        }

        public void MergearClausulas(GrupoClausula GrupoAMergear)
        {
            foreach (ContenidoClausula ContenidoAMergear in GrupoAMergear.Contenidos)
            {
                int Index = IndexOfClausula(ContenidoAMergear.Clausula);

                if (Index > -1)
                {
                    //Setea la validez territorial cargada para el producto.
                    //ContenidoAMergear.ValidezTerritorial = this.Contenidos[Index].ValidezTerritorial;
                    this.Contenidos[Index] = ContenidoAMergear;
                }
                else
                {
                    //Setea la validez territorial cargada en el producto como clausula.
                    SetearValidezTerritorial(ContenidoAMergear);
                    try
                    {
                        int I = 0;
                        foreach (ContenidoClausula Contenido in Contenidos)
                        {
                            if (Contenido.ObtenerOrden() <= ContenidoAMergear.ObtenerOrden())
                            {
                                I++;
                            }
                            else
                            {
                                break;
                            }                            
                        }

                        this.Contenidos.Insert(I, ContenidoAMergear);
                    }
                    catch (Exception)
                    {
                        this.Contenidos.Add(ContenidoAMergear);
                    }
                }
            }
        }
    }
}
