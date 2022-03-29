using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using Backend.Dominio;
using Backend.Datos;
using CapitasMigracion.Datos;
using Backend.Servicios;
using Backend.DTO;
using Backend.Homes;
using System.Collections;

namespace CapitasMigracion.Servicios
{
    public class ServicioMigracion
    {
        #region Migracion Productos y Tarifas
        public static void MigrarProductosTarifas()
        {
            IList<Business> Negocios = DAOBusiness.Instancia().Buscar();

            IList<Plan> Planes = DAOPlan.Instancia().Buscar();

            foreach (Business Negocio in Negocios)
            {
                Producto Producto = new Producto();
                Producto.Codigo = Negocio.Codigo;
                Producto.Nombre = Negocio.Nombre;
                Producto.IdTipoGrupoClausula = Negocio.IdTipoGrupoClausula;
                Producto.CodigoPais = Negocio.CodigoPais;

                Producto.Persistir();
            }

            foreach (Plan Plan in Planes)
            {             
                Producto Producto = DAOProducto.Instancia().Obtener(Plan.IdTipoGrupoClausula, Plan.CodigoBusiness, Plan.CodigoPais);

                if (Producto.Id != 0)
                {
                    Tarifa Tarifa = new Tarifa();

                    Tarifa.IdProducto = Producto.Id;
                    Tarifa.CodigoPais = Plan.CodigoPais;
                    Tarifa.Codigo = Plan.Codigo;
                    Tarifa.Nombre = Plan.Nombre;
                    Tarifa.Sufijo = "";
                    Tarifa.IdTipoGrupoClausula = Plan.IdTipoGrupoClausula;

                    Tarifa.Persistir();
                }
            }
        }
        
        #endregion

        #region Migracion Clausulas

        public static void MigrarClausulas()
        {
            IList<LimitCategories> Limits = DAOLimitCategories.Instancia().Buscar();

            foreach (LimitCategories Limit in Limits)
            {
                Clausula Clausula = ClausulaHome.Obtener(Limit.Codigo);

                if (Clausula.Id == 0)
                {
                    Clausula.Clausula_Idioma = new List<Clausula_Idioma>();
                    Clausula.Codigo = Limit.Codigo;
                    Clausula.TipoClausula = TipoClausulaHome.ObtenerPorCodigoClausula(Clausula.Codigo);

                    IList<Idioma> Idiomas = IdiomaHome.Buscar();
                    foreach (Idioma Idioma in Idiomas)
                    {
                        Clausula_Idioma ClausulaIdioma = new Clausula_Idioma();
                        ClausulaIdioma.Nombre = Limit.Nombre;
                        ClausulaIdioma.IdIdioma = Idioma.Id;

                        Clausula.Clausula_Idioma.Add(ClausulaIdioma);                    
                    }

                    Clausula.Persistir();    
                }
            }
        }

        #endregion

        #region Migracion Validez Territorial

        public static void MigrarValidezTerritorial()
        {
            IList<LocationGroup> Locations = DAOLocationGroup.Instancia().Buscar();

            foreach (LocationGroup Location in Locations)
            {
                ValidezTerritorialPersistence.Crear(Location);
            }

            foreach (LocationGroup Location in Locations)
            {
                ValidezTerritorialPersistence.Crear(Location, Location.Details);
            }
        }

        #endregion

        #region Region Grupos Clausulas

        private static string ObtenerRate(string Key)
        {
            IDictionary<string, string> Rates = new Dictionary<string, string>();

            Rates.Add("daily", "DIA");
            Rates.Add("monthly", "MES");
            Rates.Add("per event", "EVEN");
            Rates.Add("per membership", "TAR");
            Rates.Add("per kg", "KG");
            Rates.Add("per year per membership", "ANIO");

            if (Rates.Keys.Contains(Key.ToLower().Trim()))
            {
                return Rates[Key.ToLower().Trim()];
            }

            return "NO";
        }

        private static string ObtenerOperador(string TipoRule)
        {
            if ("MAX".Equals(TipoRule.ToUpper().Trim()))
            {
                return "MENOR";
            }
            return "MAYOR";
        }

        private static IList<Leyenda> ObtenerLeyendas(RulePool Rule)
        {
            IList<Leyenda> Leyendas = new List<Leyenda>();

            IList<Idioma> Idiomas = IdiomaHome.Buscar();

            foreach (Idioma Idioma in Idiomas)
            {
                Leyendas.Add(new Leyenda(Idioma.Id, Rule.Value.ToString() + " " + Rule.Unit));
            }

            return Leyendas;
        }

        private static string ObtenerExpresionContenido(RulePool Rule)
        {
            return "";
        }

        private static string ObtenerContenido(RulePool Rule)
        {
            IDictionary<string, string> Unidades = new Dictionary<string, string>();

            Unidades.Add("Year", "ANIO");
            Unidades.Add("Month", "MES");
            Unidades.Add("Day", "DIAS");
            Unidades.Add("Percent", "GENERAL");
            Unidades.Add("KG", "PESO");
            Unidades.Add("GuestNumber", "HUESPEDES");
            Unidades.Add("Days from Membership's Valid to", "GENERAL");
            Unidades.Add("Age", "EDAD");
            Unidades.Add("Medical Visit", "GENERAL");
            Unidades.Add("Event", "GENERAL");
            Unidades.Add("Offset", "GENERAL");
            
            string Contenido = "";

            if (Unidades.Keys.Contains(Rule.Unit.Trim()) && 
                (Unidades[Rule.Unit.Trim()].Equals("PESO") || 
                Unidades[Rule.Unit.Trim()].Equals("GENERAL")))
            {
                Contenido = Unidades[Rule.Unit.Trim()] + ": " + Rule.Value + " " + Rule.Unit;
            }
            else
            {
                if (!Unidades.Keys.Contains(Rule.Unit.Trim()))
                {
                    Contenido = "MONTO: " + Rule.Value + " " + Rule.Unit;
                }
                else
                {
                    Contenido = Unidades[Rule.Unit] + ": " + Rule.Value;
                }
            }

            return Contenido;
        }

        private static void CrearRangoDTO(TreePool TreePool, Pool Pool, RulePool Rule, Backend.DTO.ClausulaDTO ClausulaDto)
        {
            ArrayList Listado = new ArrayList(TreePool.ObtenerListado());
            IList<TreePoolDaysByLocation> DaysByLocations = TreePool.ObtenerDaysByLocation();

            foreach (TreePoolDaysByLocation DayByLocation in DaysByLocations)
            {
                ContenidoRangoDTO Dto = new ContenidoRangoDTO();

                Dto.IdTipoModalidad = TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id;
                Dto.Categoria = 0;
                Dto.IdTipoDestino = 0;
                Dto.IdTipoPlan = TipoPlanHome.Todos().Id;
                Dto.IdValidezTerritorialClausula = Rule.IncludeNational ?
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL_RECEPTIVO).Id :
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;
                Dto.EdadMinima = TreePool.EdadMinima();
                Dto.EdadMaxima = TreePool.EdadMaxima();
                Dto.Leyendas = ObtenerLeyendas(Rule);

                //segun cantidad de elementos en el array
                //LocationGroup LocationGroup = DAOLocationGroup.Instancia().Obtener(DayByLocation.IdLocationGroup);

                LocationGroup LocationGroup = DAOLocationGroup.Instancia().Obtener(Rule.IdTerritorialValidity);

                Dto.IdValidezTerritorial = ValidezTerritorialHome.Obtener(LocationGroup.Nombre).Id;

                Dto.Contenido = ObtenerContenido(Rule) +
                    (DayByLocation.ConsecutiveDays == 0 ? "" : " && DIAS-CONSECUTIVOS: IGUAL " + DayByLocation.ConsecutiveDays);

                ClausulaDto.Contenidos.Add(Dto);
            }
        }

        private static Backend.DTO.ClausulaDTO CrearClausulaDTO(TreePool TreePool, Pool Pool, int Orden, Backend.DTO.GrupoClausulaDTO GrupoDto)
        {
            Backend.DTO.ClausulaDTO Dto = new Backend.DTO.ClausulaDTO();

            Dto.Orden = Orden;
            Dto.NombreClausula = Pool.CodigoClausula.Trim().Replace("..", ".");
            Dto.TextoIdentificatorio = Dto.NombreClausula;

            Clausula Clausula = ClausulaHome.Obtener(Dto.NombreClausula);

            if (Clausula.Id != 0)
            {
                Dto.IdClausula = ClausulaHome.Obtener(Dto.NombreClausula).Id;
                Dto.IdTipoClausula = Dto.NombreClausula.Contains("C.") ?
                   TipoClausulaHome.Obtener(TipoClausula.SERVICIO).Id :
                   Dto.NombreClausula.Contains("D.") ? TipoClausulaHome.Obtener(TipoClausula.SEGURO).Id :
                   TipoClausulaHome.Obtener(TipoClausula.GENERAL).Id;
                Dto.TipoCobertura = TipoCoberturaHome.Obtener(ObtenerRate(
                    Pool.Rules != null && Pool.Rules.Count > 0 ? Pool.Rules[0].Rate : "NO"));
                
                Dto.IdTipoImpresionClausula = TipoImpresionClausulaHome.Obtener(TipoImpresionClausula.COMPLETO).Id;
                Dto.IdTipoContenidoImpresion = TipoContenidoImpresionHome.Obtener(TipoContenidoImpresion.COMPLETO).Id;
                Dto.VisibleEnAsistencia = Pool.Visible;
                Dto.EvaluableEnAsistencia = Pool.Rules != null && Pool.Rules.Count > 0 ? 
                    Pool.Rules[0].Evaluate : false;

                foreach (RulePool Rule in Pool.Rules)
                {
                    CrearRangoDTO(TreePool, Pool, Rule, Dto);
                }

                if (!GrupoDto.Clausulas.Keys.Contains(Dto.NombreClausula))
                {
                    GrupoDto.Clausulas.Add(Dto.NombreClausula, Dto);
                }
            }

            

            /*
        private IList<ContenidoRangoDTO> _Contenidos = new List<ContenidoRangoDTO>();

             */



            return Dto;
        }

        private static Backend.DTO.GrupoClausulaDTO CrearDTO(TreePool TreePool)
        {
            Backend.DTO.GrupoClausulaDTO Dto = new Backend.DTO.GrupoClausulaDTO();

            Dto.TipoGrupoClausula = TipoGrupoClausulaHome.ProductoSinEmision();
            Dto.CodigoPais = TreePool.CountryCode;
            Dto.Producto = DAOProducto.Instancia().Obtener(Dto.TipoGrupoClausula.Id, TreePool.IdBusiness.ToString(), Dto.CodigoPais);
            Dto.Tarifas.Add(DAOTarifa.Instancia().Obtener(Dto.CodigoPais, Dto.Producto.Codigo, TreePool.IdPlan.ToString(), false));
            Dto.Anual = false;

            if (Dto.Producto.Nombre.Equals("HOSPITAL BRITANICO"))
            {
                int u = 0;
            }

            int I = 1;
            foreach(Pool Pool in TreePool.Pools) 
            {
                Backend.DTO.ClausulaDTO ClausulaDto = CrearClausulaDTO(TreePool, Pool, I, Dto);
                I++;
            }
            
            return Dto;
        }

        public static void MigrarGrupos()
        {
            IList<TreePool> Trees = DAOTreePool.Instancia().Buscar();
            int orden = 1;
            foreach (TreePool Tree in Trees)
            {
                ServicioGrupoClausula.Crear(CrearDTO(Tree));
                orden++;
            }
        }

        #endregion
    }
}
