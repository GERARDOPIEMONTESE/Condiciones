using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;

namespace Condiciones
{
    public partial class CopiaGrupos : System.Web.UI.Page
    {
        private void Copiar(Pais pais, GrupoClausula grupo, Tarifa tarifaCopiar, TipoGrupoClausula tipoGrupoClausula)
        {
            GrupoClausula nuevoGrupo = grupo.Copiar();
            nuevoGrupo.IdLocacion = pais.IdLocacion;
            nuevoGrupo.Objetos = new List<ObjetoAgrupadorClausula>();

            ObjetoAgrupadorClausula objeto = new ObjetoAgrupadorClausula();
            objeto.IdObjetoAgrupador = tarifaCopiar.Id;
            objeto.TipoGrupoClausula = tipoGrupoClausula;
            objeto.IdLocacion = pais.IdLocacion;

            nuevoGrupo.Objetos.Add(objeto);

            nuevoGrupo.Persistir();
        }

        private void Copiar(Pais pais, GrupoClausula grupo, IList<Tarifa> tarifasCopiar, TipoGrupoClausula tipoGrupoClausula)
        {
            if (grupo == null || grupo.Id == 0)
            {
                return;
            }

            if (tarifasCopiar == null || tarifasCopiar.Count == 0)
            {
                return;
            }

            GrupoClausula nuevoGrupo = grupo.Copiar();
            nuevoGrupo.IdLocacion = pais.IdLocacion;
            nuevoGrupo.Objetos = new List<ObjetoAgrupadorClausula>();

            foreach (Tarifa tarifaCopiar in tarifasCopiar)
            {
                ObjetoAgrupadorClausula objeto = new ObjetoAgrupadorClausula();
                objeto.IdObjetoAgrupador = tarifaCopiar.Id;
                objeto.TipoGrupoClausula = tipoGrupoClausula;
                objeto.IdLocacion = pais.IdLocacion;

                nuevoGrupo.Objetos.Add(objeto);
            }

            nuevoGrupo.Persistir();
        }

        private GrupoClausula GetGrupo(IList<GrupoClausula> grupos, bool anual)
        {
            foreach (GrupoClausula grupo in grupos)
            {
                if (grupo.Anual == anual)
                {
                    return GrupoClausulaHome.Obtener(grupo.Id, false);
                }
            }

            return null;
        }

        private void CopiarGrupos(IList<GrupoClausula> grupos, Pais pais, TipoGrupoClausula tipoGrupoClausula, string productoNuevo)
        {
            Producto nuevo = ProductoHome.Obtener(Convert.ToInt32(pais.Codigo), productoNuevo);

            IList<Tarifa> tarifas = TarifaHome.Buscar(Convert.ToInt32(pais.Codigo), nuevo.Id, false);
            if (tarifas != nuevo && tarifas.Count > 0)
            {
                Copiar(pais, GetGrupo(grupos, false), tarifas, tipoGrupoClausula);
            }

            tarifas = TarifaHome.Buscar(540, nuevo.Id, true);
            if (tarifas != nuevo && tarifas.Count > 0)
            {
                Copiar(pais, GetGrupo(grupos, true), tarifas, tipoGrupoClausula);
            }
        }

        private void CopiarGrupos(IList<GrupoClausula> grupos, Pais pais, 
            TipoGrupoClausula tipoGrupoClausula, string productoNuevo, bool anual)
        {
            Producto nuevo = ProductoHome.Obtener(Convert.ToInt32(pais.Codigo), productoNuevo);

            IList<Tarifa> tarifas = TarifaHome.Buscar(Convert.ToInt32(pais.Codigo), nuevo.Id, "0", true, "", anual);
            if (tarifas != nuevo && tarifas.Count > 0)
            {
                Copiar(pais, GetGrupo(grupos, anual), tarifas, tipoGrupoClausula);
            }
        }

        private void CopiarGrupos1()
        {
            TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Producto();
            Pais pais = PaisHome.ObtenerPorCodigo(540);

            Producto productoOriginal = ProductoHome.Obtener(540, "BD");
            IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4D");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "ND");

            productoOriginal = ProductoHome.Obtener(540, "BE");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4E");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NE");

            productoOriginal = ProductoHome.Obtener(540, "BF");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4B");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NB");

            productoOriginal = ProductoHome.Obtener(540, "BG");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4R");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NR");

            productoOriginal = ProductoHome.Obtener(540, "BH");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4N");
        }

        private void CopiarGrupos(string codigo, TipoGrupoClausula tipoGrupoClausula)
        {
            Producto productoOriginal = ProductoHome.Obtener(540, codigo);
            IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(tipoGrupoClausula.Id, 540, productoOriginal.Id, "", "");
            IList<int> countries = Countries();

            foreach (int codigoPais in countries)
            {
                Pais pais = PaisHome.ObtenerPorCodigo(codigoPais);
                CopiarGrupos(grupos, pais, tipoGrupoClausula, codigo);
            }
        }

        private void CopiarGrupos()
        {
            TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Producto();
            
            CopiarGrupos("4D", tipoGrupoClausula);
            CopiarGrupos("ND", tipoGrupoClausula);
            CopiarGrupos("4E", tipoGrupoClausula);
            CopiarGrupos("NE", tipoGrupoClausula);
            CopiarGrupos("4B", tipoGrupoClausula);
            CopiarGrupos("NB", tipoGrupoClausula);
            CopiarGrupos("4R", tipoGrupoClausula);
            CopiarGrupos("NR", tipoGrupoClausula);
            CopiarGrupos("4N", tipoGrupoClausula);
        }


        private void GenerarGruposArgentinaFaltantes()
        {

            TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Producto();
            Pais pais = PaisHome.ObtenerPorCodigo(540);

            Producto productoOriginal = ProductoHome.Obtener(540, "BD");
            IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "ND", false);

            productoOriginal = ProductoHome.Obtener(540, "BE");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NE", true);

            productoOriginal = ProductoHome.Obtener(540, "BF");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4B", true);
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NB", true);

            productoOriginal = ProductoHome.Obtener(540, "BG");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4R", true);
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NR", true);

        }

        private void GenerarGruposArgentina()
        {
            TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Producto();
            Pais pais = PaisHome.ObtenerPorCodigo(540);

            Producto productoOriginal = ProductoHome.Obtener(540, "BD");
            IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4D");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "ND");

            productoOriginal = ProductoHome.Obtener(540, "BE");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4E");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NE");

            productoOriginal = ProductoHome.Obtener(540, "BF");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4B");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NB");

            productoOriginal = ProductoHome.Obtener(540, "BG");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4R");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "NR");

            productoOriginal = ProductoHome.Obtener(540, "BH");
            grupos = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0");
            CopiarGrupos(grupos, pais, tipoGrupoClausula, "4N");
        }

        private void CopiarProducto4B(TipoGrupoClausula tipoGrupoClausula, int country, Pais pais)
        {
            Producto productoOriginal = ProductoHome.Obtener(country, "4B");
            IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(tipoGrupoClausula.Id, country, productoOriginal.Id, "", "0");

            GrupoClausula grupoAnual = GetGrupo(grupos, true);
            GrupoClausula grupo = GetGrupo(grupos, false);

            if (grupoAnual != null)
            {
                IList<Tarifa> tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40004", true, "F0263", true);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupoAnual, tarifas[0], tipoGrupoClausula);
                }

                tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40005", true, "F0264", true);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupoAnual, tarifas[0], tipoGrupoClausula);
                }
            }

            if (grupo != null)
            {
                IList<Tarifa> tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40010", true, "F0261", false);

                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupo, tarifas[0], tipoGrupoClausula);
                }

                tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40011", true, "F0262", false);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupo, tarifas[0], tipoGrupoClausula);
                }
            }
        }

        private void CopiarProducto4D(TipoGrupoClausula tipoGrupoClausula, int country, Pais pais)
        {
            //Pais pais = PaisHome.ObtenerPorCodigo(country);
            Producto productoOriginal = ProductoHome.Obtener(country, "4D");
            IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(tipoGrupoClausula.Id, country, productoOriginal.Id, "", "0");

            GrupoClausula grupoAnual = GetGrupo(grupos, true);
            GrupoClausula grupo = GetGrupo(grupos, false);

            if (grupoAnual != null)
            {
                IList<Tarifa> tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40000", true, "F0271", true);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupoAnual, tarifas[0], tipoGrupoClausula);
                }

                tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40001", true, "F0272", true);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupoAnual, tarifas[0], tipoGrupoClausula);
                }
            }

            if (grupo != null)
            {
                IList<Tarifa> tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40006", true, "F0269", false);

                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupo, tarifas[0], tipoGrupoClausula);
                }

                tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40007", true, "F0270", false);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupo, tarifas[0], tipoGrupoClausula);
                }
            }
        }

        private void CopiarProducto4E(TipoGrupoClausula tipoGrupoClausula, int country, Pais pais)
        {
            //Pais pais = PaisHome.ObtenerPorCodigo(country);
            Producto productoOriginal = ProductoHome.Obtener(country, "4E");
            IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(tipoGrupoClausula.Id, country, productoOriginal.Id, "", "0");

            GrupoClausula grupoAnual = GetGrupo(grupos, true);
            GrupoClausula grupo = GetGrupo(grupos, false);

            if (grupoAnual != null)
            {
                IList<Tarifa> tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40002", true, "F0267", true);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupoAnual, tarifas[0], tipoGrupoClausula);
                }

                tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40003", true, "F0268", true);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupoAnual, tarifas[0], tipoGrupoClausula);
                }
            }

            if (grupo != null)
            {
                IList<Tarifa> tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40008", true, "F0265", false);

                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupo, tarifas[0], tipoGrupoClausula);
                }

                tarifas = TarifaHome.Buscar(country, productoOriginal.Id, "40009", true, "F0266", false);
                if (tarifas.Count > 0)
                {
                    Copiar(pais, grupo, tarifas[0], tipoGrupoClausula);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IList<string> products = Products();
            IList<int> countries = Countries();
            TipoGrupoClausula tipoGrupo = TipoGrupoClausulaHome.Producto();

            foreach (string code in products)
            {
                Producto prodOriginal = ProductoHome.Obtener(540, code);
                IList<Tarifa> tarifas = TarifaHome.Buscar(540, prodOriginal.Id, true);
                foreach (Tarifa tarifa in tarifas)
                {
                    IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(tipoGrupo.Id, 540, prodOriginal.Id, tarifa.Sufijo, tarifa.Codigo);
                    GrupoClausula grupo = GetGrupo(grupos, true);

                    foreach (int country in countries)
                    {
                        Producto prodCountry = ProductoHome.Obtener(country, code);
                        Pais pais = PaisHome.ObtenerPorCodigo(country);

                        IList<Tarifa> tarifasPais = TarifaHome.Buscar(country, prodCountry.Id, tarifa.Codigo, true, tarifa.Sufijo, tarifa.Anual);
                        Copiar(pais, grupo, tarifasPais, tipoGrupo);
                    }
                }
            }

            //GenerarGruposArgentinaFaltantes();
            /*
            40004	4B	1	1	F0263
            40005	4B	1	1	F0264
            40010	4B	0	1	F0261
            40011	4B	0	1	F0262

            40000	4D	1	1	F0271
            40001	4D	1	1	F0272
            40006	4D	0	1	F0269
            40007	4D	0	1	F0270

            40002	4E	1	1	F0267
            40003	4E	1	1	F0268
            40008	4E	0	1	F0265
            40009	4E	0	1	F0266
            */
            
            //Crear grupos con franquicia
            /*TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Producto();
            IList<int> countries = Countries();
            
            foreach (int country in countries)
            {
                Pais pais = PaisHome.ObtenerPorCodigo(country);

                CopiarProducto4B(tipoGrupoClausula, country, pais);
                CopiarProducto4E(tipoGrupoClausula, country, pais);
                CopiarProducto4D(tipoGrupoClausula, country, pais); 
            }
            */

            //Producto productoOriginal = ProductoHome.Obtener(540, "4M");
            //GrupoClausula grupoClausula = GrupoClausulaHome.Buscar(1, 540, productoOriginal.Id, "", "0")[0];

            //grupoClausula = GrupoClausulaHome.Obtener(grupoClausula.Id, false);

            //foreach (int codigoPais in countries)
            //{
            //    Pais pais = PaisHome.ObtenerPorCodigo(codigoPais);
            //    Tarifa tarifaCopia = TarifaHome.Obtener(codigoPais, "4M", "0", true);

            //    Copiar(pais, grupoClausula, tarifaCopia, tipoGrupoClausula);
            //}

            //TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Producto();

            //IList<int> countries = Countries();
            //IDictionary<string, IList<CopiaDTO>> productos = ObtenerProductos();

            //foreach (int codigoPais in countries)
            //{
            //    Pais pais = PaisHome.ObtenerPorCodigo(codigoPais);
            //    Producto productoOriginal = ProductoHome.Obtener(codigoPais, "4M");

            //    foreach (string codigoTarifaOriginal in productos.Keys)
            //    {
            //        IList<GrupoClausula> grupos = GrupoClausulaHome.Buscar(
            //            tipoGrupoClausula.Id, codigoPais, productoOriginal.Id, "", codigoTarifaOriginal);

            //        GrupoClausula grupo = null;

            //        foreach (GrupoClausula group in grupos)
            //        {
            //            if (group.Anual == productos[codigoTarifaOriginal][0].Anual)
            //            {
            //                grupo = GrupoClausulaHome.Obtener(group.Id, false);
            //                break;
            //            }
            //        }

            //        if (grupo != null)
            //        {
            //            foreach (CopiaDTO copia in productos[codigoTarifaOriginal])
            //            {
            //                Tarifa tarifaCopia = TarifaHome.Obtener(codigoPais, copia.CodigoProducto, copia.Codigo, copia.Anual);
            //                if (tarifaCopia.Id != 0)
            //                {
            //                    Copiar(pais, grupo, tarifaCopia, tipoGrupoClausula);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private IDictionary<string, IList<CopiaDTO>> ObtenerProductos()
        {
            IDictionary<string, IList<CopiaDTO>> productos = new Dictionary<string, IList<CopiaDTO>>();

            //productos.Add("0", new List<CopiaDTO>());
            //productos["0"].Add(new CopiaDTO("3A", "0", false));
            //productos["0"].Add(new CopiaDTO("3B", "0", false));
            //productos["0"].Add(new CopiaDTO("44", "0", false));
            //productos["0"].Add(new CopiaDTO("45", "0", false));

            //productos.Add("13000", new List<CopiaDTO>());
            //productos["13000"].Add(new CopiaDTO("3A", "13901", true));
            //productos["13000"].Add(new CopiaDTO("3B", "13905", true));
            //productos["13000"].Add(new CopiaDTO("44", "13909", true));
            //productos["13000"].Add(new CopiaDTO("45", "13913", true));

            //productos.Add("13001", new List<CopiaDTO>());
            //productos["13001"].Add(new CopiaDTO("3A", "13902", true));
            //productos["13001"].Add(new CopiaDTO("3B", "13906", true));
            //productos["13001"].Add(new CopiaDTO("44", "13910", true));
            //productos["13001"].Add(new CopiaDTO("45", "13914", true));

            //productos.Add("13002", new List<CopiaDTO>());
            //productos["13002"].Add(new CopiaDTO("3A", "13903", false));
            //productos["13002"].Add(new CopiaDTO("3B", "13907", false));
            //productos["13002"].Add(new CopiaDTO("44", "13911", false));
            //productos["13002"].Add(new CopiaDTO("45", "13915", false));

            //productos.Add("13003", new List<CopiaDTO>());
            //productos["13003"].Add(new CopiaDTO("3A", "13904", true));
            //productos["13003"].Add(new CopiaDTO("3B", "13908", true));
            //productos["13003"].Add(new CopiaDTO("44", "13912", true));
            //productos["13003"].Add(new CopiaDTO("45", "13916", true));            

            return productos;
        }

        private IList<string> Products()
        {
            IList<string> products = new List<string>();
            
            products.Add("4M"); //ANUAL
            //products.Add("4D"); //ANUAL
            //products.Add("ND"); //TODO
            //products.Add("4E"); //ANUAL
            //products.Add("NE"); //ANUAL
            //products.Add("4B"); //ANUAL
            //products.Add("NB"); //ANUAL
            //products.Add("4R"); //ANUAL
            //products.Add("NR"); //ANUAL

            return products;
        }

        private IList<int> Countries()
        {
            IList<int> countries = new List<int>();

            //countries.Add(540);
            countries.Add(591);
            countries.Add(570);
            countries.Add(598);
            countries.Add(550);
            countries.Add(507);
            countries.Add(560);
            countries.Add(595);
            countries.Add(580);
            countries.Add(593);
            countries.Add(503);
            countries.Add(502);
            countries.Add(504);
            countries.Add(505);
            countries.Add(510);
            countries.Add(520);
            countries.Add(809);

            countries.Add(582);

            return countries;
        }
    }

    public class CopiaDTO
    {
        public string CodigoProducto { get; set; }

        public string Codigo { get; set; }

        public bool Anual { get; set; }

        public CopiaDTO()
        {
        }

        public CopiaDTO(string pCodigoProducto, string pCodigo, bool pAnual)
        {
            CodigoProducto = pCodigoProducto;
            Codigo = pCodigo;
            Anual = pAnual;
        }
    }
}