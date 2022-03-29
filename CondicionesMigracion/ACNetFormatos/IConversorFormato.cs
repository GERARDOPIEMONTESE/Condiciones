using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using Backend.DTO;
using Backend.Homes;
using Backend.Dominio;
using CondicionesMigracion.ACNetDatos;

namespace CondicionesMigracion.ACNetFormatos
{
    public abstract class IConversorFormato
    {
        protected string ObtenerMoneda(ClausulaDato Dato)
        {
            int IdMoneda = 0;
            Int32.TryParse(Dato.Moneda, out IdMoneda);

            return DAOMoneda.Instancia().
                Obtener(IdMoneda == 0 ? 1 : IdMoneda).Nomenclatura;
        }

        protected string ObtenerUnidadMedicion(ClausulaDato Dato)
        {
            int IdUnidadMedicion = 0;
            Int32.TryParse(Dato.UnidadMedicion, out IdUnidadMedicion);

            return DAOUnidadMedicion.Instancia().
                Obtener(IdUnidadMedicion == 0 ? 1 : IdUnidadMedicion).Nomenclatura;
        }

        protected string ObtenerValidezTerritorial(ClausulaDato Dato)
        {
            GrupoPais GrupoPais = DAOGrupoPais.Instancia().Obtener(
                Dato.IdGrupo, Dato.IdClausula.Trim(), Dato.PosicionRegistro);

            return GrupoPais.Id == 0 ? "TODO EL MUNDO" : GrupoPais.Nombre;
        }

        private string ObtenerLeyenda(ClausulaDato Dato)
        {
            ClausulaLeyenda Leyenda = DAOClausulaLeyenda.Instancia().
                Obtener(Dato.IdGrupo, Dato.Posicion);

            return Leyenda.Leyenda == null ? Dato.Valor.ToString() : Leyenda.Leyenda;
        }

        protected virtual IList<Leyenda> ObtenerLeyendas(ClausulaDato Dato) 
        {
            IList<Leyenda> Leyendas = new List<Leyenda>();

            foreach (Idioma Idioma in IdiomaHome.Buscar())
            {
                string Texto = ObtenerLeyenda(Dato);

                if (Texto != null)
                {
                    Leyenda Leyenda = new Leyenda();
                    Leyenda.IdIdioma = Idioma.Id;
                    Leyenda.Texto = Texto;

                    Leyendas.Add(Leyenda);
                }
                else
                {
                    Leyenda Leyenda = new Leyenda();
                    Leyenda.IdIdioma = Idioma.Id;
                    Leyenda.Texto = Dato.Valor.ToString();

                    Leyendas.Add(Leyenda);

                }
            }

            return Leyendas;
        }
        
        protected int ObtenerIdTipoPlan(ClausulaTarifaGrupo Grupo)
        {
            //if (ClausulaTarifaGrupo.UPGRADE.Equals(Grupo.Discriminador) || !Grupo.Producto.StartsWith("R"))
            //{
            //    return TipoPlanHome.Obtener(TipoPlan.CODIGO_TODOS).Id;
            //}

            //if (Grupo.TarifaPlanFamiliar == 1)
            //{
            //    return TipoPlanHome.Obtener(TipoPlan.PLAN_FAMILIAR).Id;
            //}

            //return TipoPlanHome.Obtener(TipoPlan.PLAN_INDIVIDUAL).Id;
            return TipoPlanHome.Obtener(TipoPlan.CODIGO_TODOS).Id;
        }

        public IList<ContenidoRangoDTO> GenerarConversion(ClausulaTarifaGrupo Grupo, IList<ClausulaDato> Datos)
        {
            try
            {
                return Convertir(Grupo, Datos);
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                throw e;
            }
        }

        protected string ObtenerNombreTexto(ClausulaDato Dato)
        {
            ClausulaTexto Texto = DAOClausulaTexto.Instancia().ObtenerPorId(Dato.IdTexto);

            return Texto.Id.ToString();
        }

        protected string ObtenerTexto(string Nombre)
        {
            Texto Texto = TextoHome.Obtener(Texto.CLAUSULA, Nombre);

            return Texto.Id == 0 ? "" : Texto.ContenidoTexto;
        }

        protected abstract IList<ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<ClausulaDato> Datos);
    }
}
