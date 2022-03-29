<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextosResumen.ascx.cs" Inherits="Condiciones.Controles.TextosResumen"  %>
<table border="0" cellpadding="1" cellspacing="1">
    <tr>
        <td>
            <asp:Label ID="lblTexto" runat="server" Text="Texto:" CssClass="Text_Normal" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TbTexto" runat="server" CssClass="TextBox_MultipleLine_M" TextMode="MultiLine" Height="320" />
            <asp:RequiredFieldValidator ID="RfvNombre" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbTexto" ErrorMessage="El texto en % no puede ser vacío." ><img src="../IMG/error.gif" alt="El texto en % no puede ser vacío." title="El texto en % no puede ser vacío." /></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
