﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using System.Transactions;
using FrameworkDAC.Negocio;



namespace Backend.Datos
{
    public class DAOSolicitudModificacionMasiva : DAOObjetoNegocio<SolicitudModificacionMasiva>
    {
         #region Singleton

        private static DAOSolicitudModificacionMasiva _Instancia;

        private DAOSolicitudModificacionMasiva()
        {
        }

        public static DAOSolicitudModificacionMasiva Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOSolicitudModificacionMasiva();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }
        
        protected override FrameworkDAC.Parametro.Parametros ParametrosCrear(SolicitudModificacionMasiva ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("Productos", ObjetoNegocio.Productos);
            Parametros.AgregarParametro("Paises", ObjetoNegocio.Paises);
            Parametros.AgregarParametro("TE", ObjetoNegocio.TE);
            Parametros.AgregarParametro("TTR", ObjetoNegocio.TTR);
            Parametros.AgregarParametro("IdTipoOperacion", ObjetoNegocio.IdTipOperacion);
            Parametros.AgregarParametro("CodigoClausulaUbicacion", ObjetoNegocio.CodigoClausulaUbicacion);
            Parametros.AgregarParametro("CodigoClausula", ObjetoNegocio.CodigoClausula);
            Parametros.AgregarParametro("EdadMinima", ObjetoNegocio.EdadMinima);
            Parametros.AgregarParametro("EdadMaxima", ObjetoNegocio.EdadMaxima);
            Parametros.AgregarParametro("Español", ObjetoNegocio.Español);
            Parametros.AgregarParametro("Ingles", ObjetoNegocio.Ingles);
            Parametros.AgregarParametro("Portugues", ObjetoNegocio.Portugues);
            
            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosModificar(SolicitudModificacionMasiva ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdSolicitudModifacionMasiva", ObjetoNegocio.Id);
            Parametros.AgregarParametro("Productos", ObjetoNegocio.Productos);
            Parametros.AgregarParametro("Paises", ObjetoNegocio.Paises);
            Parametros.AgregarParametro("TE", ObjetoNegocio.TE);
            Parametros.AgregarParametro("TTR", ObjetoNegocio.TTR);
            Parametros.AgregarParametro("IdTipoOperacion", ObjetoNegocio.IdTipOperacion);
            Parametros.AgregarParametro("CodigoClausulaUbicacion", ObjetoNegocio.CodigoClausulaUbicacion);
            Parametros.AgregarParametro("CodigoClausula", ObjetoNegocio.CodigoClausula);
            Parametros.AgregarParametro("EdadMinima", ObjetoNegocio.EdadMinima);
            Parametros.AgregarParametro("EdadMaxima", ObjetoNegocio.EdadMaxima);
            Parametros.AgregarParametro("Español", ObjetoNegocio.Español);
            Parametros.AgregarParametro("Ingles", ObjetoNegocio.Ingles);
            Parametros.AgregarParametro("Portugues", ObjetoNegocio.Portugues);

            return Parametros;
        }

        protected override FrameworkDAC.Parametro.Parametros ParametrosEliminar(SolicitudModificacionMasiva ObjetoNegocio)
        {
            Parametros Parametros = new Parametros();

            Parametros.AgregarParametro("IdSolicitudModifacionMasiva", ObjetoNegocio.Id);
            Parametros.AgregarParametro("IdEstado", ObjetoNegocio.IdEstado);

            return Parametros;
        }

        protected override void Completar(SolicitudModificacionMasiva ObjetoPersistido,System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdSolicitudModificacionMasiva"]);
            ObjetoPersistido.CodigoClausula = dr["CodigoClausula"].ToString();
            ObjetoPersistido.CodigoClausulaUbicacion = dr["CodigoClausulaUbicacion"].ToString();
            ObjetoPersistido.EdadMaxima = Convert.ToInt32(dr["EdadMaxima"].ToString());
            ObjetoPersistido.EdadMinima = Convert.ToInt32(dr["EdadMinima"].ToString());
            ObjetoPersistido.Español = dr["Español"].ToString();
            ObjetoPersistido.IdEstado = Convert.ToInt32(dr["IdEstado"].ToString());
            ObjetoPersistido.Ingles = dr["Ingles"].ToString();
            ObjetoPersistido.IdTipOperacion = Convert.ToInt32(dr["IdTipoOperacion"].ToString());
            ObjetoPersistido.Paises = dr["Paises"].ToString();
            ObjetoPersistido.Portugues = dr["Portugues"].ToString();
            ObjetoPersistido.Procesado = Convert.ToBoolean(dr["Procesado"].ToString());
            ObjetoPersistido.Productos = dr["Productos"].ToString();
            ObjetoPersistido.TE = dr["TE"].ToString();
            ObjetoPersistido.TTR = Convert.ToBoolean(dr["TTR"].ToString());

        }


      
        
    }
}
