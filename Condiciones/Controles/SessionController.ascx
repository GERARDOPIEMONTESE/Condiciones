<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SessionController.ascx.cs" Inherits="Condiciones.Controles.SessionController" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>

<script type="text/javascript" language="javascript">
    function Cerrar() {
        window.close();
    }
    function Redireccionar() {
        window.location = 'http://portal.assist-card.com/Usuarios/LogIn.aspx';

    }
    function RedireccionarConTiempo() {

        setTimeout("Redireccionar()", 8000);

    }
</script>

<link href="CSS/Espera.css" rel="stylesheet" type="text/css" />
<link href="CSS/Main.css" rel="stylesheet" type="text/css" />

<asp:TextBox runat="server" ID="txtURLLogin" Visible="false"></asp:TextBox>
<asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress" Visible="false">
    <div style="position: relative; top: 30%; text-align: center;">
        <table style="font-size: small">
            <tr>
                <td>
                    <img src="../IMG/error.gif" alt="Ha expirado la sesion" />
                    Ha expirado la sesión.
                </td>
            </tr>
            <tr>
                <td>
                    Por favor haga click en Login para autenticarse nuevamente o espera a ser redireccionado
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" id="btnCerrar" value="Cerrar" onclick="Cerrar();" />
                    <input type="button" id="btnLogin" value="Login" onclick="Redireccionar();" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress" PopupControlID="panelUpdateProgress" BackgroundCssClass="modalBackground" DropShadow="true" OkControlID="btnLogin">
</ajx:ModalPopupExtender>
