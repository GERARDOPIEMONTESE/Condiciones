<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucContenidoClausula.ascx.cs" Inherits="Condiciones.Controles.WucContenidoClausula" %>
<%@ Register TagPrefix="wuc" TagName="Condicion" Src="~/Controles/WucCondicionClausula.ascx" %>
<%@ Register TagPrefix="wl" TagName="Leyenda" Src="~/Controles/WucLeyenda.ascx" %>
<table border="0" cellpadding="1" cellspacing="1" align="center" style="margin-right: 0px">

    <tr>
        <td>
            <asp:Label ID="LEdadMinima" runat="server" Text="Edad Minima:" CssClass="Text_Normal" />
        </td>
        <td>
            <asp:TextBox ID="TbEdadMinima" runat="server" MaxLength="3" Text="0" CssClass="Text_Normal" Columns="6" />
            <asp:RegularExpressionValidator ID="RevEdadMinima" runat="server" ValidationExpression="\d{1,3}" ControlToValidate="TbEdadMinima" Display="None" ValidationGroup="Guardar" ErrorMessage="La Edad Mínima debe contener solo dígitos." ><img src="../IMG/error.gif" alt="La Edad Mínima debe contener solo dígitos" title="La Edad Mínima debe contener solo dígitos" /></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RfvEdadMinima" runat="server" ControlToValidate="TbEdadMinima" Display="None" ValidationGroup="Guardar" ErrorMessage="La Edad Mínima no puede estar vacía" ><img src="../IMG/error.gif" alt="La Edad Mínima no puede estar vacía" title="La Edad Mínima no puede estar vacía" /></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CVEdadMinima" runat="server" ControlToValidate="TbEdadMinima" ControlToCompare="TbEdadMaxima" Type="Integer" Operator="LessThanEqual" Display="None" ValidationGroup="Guardar" ErrorMessage="La Edad Mínima debe ser menor o igual que la Edad Máxima." ><img src="../IMG/error.gif" alt="La Edad Mínima debe contener solo dígitos" title="La Edad Mínima debe contener solo dígitos" /></asp:CompareValidator>
        </td>
        <td>
            <asp:Label ID="LEdadMaxima" runat="server" Text="Edad Máxima:" CssClass="Text_Normal" />
        </td>
        <td>
            <asp:TextBox ID="TbEdadMaxima" runat="server" MaxLength="3" Text="120" CssClass="Text_Normal" Columns="6" />
            <asp:RegularExpressionValidator ID="RevEdadMaxima" runat="server" ValidationExpression="\d{1,3}" ControlToValidate="TbEdadMaxima" Display="None" ValidationGroup="Guardar" ErrorMessage="La Edad Máxima debe contener solo dígitos." ><img src="../IMG/error.gif" title="La Edad Máxima debe contener solo dígitos." alt="La Edad Máxima debe contener solo dígitos." /></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RfvEdadMaxima" runat="server" ControlToValidate="TbEdadMaxima" Display="None" ValidationGroup="Guardar" ErrorMessage="La Edad Máxima no puede estar vacía" ><img src="../IMG/error.gif" alt="La Edad Máxima no puede estar vacía" title="La Edad Máxima no puede estar vacía" /></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TbEdadMaxima" ValueToCompare="150" Type="Integer" Operator="LessThanEqual" Display="None" ValidationGroup="Guardar" ErrorMessage="La Edad Maxima no puede superar los 150." ><img src="../IMG/error.gif" alt="La Edad Maxima no puede superar los 150." title="La Edad Maxima no puede superar los 150." /></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LTipoModalidad" runat="server" Text="Modalidad:" CssClass="Text_Normal" />
        </td>
        <td>
            <asp:DropDownList ID="DdlTipoModalidad" runat="server" CssClass="DropDownList_SM" />
        </td>
        <td>
            <asp:Label ID="LCategoria" runat="server" Text="Categoria:" CssClass="Text_Normal" />
        </td>
        <td>
            <asp:TextBox ID="TbCategoria" runat="server" MaxLength="10" Text="0" CssClass="Text_Normal" Columns="6" />
            <asp:RequiredFieldValidator ID="RfvCategoria" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbCategoria" ErrorMessage="La categoria en % no puede estar vacía." ><img src="../IMG/error.gif" alt="La categoria en % no puede estar vacía." title="La categoria en % no puede estar vacía." /> </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LPlanFamiliar" runat="server" Text="Tipo Plan:" CssClass="Text_Normal" />
        </td>
        <td colspan="3">
            <asp:DropDownList ID="DdlTipoPlan" runat="server" CssClass="DropDownList_SM" />
        </td>
    </tr>
    <tr style="display:none;">
        <td>
            <asp:Label ID="LContenido" runat="server" Text="Fórmula:" CssClass="Text_Normal" />
        </td>
        <td colspan="3">
            <wuc:Condicion runat="server" ID="Condicion" />
        </td>
    </tr>
<%--    <asp:UpdatePanel ID="UpClausulas" runat="server">
        <ContentTemplate>--%>
        
        <tr>
            <td>
                <asp:Label ID="L1Contenido" runat="server" Text="Fórmula:" CssClass="Text_Normal" />
            </td>
            <td colspan="3">
                <asp:DropDownList ID="DdlContenidosValidadores" runat="server" CssClass="DropDownList_X" style="width:85px" OnSelectedIndexChanged="DdlContenidosValidadores_IndexChanged" AutoPostBack="true"/>
                <asp:DropDownList ID="DdlIgual" Visible="false" runat="server" CssClass="DropDownList_X" style="width:107px" >
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="IGUAL" Value="IGUAL"></asp:ListItem>
                    <asp:ListItem Text="MENOR-IGUAL" Value="MENOR-IGUAL"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:TextBox ID="tbNumero" Visible="false" runat="server" Style="width:90px" CssClass="Text_Normal" />
                <asp:DropDownList ID="DdlCurrency" Visible="false" runat="server" CssClass="DropDownList_X" style="width:90px">
                    <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                    <asp:ListItem Text="R$" Value="R$"></asp:ListItem>
                    <asp:ListItem Text="Euros" Value="Euros"></asp:ListItem>

                </asp:DropDownList>
                <asp:Label ID="lbFormulaError" runat="server" Value="" Visible="true" Style="font-family: 'Roboto',Helvetica;font-size: 9px;color: Red;text-align: left;font-weight: bold;"></asp:Label>
            </td>
        </tr>
<%--        <tr>
            <asp:Panel ID="pFormula" runat="server">
                
            </asp:Panel>
        </tr>--%>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <tr>
        <td>
            <asp:Label runat="server" ID="Label1" Text="Validez Territorial" CssClass="Text_Normal" />
        </td>
        <td colspan="3">
            <asp:DropDownList ID="DdlValidezTerritorialClausula" runat="server" CssClass="DropDownList_X" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="LValidezTerritorial" Text="Paises" CssClass="Text_Normal" />
        </td>
        <td colspan="3">
            <asp:DropDownList ID="DdlValidezTerritorial" runat="server" CssClass="DropDownList_X" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="LLeyenda" Text="Contenido (Impresión)" CssClass="Text_Normal" />
        </td>
        <td colspan="3">
            <wl:Leyenda runat="server" ID="WlLeyendas"></wl:Leyenda>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblPeso" runat="server" Text="Peso: " Visible="false" DefaultValue="0"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPeso" runat="server" ReadOnly="true" Visible="false" style="width:100px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPeso" runat="server" ErrorMessage="Debe cagar un valor." Enabled="false" ControlToValidate="txtPeso"><img src="../IMG/error.gif" title="Debe cagar un valor." alt="Debe cagar un valor." /></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Button ID="btnCalcular" runat="server" Visible="false" onclientclick="recalcularPeso()" CssClass="Button_Normal" Text="Recalcular"/>
        </td>
    </tr>
</table>
