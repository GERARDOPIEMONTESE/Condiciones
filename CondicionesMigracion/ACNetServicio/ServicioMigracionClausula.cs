using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using CondicionesMigracion.ACNetDatos;
using Backend.Dominio;
using Backend.Homes;

namespace CondicionesMigracion.ACNetServicio
{
    public class ServicioMigracionClausula
    {
        #region Singleton

        private static ServicioMigracionClausula _Instancia;

        private ServicioMigracionClausula()
        {
        }

        public static ServicioMigracionClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioMigracionClausula();
            }
            return _Instancia;
        }

        #endregion

        private void GenerarIdiomas(IList<Clausula_Idioma> TextosIdioma, ClausulaACNET Clausula)
        {
            if (TextosIdioma.Count == 0)
            {
                IList<Idioma> Idiomas = IdiomaHome.Buscar();

                foreach (Idioma Idioma in Idiomas)
                {
                    if (Idioma.Id > -1)
                    {
                        Clausula_Idioma ClausulaIdioma = new Clausula_Idioma();
                        ClausulaIdioma.IdIdioma = Idioma.Id;
                        ClausulaIdioma.Nombre = Clausula.Titulo;

                        TextosIdioma.Add(ClausulaIdioma);
                    }
                }
            }
            else
            {
                foreach (Clausula_Idioma ClausulaIdioma in TextosIdioma)
                {
                    if (ClausulaIdioma.IdIdioma == Clausula.IdIdioma)
                    {
                        ClausulaIdioma.Nombre = Clausula.Titulo;
                    }
                }
            }
        }

        private void GenerarIdiomasSinTitulos(IList<Clausula_Idioma> TextosIdioma, ClausulaACNET Clausula)
        {
            IList<Idioma> Idiomas = IdiomaHome.Buscar();

            foreach (Idioma Idioma in Idiomas)
            {
                if (Idioma.Id > -1)
                {
                    Clausula_Idioma ClausulaIdioma = new Clausula_Idioma();
                    ClausulaIdioma.IdIdioma = Idioma.Id;
                    ClausulaIdioma.Nombre = "Ninguno";

                    TextosIdioma.Add(ClausulaIdioma);
                }
            }
        }

        public void Migrar()
        {
            //IList<Clausula> ClausulasOriginales = ClausulaHome.Buscar();

            IList<ClausulaACNET> Clausulas = DAOClausulaACNET.Instancia().BuscarConTitulo();

            foreach (ClausulaACNET ClausulaACNET in Clausulas)
            {
                Clausula Clausula = ClausulaHome.Obtener(ClausulaACNET.IdClausula.Trim());

                Clausula.Codigo = ClausulaACNET.IdClausula;

                Clausula.TipoClausula = ClausulaACNET.IdClausula.Trim().StartsWith("C.") ?
                    TipoClausulaHome.Obtener(TipoClausula.SERVICIO) :
                        ClausulaACNET.IdClausula.Trim().StartsWith("D.") ?
                        TipoClausulaHome.Obtener(TipoClausula.SEGURO) :
                        TipoClausulaHome.Obtener(TipoClausula.GENERAL);

                if (Clausula.Clausula_Idioma == null)
                {
                    Clausula.Clausula_Idioma = new List<Clausula_Idioma>();
                }

                GenerarIdiomas(Clausula.Clausula_Idioma, ClausulaACNET);

                Clausula.Persistir();
            }

            Clausulas = DAOClausulaACNET.Instancia().BuscarSinTitulo();

            foreach (ClausulaACNET ClausulaACNET in Clausulas)
            {
                Clausula Clausula = ClausulaHome.Obtener(ClausulaACNET.IdClausula.Trim());

                if (Clausula.Id == 0)
                {
                    Clausula.Codigo = ClausulaACNET.IdClausula;

                    Clausula.TipoClausula = ClausulaACNET.IdClausula.Trim().StartsWith("C.") ?
                        TipoClausulaHome.Obtener(TipoClausula.SERVICIO) :
                            ClausulaACNET.IdClausula.Trim().StartsWith("D.") ?
                            TipoClausulaHome.Obtener(TipoClausula.SEGURO) :
                            TipoClausulaHome.Obtener(TipoClausula.GENERAL);

                    Clausula.Clausula_Idioma = new List<Clausula_Idioma>();

                    GenerarIdiomasSinTitulos(Clausula.Clausula_Idioma, ClausulaACNET);

                    Clausula.Persistir();
                }
            }
        }
    }
}
