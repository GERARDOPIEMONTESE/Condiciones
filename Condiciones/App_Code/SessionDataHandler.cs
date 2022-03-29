using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using AjaxControlToolkit;
using System.Web.Configuration;
using System.Web.UI;
using Backend.Dominio;

public class SessionDataHandler
{
    public const string MODALIDAD = "Modalidad";
    public const string PAIS = "Pais";
    public const string TIPO_GRUPO_CLAUSULA = "TipoGrupoClausula";
    public const string PRODUCTO = "Producto";
    public const string TARIFAS = "Tarifas";
    public const string SUCURSALES = "Sucursales";
    public const string ANUAL = "Anual";
    public const string DIAS_CONSECUTIVOS = "DiasConsecutivos";
    public const string CONTENIDO = "Contenido";
    public const string CLAUSULA_SELECCIONADA = "ClausulaSeleccionada";
    public const string ADJUNTOS = "Adjuntos";
    public const string SETEA_PADRES = "SeteaPadres";
    public const string CLAUSULA_EDITAR = "ClausulaEditar";
    public const string MODALIDAD_CREAR = "new";
    public const string MODALIDAD_EDITAR = "edit";
    public const string MODALIDAD_COPIAR = "copy";
    public const string GRUPO_CLAUSULAS = "GrupoClausulas";
    public const string GRUPO_CLAUSULAS_MASIVO = "GrupoClausulas";
    public const string CLAUSULAS_MASIVO = "Clausulas";
    public const string TIPO_TEXTO = "TipoTexto";
    public const string TEXTO = "Texto";
    public const string ID_GRUPO_CLAUSULA_CONSULTA = "IdGrupoClausula";
    public const string MODIFICACION_MASIVA_TEXTO = "Texto";
    public const string MODIFICACION_MASIVA_CONTENIDO = "Contenido";
    public const string MODIFICACION_MASIVA_DOCUMENTO = "Documento";
    public const string DOCUMENTO = "DocumentoAbm";
    public const string ASOCIACIONES_DOCUMENTO_PAISES = "AsociacionesDocumentoPaises";
    public const string ASOCIACIONES_DOCUMENTO_PRODUCTOS = "AsociacionesDocumentoProductos";
    public const string ASOCIACIONES_DOCUMENTO_GRUPOS_CLAUSULAS = "AsociacionesDocumentoGruposClausulas";

    public static void RedireccionarFin(HttpResponse Response, string QueryString)
    {
        Response.Redirect("./ListaDeGrupoClausulas.aspx" + QueryString);
    }

    public static void RedireccionarFinSLA(HttpResponse Response, string QueryString, bool raiz)
    {
        if (!raiz)
            Response.Redirect("./ListaDeGrupoClausulasSLA.aspx" + QueryString);
        else
            Response.Redirect("./SLA/ListaDeGrupoClausulasSLA.aspx" + QueryString);
    }

    public static TipoGrupoClausula TipoGrupoClausula(HttpSessionState Session)
    {
        return (TipoGrupoClausula)Session[TIPO_GRUPO_CLAUSULA];
    }

    public static TipoTexto TipoTexto(HttpSessionState Session)
    {
        return (TipoTexto)Session[TIPO_TEXTO];
    }

    public static Texto Texto(HttpSessionState Session)
    {
        return (Texto)Session[TEXTO];
    }

    public static int IdGrupoClausulaConsulta(HttpSessionState Session)
    {
        return Convert.ToInt32(Session[ID_GRUPO_CLAUSULA_CONSULTA]);
    }

    public static bool ObtenerSeteaPadres(HttpSessionState Session)
    {
        return Session[SETEA_PADRES] == null ?  false :(bool)Session[SETEA_PADRES];
    }

    public static void SetearSeteaPadres(HttpSessionState Session, bool SeteaPadres)
    {
        Session[SETEA_PADRES] = SeteaPadres;
    }
}