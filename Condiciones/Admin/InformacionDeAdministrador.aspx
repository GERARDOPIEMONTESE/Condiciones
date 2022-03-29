<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformacionDeAdministrador.aspx.cs" Inherits="Condiciones.Admin.InformacionDeAdministrador" ValidateRequest="false" %>

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
            if ((document.getElementById("TbNombre").value != '') && (document.getElementById("TbCodigo").value != '')) {
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
        <asp:UpdatePanel ID="UpClausulas" runat="server">
            <ContentTemplate>
                <fieldset>
                    <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Panel runat="server" ID="pnlEdicion" DefaultButton="BAceptar">
                                    <table border="0" cellpadding="1" cellspacing="1" align="center">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="LTipo" runat="server" Text="Tipo: " CssClass="Text_Normal_R" />
                                            </td>
                                            <td>
                                                <asp:Label ID="LNombreTipo" runat="server" Text="" CssClass="Text_Subtitle" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblCodigo" runat="server" Text="Código:" CssClass="Text_Normal_R" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TbCodigo" runat="server" CssClass="TextBox_X" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvTbCodigo" runat="server" ControlToValidate="TbCodigo" ValidationGroup="Guardar" CssClass="Text_Error" ErrorMessage="El Código es obligatorio."><img src="../IMG/error.gif" alt="El Código es obligatorio." title="El Código es obligatorio." /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="Text_Normal_R" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TbNombre" runat="server" CssClass="TextBox_X" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvTbNombre" runat="server" ControlToValidate="TbNombre" ValidationGroup="Guardar" CssClass="Text_Error" ErrorMessage="El Nombre es obligatorio."><img src="../IMG/error.gif" alt="El Nombre es obligatorio." title="El Nombre es obligatorio." /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" CssClass="Text_Normal_R" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TbDescripcion" runat="server" CssClass="TextBox_X" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2" class="btn-cntnr">
                                                <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" />
                                                <asp:Button ID="BAceptar" runat="server" Text="Aceptar" OnClick="BAceptar_Click" CssClass="Button_Normal" ValidationGroup="Guardar" OnClientClick="javascript:return Confirm();" />
                                                <asp:Button ID="BEliminar" runat="server" Text="Eliminar" OnClick="BEliminar_Click" CssClass="Button_Normal" Visible="false" OnClientClick="javascript:return confirm('Desea confirmar la operación?');" />
                                                <asp:Button ID="BValidar" runat="server" ValidationGroup="Guardar" CssClass="Invisible" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
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
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <uc1:SessionController ID="SessionController1" runat="server" />
    </div>
    </form>
</body>
</html>
