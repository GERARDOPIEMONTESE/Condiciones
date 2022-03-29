<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="InformacionDeDocumento.aspx.cs" Inherits="Condiciones.InformacionDeDocumento" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register src="../Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
    <script src="../Js/Condiciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Panel runat="server" ID="pnl" DefaultButton="bGrabar">
            <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                <tr>
                    <td align="center">
                        <table border="0" cellpadding="1" cellspacing="1" align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo Documento:" CssClass="Text_Normal_R" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="DdlTipoDocumento" runat="server" CssClass="DropDownList_X" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblIdioma" runat="server" Text="Idioma Documento:" CssClass="Text_Normal_R" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="DdlIdioma" runat="server" CssClass="DropDownList_X" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="Text_Normal_R" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TbNombre" runat="server" CssClass="TextBox_X" />
                                    <asp:RequiredFieldValidator ID="RfvNombre" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbNombre" ErrorMessage="El nombre del documento no puede ser vacío."><img src="../IMG/error.gif" alt="El nombre del documento no puede ser vacío" title="El nombre del documento no puede ser vacío" /><img src="../IMG/error.gif" alt="El nombre del documento no puede ser vacío" title="El nombre del documento no puede ser vacío" /></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LObservaciones" runat="server" Text="Observaciones:" CssClass="Text_Normal_R" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TbObservaciones" runat="server" CssClass="TextBox_X" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbObservaciones" ErrorMessage="Las observaciones del documento no pueden estar vacías."><img src="../IMG/error.gif" alt="Las observaciones del documento no pueden ser vacías" title="Las observaciones del documento no pueden ser vacías" /><img src="../IMG/error.gif" alt="Las observaciones del documento no pueden ser vacías" title="Las observaciones del documento no pueden ser vacías" /></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDocumento" runat="server" Text="Documento:" CssClass="Text_Normal_R" />
                                </td>
                                <td class="btn-cntnr-large">
                                    <asp:FileUpload ID="FDocumento" runat="server" CssClass="Button_Normal" />
                                    <asp:RequiredFieldValidator ID="RfvDocumento" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="FDocumento" ErrorMessage="Por favor seleccione un documento para cargar."><img src="../IMG/error.gif" alt="Por favor seleccione un documento para cargar." title="Por favor seleccione un documento para cargar." /></asp:RequiredFieldValidator>
                                    <asp:FileUpload ID="FDocumentoModif" runat="server" CssClass="Button_Normal" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" class="btn-cntnr-large">
                                    <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" />
                                    <asp:Button ID="bGrabar" runat="server" Text="Grabar" OnClick="bGrabar_Click" CssClass="Button_Normal" Visible="true" ValidationGroup="Guardar"  />
                                    <asp:Button ID="BEliminar" runat="server" Text="Eliminar" OnClick="BEliminar_Click" CssClass="Button_Normal" Visible="false" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:Label runat="server" ID="lblMensajesAsociados" ForeColor="Red" Visible="false" CssClass="TextError_Normal">No se puede eliminar un documento con paises, productos y/o clausulas asociadas</asp:Label>
                                    <asp:Label runat="server" ID="lblErrorFileSize" ForeColor="Red" Visible="false" CssClass="TextError_Normal">El archivo no pude superar los 4 MB</asp:Label>
                                    <asp:ValidationSummary runat="server" DisplayMode="BulletList" CssClass="TextError_Normal" ValidationGroup="Guardar" ID="VsValidador" />
                                </td>
                            </tr>
                        </table>
                        <asp:Label runat="server" ID="lblMensajeError" CssClass="TextError_Normal"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <table cellpadding="1" cellspacing="1" align="center" width="100%" class="tbl-doc-assoc">
            <tr>
                <th>
                    Asociar Documentos a Países o Productos
                </th>
                <th>
                    Documentos Asociados Actuales
                </th>
            </tr>
            <tr>
                <td class="doc-assoc">
                    <asp:TreeView ID="TVAsociaciones" runat="server" ShowCheckBoxes="All" Height="380px" Width="100%" Style="text-align: left; overflow: scroll" OnTreeNodePopulate="TVAsociaciones_TreeNodePopulate">
                        <NodeStyle Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
                <td class="doc-assoc">
                    <asp:TreeView ID="TVAsociacionesActuales" runat="server" Height="380px" Width="100%" Style="text-align: left; overflow: scroll">
                        <NodeStyle Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
            </tr>
        </table>
    </div>
   <uc1:SessionController ID="SessionController1" runat="server" />
    </form>
</body>
</html>
