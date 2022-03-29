using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using Backend.Homes;
using Backend.Contextos;
using FrameworkDAC.Negocio;

namespace Backend.Datos
{
    public class DAOGrupoClausula : DAOObjetoNegocio<GrupoClausula>
    {
        #region Singleton

        private static DAOGrupoClausula _Instancia;

        private DAOGrupoClausula()
        {
        }

        public static DAOGrupoClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOGrupoClausula();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(GrupoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdLocacion", ObjetoNegocio.IdLocacion);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.TipoGrupoClausula.Id);
            Parametros.AgregarParametro("Anual", ObjetoNegocio.Anual);
            Parametros.AgregarParametro("DiasConsecutivos", ObjetoNegocio.DiasConsecutivos);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(GrupoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdLocacion", ObjetoNegocio.IdLocacion);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.TipoGrupoClausula.Id);
            Parametros.AgregarParametro("Anual", ObjetoNegocio.Anual);
            Parametros.AgregarParametro("DiasConsecutivos", ObjetoNegocio.DiasConsecutivos);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(GrupoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override Parametros ParametrosGrabarLog(GrupoClausula ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdGrupoClausula", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdLocacion", ObjetoNegocio.IdLocacion);
            Parametros.AgregarParametro("IdTipoGrupoClausula", ObjetoNegocio.TipoGrupoClausula.Id);
            Parametros.AgregarParametro("Anual", ObjetoNegocio.Anual);
            Parametros.AgregarParametro("DiasConsecutivos", ObjetoNegocio.DiasConsecutivos);
            Parametros.AgregarParametro("IdUsuario", ObjetoNegocio.IdUsuario);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(GrupoClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdGrupoClausula"]);
            ObjetoPersistido.IdLocacion = Convert.ToInt32(dr["IdLocacion"]);
            ObjetoPersistido.TipoGrupoClausula = DAOTipoGrupoClausula.Instancia().
                Obtener(Convert.ToInt32(dr["IdTipoGrupoClausula"]));
            
            ObjetoPersistido.Anual = Convert.ToBoolean(dr["Anual"]);
            ObjetoPersistido.DiasConsecutivos = Convert.ToInt32(dr["DiasConsecutivos"]);
            ObjetoPersistido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"]);
        }

        protected override void CrearComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, System.Transactions.TransactionScope ts)
        {
            string message = string.Empty;
            try
            {
                GrupoClausula GrupoClausula = (GrupoClausula)ObjetoNegocio;

                EliminarComposicion(GrupoClausula, ts);

                
                foreach (ContenidoClausula Contenido in GrupoClausula.Contenidos)
                {
                    Contenido.IdGrupoClausula = GrupoClausula.Id;
                    Contenido.IdUsuario = GrupoClausula.IdUsuario;
                    message = "ContenidoClausula";
                    Contenido.Crear(ts);
                }

                foreach (ObjetoAgrupadorClausula Objeto in GrupoClausula.Objetos)
                {
                    Objeto.IdGrupoClausula = GrupoClausula.Id;
                    Objeto.IdUsuario = GrupoClausula.IdUsuario;
                    message = "ObjetoAgrupador";
                    Objeto.Crear(ts);
                }

                foreach (AsociacionDocumento Documento in GrupoClausula.Documentos)
                {
                    Documento.IdObjeto = GrupoClausula.Id;
                    Documento.IdUsuario = GrupoClausula.IdUsuario;
                    message = "Documento";
                    Documento.Crear(ts);
                }

                foreach (AsociacionTexto Texto in GrupoClausula.Textos)
                {
                    Texto.IdGrupoClausula = GrupoClausula.Id;
                    Texto.IdUsuario = GrupoClausula.IdUsuario;
                    message = "Texto";
                    Texto.Persistir(ts);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(message + "." + ex.Message);
            }
            
        }

        protected override void ModificarComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, System.Transactions.TransactionScope ts)
        {
            CrearComposicion(ObjetoNegocio, ts);
        }

        protected override void EliminarComposicion(FrameworkDAC.Negocio.ObjetoNegocio ObjetoNegocio, System.Transactions.TransactionScope ts)
        {
            try
            {
                GrupoClausula GrupoClausula = (GrupoClausula)ObjetoNegocio;

                DAOContenidoClausula.Instancia().Eliminar(GrupoClausula.Id, ts);

                DAOObjetoAgrupadorClausula.Instancia().Eliminar(GrupoClausula.Id, ts);

                DAOAsociacionDocumento.Instancia().Eliminar(GrupoClausula.Id, ts);

                DAOAsociacionTexto.Instancia().Eliminar(GrupoClausula.Id, ts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected override void CompletarComposicion(GrupoClausula ObjetoPersistido)
        {
            ObjetoPersistido.Contenidos = DAOContenidoClausula.Instancia().
                Buscar(ObjetoPersistido.Id);
            ObjetoPersistido.Objetos = DAOObjetoAgrupadorClausula.Instancia().
                Buscar(ObjetoPersistido.Id);
            ObjetoPersistido.Documentos = DAOAsociacionDocumento.Instancia().
                Buscar(ObjetoPersistido.Id, TipoAsociacionDocumentoHome.Grupo().Id);
            ObjetoPersistido.Textos = DAOAsociacionTexto.Instancia().
                Buscar(ObjetoPersistido.Id);
        }

        public IList<GrupoClausula> Buscar(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, string Sufijo, string CodigoTarifa)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("Sufijo", Sufijo.Length == 0 ? null : Sufijo);
            Parametros.AgregarParametro("CodigoTarifa", CodigoTarifa.Length == 0 ? null : CodigoTarifa);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(
                Parametros, "dbo.GrupoClausula_Tx_Producto"), true);
        }

        public IList<GrupoClausula> Buscar(int IdTipoGrupoClausula, int CodigoPais,
            string CodigoProducto, string Sufijo, string CodigoTarifa)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("CodigoProducto", CodigoProducto);
            Parametros.AgregarParametro("Sufijo", Sufijo.Length == 0 ? null : Sufijo);
            Parametros.AgregarParametro("CodigoTarifa", CodigoTarifa.Length == 0 ? null : CodigoTarifa);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(
                Parametros, "dbo.GrupoClausula_Tx_Producto"), true);
        }

        public IList<GrupoClausula> Buscar(int IdTipoGrupoClausula, int CodigoPais,
            int IdProducto, bool Anual, int IdModalidadTarifa)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdTipoGrupoClausula", IdTipoGrupoClausula);
            Parametros.AgregarParametro("CodigoPais", CodigoPais);
            Parametros.AgregarParametro("Anual", Anual);
            Parametros.AgregarParametro("IdProducto", IdProducto);
            Parametros.AgregarParametro("IdModalidadTarifa", IdModalidadTarifa);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.GrupoClausula_Producto_Tx_ModalidadTarifa"));
        }

        private IList<AsociacionDocumento> AddAllDocumentos(IList<AsociacionDocumento> Originales, IList<AsociacionDocumento> Agregados)
        {
            if (Originales == null || Agregados == null)
            {
                return Originales;
            }

            foreach (AsociacionDocumento Asociacion in Agregados)
            {
                Originales.Add(Asociacion);
            }

            return Originales;
        }

        public void ObtenerDocumentos(ContextoGrupoPorRango Contexto, GrupoClausula Grupo)
        {
            IList<TipoDocumento> TiposDocumento = TipoDocumentoHome.Buscar();

            foreach (TipoDocumento TipoDocumento in TiposDocumento)
            {
                IList<AsociacionDocumento> Documentos = DAOAsociacionDocumento.Instancia().Buscar(Grupo.Id,
                    TipoAsociacionDocumentoHome.Grupo().Id, TipoDocumento.Id);

                if (Documentos == null || Documentos.Count == 0)
                {
                    if (Grupo.Objetos != null && Grupo.Objetos.Count > 0)
                    {
                        ObjetoAgrupadorClausula Objeto = Grupo.Objetos[0];

                        Tarifa Tarifa = TarifaHome.Obtener(Contexto.CodigoPais, Contexto.CodigoProducto, Contexto.CodigoTarifa, Contexto.Anual);

                        if (Tarifa != null && Tarifa.Id > 0)
                        {
                            Documentos = DAOAsociacionDocumento.Instancia().Buscar(Tarifa.IdProducto,
                                TipoAsociacionDocumentoHome.Producto().Id, TipoDocumento.Id);
                        }

                        if (Documentos == null || Documentos.Count == 0)
                        {
                            Documentos = DAOAsociacionDocumento.Instancia().Buscar(Contexto.CodigoPais,
                                TipoAsociacionDocumentoHome.Pais().Id, TipoDocumento.Id);
                        }
                    }
                }

                AddAllDocumentos(Grupo.Documentos, Documentos);
            }

        }

        public IList<GrupoClausula> Buscar(ContextoGrupoPorRango Contexto)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("CodigoPais", Contexto.CodigoPais);
            Parametros.AgregarParametro("CodigoProducto", Contexto.CodigoProducto);
            Parametros.AgregarParametro("CodigoTarifa", Contexto.CodigoTarifa);
            Parametros.AgregarParametro("Anual", Contexto.Anual);

            IList<GrupoClausula> Grupos = Buscar(
                new Filtro(Parametros, "dbo.GrupoClausula_Tx_Tarifa"), true);

            foreach (GrupoClausula Grupo in Grupos)
            {
                Grupo.Objetos = DAOObjetoAgrupadorClausula.Instancia().
                    Buscar(Grupo.Id);

                Grupo.Textos = DAOAsociacionTexto.Instancia().Buscar(
                    Grupo.Id, Contexto.IdTipoPlan);

                ObtenerDocumentos(Contexto, Grupo);

                Grupo.Contenidos = DAOContenidoClausula.Instancia().Buscar(Grupo.Id, true);

                foreach (ContenidoClausula Contenido in Grupo.Contenidos)
                {
                    
                    Contenido.Contenidos = DAOContenidoClausulaRango.Instancia().
                        Buscar(Contexto, Contenido.Id);
                    Contenido.Padres = DAOAsociacionContenidoClausula.Instancia().
                        Buscar(Contenido.Id, true);
                }
            }

            return Grupos;
        }

        public IList<GrupoClausula> BuscarSimple(ContextoGrupoPorRango Contexto)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("CodigoPais", Contexto.CodigoPais);
            Parametros.AgregarParametro("CodigoProducto", Contexto.CodigoProducto);
            Parametros.AgregarParametro("CodigoTarifa", Contexto.CodigoTarifa);
            Parametros.AgregarParametro("Anual", Contexto.Anual);

            IList<GrupoClausula> Grupos = Buscar(
                new Filtro(Parametros, "dbo.GrupoClausula_Tx_Tarifa"), true);

            foreach (GrupoClausula Grupo in Grupos)
            {
                Grupo.Objetos = DAOObjetoAgrupadorClausula.Instancia().
                    Buscar(Grupo.Id);

                Grupo.Contenidos = DAOContenidoClausula.Instancia().Buscar(Grupo.Id, true);

                foreach (ContenidoClausula Contenido in Grupo.Contenidos)
                {
                    Contenido.Contenidos = DAOContenidoClausulaRango.Instancia().
                        Buscar(Contexto, Contenido.Id);
                    Contenido.Padres = DAOAsociacionContenidoClausula.Instancia().
                        Buscar(Contenido.Id, true);
                }
            }

            return Grupos;
        }

        //SLA
        public IList<GrupoClausula> BuscarSLA(ContextoGrupoPorRango Contexto)
        {
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("CodigoPais", Contexto.CodigoPais);
            parametros.AgregarParametro("IdTipoGrupoClausula", Contexto.IdTipoGrupoClausula);
            parametros.AgregarParametro("CodigoAgencia", Contexto.CodigoAgencia);
            parametros.AgregarParametro("NumeroSucursal", Contexto.NumeroSucursal);

            IList<GrupoClausula> Grupos = Buscar(new Filtro(parametros, "dbo.GrupoClausula_Tx_AgenciaSucursal"), true);

            foreach (GrupoClausula Grupo in Grupos)
            {
                Grupo.Objetos = DAOObjetoAgrupadorClausula.Instancia().
                    Buscar(Grupo.Id);

                Grupo.Contenidos = DAOContenidoClausula.Instancia().Buscar(Grupo.Id, true);

                foreach (ContenidoClausula Contenido in Grupo.Contenidos)
                {
                    Contenido.Contenidos = DAOContenidoClausulaRango.Instancia().
                        Buscar(Contexto, Contenido.Id);
                    Contenido.Padres = DAOAsociacionContenidoClausula.Instancia().
                        Buscar(Contenido.Id, true);
                }
            }

            return Grupos;
        }

        //Fin SLA

        public void Modificar(int IdGrupoClausula, int IdTextoResumen)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdTextoResumen", IdTextoResumen);

            Modificar("dbo.GrupoClausula_M_TextoResumen", Parametros);
        }

        public void Modificar(int IdGrupoClausula, int IdTipoDocumento, int IdDocumento)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdGrupoClausula", IdGrupoClausula);
            Parametros.AgregarParametro("IdTipoDocumento", IdTipoDocumento);
            Parametros.AgregarParametro("IdDocumento", IdDocumento);
            Parametros.AgregarParametro("CodigoTipoAsociacionDocumento", "GRUP");

            Modificar("dbo.GrupoClausula_M_Documento", Parametros);
        }

        public bool Existe(Tarifa Tarifa, TipoGrupoClausula TipoGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoGrupoClausula", TipoGrupoClausula.Id);
            Parametros.AgregarParametro("IdTarifa", Tarifa.Id);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Existe(new Filtro(Parametros, "dbo.GrupoClausula_Tx_IdTarifa"));
        }

        public bool Existe(int IdObjeto, TipoGrupoClausula TipoGrupoClausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdTipoGrupoClausula", TipoGrupoClausula.Id);
            Parametros.AgregarParametro("IdTarifa", IdObjeto);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Existe(new Filtro(Parametros, "dbo.GrupoClausula_Tx_IdTarifa"));
        }

        public bool Existe(Clausula Clausula)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdClausula", Clausula.Id);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());
            
            return Existe(new Filtro(Parametros, "dbo.GrupoClausula_Tx_IdClausula"));
        }

        public IList<GrupoClausula> Buscar(Documento Documento)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("IdDocumento", Documento.Id);
            Parametros.AgregarParametro("IdTipoAsociacionDocumento", TipoAsociacionDocumentoHome.Grupo().Id);
            Parametros.AgregarParametro("IdEstadoEliminado", ObjetoNegocio.Eliminado());

            return Buscar(new Filtro(Parametros, "dbo.GrupoClausula_Tx_IdDocumento"));
        }
    }
}
