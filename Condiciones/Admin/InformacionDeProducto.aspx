<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformacionDeProducto.aspx.cs" Inherits="Condiciones.Admin.InformacionDeProducto" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register src="../Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Espera.css" type="text/css" />
    <script src="../Js/Condiciones.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function Confirm() {
            if ((document.getElementById("TbCodigoPais").value != '') && (document.getElementById("TbCodigo").value != '') && (document.getElementById("TbNombre").value != '')) {
                if (confirm('Desea confirmar la operación?')) {
                    document.getElementById("BAceptar").click();
                } else {
                    return false;
                }
            }
            else {
                document.getElementById("BValidar").click();
                return false;
            }
        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:UpdatePanel runat="server" ID="UpDatos">
            <ContentTemplate>
                <fieldset>
                    <asp:Panel runat="server" ID="pnl" DefaultButton="BAceptar">
                        <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                            <tr>
                                <td align="center">
                                    <table border="0" cellpadding="1" cellspacing="1" align="center" width="70%">
                                        <tr>
                                            <td align="left" width="10%">
                                                <asp:Label ID="LTipoGrupo" runat="server" Text="Tipo:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:DropDownList ID="DdlTipoGrupo" runat="server" CssClass="DropDownList_X" />
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left" width="10%">
                                                <asp:Label ID="LCodigoPais" runat="server" Text="País:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:TextBox ID="TbCodigoPais" runat="server" CssClass="TextBox_X" MaxLength="3" />
                                            </td>
                                            <td align="center">
                                                <asp:RegularExpressionValidator ID="RevCodigoPais" runat="server" ValidationExpression="\d{1,3}" ControlToValidate="TbCodigoPais" ValidationGroup="Guardar" CssClass="Text_Error" ErrorMessage="El código del país es un dato numérico."
                                                    Display="Dynamic"><img src="../IMG/error.gif" alt="El código del país es un dato numerico" title="El código del país es un dato numerico" /></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RfvCodigoPais" runat="server" ControlToValidate="TbCodigoPais" ValidationGroup="Guardar" CssClass="Text_Error" ErrorMessage="El código del país es obligatorio." Display="Dynamic"><img src="../IMG/error.gif" alt="El código del país es obligatorio." title="El código del país es obligatorio." /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="LCodigo" runat="server" Text="Código:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TbCodigo" runat="server" CssClass="TextBox_X" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RfvCodigo" runat="server" ControlToValidate="TbCodigo" CssClass="Text_Error" ValidationGroup="Guardar" ErrorMessage="El código del producto/business es obligatorio."><img src="../IMG/error.gif" alt="El código del producto/business es obligatorio." title="El código del producto/business es obligatorio." /></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="LNombre" runat="server" Text="Nombre:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TbNombre" runat="server" CssClass="TextBox_X" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RfvNombre" runat="server" ControlToValidate="TbCodigo" CssClass="Text_Error" ValidationGroup="Guardar" ErrorMessage="El nombre del producto/business es obligatorio."><img src="../IMG/error.gif" title="El nombre del producto/business es obligatorio." alt="El nombre del producto/business es obligatorio." /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="5" class="btn-cntnr">
                                                <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" />
                                                <asp:Button ID="BAceptar" runat="server" Text="Aceptar" OnClick="BAceptar_Click" CssClass="Button_Normal" ValidationGroup="Guardar" OnClientClick="javascript:return Confirm();" />
                                                <asp:Button ID="BValidar" runat="server" ValidationGroup="Guardar" CssClass="Invisible" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
          <asp:UpdateProgress ID="UpEsperaAccion" runat="server">
            <ProgressTemplate>
                <div class="ProgressBanner">
                    <img src="../IMG/loading.gif" alt="Cargando Página" />
                    <p>
                        Cargando Página ...
                    </p>
                /div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <uc1:SessionController ID="SessionController1" runat="server" />
    </div>
    </form>
</body>
</html>
