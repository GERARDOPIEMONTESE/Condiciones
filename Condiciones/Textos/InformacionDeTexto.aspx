<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="InformacionDeTexto.aspx.cs"
    Inherits="Condiciones.InformacionDeTextoResumen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register TagPrefix="Generar" TagName="TextoBeneficio" Src="~/Controles/TextosResumen.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:ScriptManager ID="SManager" runat="server" EnablePageMethods="true" />
        <asp:SiteMapPath ID="SiteMapPath" runat="server" CssClass="Text_SiteMap" />
        <fieldset>
            <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="Text_Normal" />
                        <asp:TextBox ID="TbNombre" runat="server" CssClass="TextBox_X" />
                        <asp:Label ID="LTipoTextoResumen" runat="server" Text="Impresion:" CssClass="Text_Normal" />
                        <asp:DropDownList ID="DdlTipoTextoResumen" runat="server" DataSourceID="OdsTipoTextoResumen"
                            DataTextField="Descripcion" DataValueField="Id" CssClass="DropDownList_M" />
                        <asp:ObjectDataSource ID="OdsTipoTextoResumen" runat="server" SelectMethod="Buscar"
                            TypeName="Backend.Homes.TipoTextoResumenHome"></asp:ObjectDataSource>
                        <asp:RequiredFieldValidator ID="RfvNombre" ValidationGroup="Guardar" runat="server"
                            Display="None" ControlToValidate="TbNombre" ErrorMessage="El nombre no puede ser vacío."><img src="../IMG/error.gif" alt="El nombre no puede ser vacío." title="El nombre no puede ser vacío." /></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CVNombreTexto" runat="server" ErrorMessage="Codigo Existente"
                            Text="Nombre Existente" ControlToValidate="TbNombre" Display="None" ValidationGroup="Guardar" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="btn-cntnr-large">
                        <br />
                        <table border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel runat="server" ID="UpTexto">
                                        <ContentTemplate>
                                            <ajx:TabContainer ID="TCIdioma" runat="server" AutoPostBack="false" Style="text-align: left;" />
                                            <div class="btn-cntnr-large" style="margin-top: 5px;">
                                                <asp:Label ID="lblNombreMascara" runat="server" Text="Máscara:" CssClass="Text_Normal" />
                                                <asp:TextBox ID="TbMascara" runat="server" CssClass="TextBox_S"></asp:TextBox>
                                                <asp:Button ID="BAgregarMascara" runat="server" Text="Agregar" OnClick="BAgregarMascara_Click"
                                                    CssClass="Button_Normal" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                        <table border="0" cellpadding="1" cellspacing="1" width="700">
                            <tr>
                                <td align="right" class="btn-cntnr-large">
                                    <asp:Button ID="bVolver" runat="server" Text="Volver" OnClick="bVolver_Click" CssClass="Button_Normal" />
                                    &nbsp;
                                    <asp:Button ID="bAgregar" runat="server" Text="Grabar" ValidationGroup="Guardar"
                                        OnClick="bAgregar_Click" CssClass="Button_Normal" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:ValidationSummary runat="server" DisplayMode="BulletList" CssClass="TextError_Normal"
                                        ValidationGroup="Guardar" ID="VsValidador" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
