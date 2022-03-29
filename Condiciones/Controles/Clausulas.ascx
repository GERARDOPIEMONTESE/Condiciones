<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Clausulas.ascx.cs" Inherits="Condiciones.Controles.Clausulas" %>
<table border="0" cellpadding="1" cellspacing="1">
    <tr>
        <td>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="Texto_Normal" />
        </td>
        <td>
            <asp:TextBox ID="TbNombre" runat="server" CssClass="TextBox_MultipleLinea_L" TextMode="MultiLine" Width="700" Height="300"/>
            <asp:RequiredFieldValidator ID="RfvNombre" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbNombre" ErrorMessage="El nombre en % no puede ser vacío." ><img src="../IMG/error.gif" alt="El nombre en % no puede ser vacío." title="El nombre en % no puede ser vacío." /></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
