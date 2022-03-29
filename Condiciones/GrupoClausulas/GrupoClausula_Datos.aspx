<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrupoClausula_Datos.aspx.cs" Inherits="Condiciones.GrupoClausulas.GrupoClausula_Datos" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Espera.css" type="text/css" />

    <script src="../Js/Condiciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:UpdatePanel runat="server" ID="UpDatos">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td style="text-align: left;">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="LTipoGrupo" runat="server" Text="Tipo:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:ObjectDataSource ID="OdsTipoGrupoClausula" runat="server" SelectMethod="Buscar" TypeName="Backend.Homes.TipoGrupoClausulaHome"></asp:ObjectDataSource>
                                        <asp:DropDownList ID="DdlTipoGrupoClausula" runat="server" DataSourceID="OdsTipoGrupoClausula" CssClass="DropDownList_M" DataTextField="Nombre" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="DdlTipoGrupoClausula_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="LAnual" runat="server" Text="Es Anual:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="CbAnual" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:ObjectDataSource ID="OdsPais" runat="server" SelectMethod="Buscar" TypeName="Backend.Homes.PaisHome"></asp:ObjectDataSource>
                                        <asp:DropDownList ID="DdlPais" runat="server" DataSourceID="OdsPais" CssClass="DropDownList_M" DataTextField="Nombre" AutoPostBack="true" DataValueField="Codigo" OnDataBound="DropDownList_DataBound" OnSelectedIndexChanged="DdlPais_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="LProducto" runat="server" Text="Producto:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlProducto" runat="server" DataValueField="Id" DataTextField="CodigoYNombre" OnDataBound="DropDownList_DataBound" AutoPostBack="true" CssClass="DropDownList_M">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvDdlProducto" ErrorMessage="Seleccione un Producto" ValidationGroup="Validar" ControlToValidate="DdlProducto"><img alt="Seleccione un Producto" title="Seleccione un Producto" src="../IMG/error.gif" /></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="LCodigoTarifa" runat="server" Text="Tarifa:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="TbCodigoTarifa" CssClass="TextBox_S"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LSufijo" runat="server" Text="Sufijo:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="TbSufijo" Width="40px" CssClass="Text_Normal" />
                                        <ajx:AutoCompleteExtender ID="AceSufijo" runat="server" ServicePath="~/Servicios/ServicioAutocompletarSufijo.asmx" ServiceMethod="GetSuggestions" TargetControlID="TbSufijo" MinimumPrefixLength="1" CompletionSetCount="12">
                                        </ajx:AutoCompleteExtender>
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <br />
                            <table width="100%">
                                <tr>
                                    <td align="center" style="border-right: 1px; border-right-style: solid; vertical-align: top;">

                                        <asp:GridView ID="GvTarifas" runat="server" ShowHeaderWhenEmpty="true"
                                            PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="17" 
                                            Width="500" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                            AllowPaging="True" AllowSorting="True" 
                                            OnRowDataBound="GvTarifas_RowDataBound" 
                                            OnPageIndexChanging="GvTarifas_PageIndexChanging" 
                                            RowStyle-CssClass="GridView_Row_Data_Normal" CssClass="tbl-generic" 
                                            EmptyDataText="No hay registros">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="CbGrupoClausula" EnableViewState="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Id" DataField="Id" />
                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                                                <asp:BoundField HeaderText="Sufijo" DataField="Sufijo" />
                                                <asp:TemplateField HeaderText="Anual">
                                                    <ItemTemplate>
                                                        <%#Eval("Anual").ToString() == "False" ? "No": "Sí" %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Modalidad" DataField="TipoModalidad" />
                                            </Columns>
                                            <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                            <PagerStyle CssClass="GridView_Pager_Normal" />
                                            <RowStyle CssClass="GridView_Row_Data_Normal" />
                                        </asp:GridView>
                                    </td>
                                    <td align="center" style="vertical-align: top; border-left-width: 1px; border-left-style: solid;">
                                        <div style="width: 100%; max-height: 400px; overflow: auto;">
                                            <asp:GridView ID="GvTarifasCheck" runat="server" ShowHeaderWhenEmpty="true"
                                                PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" DataKeyNames="Id" 
                                                Width="500" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                AllowPaging="false" AllowSorting="True" 
                                                OnRowDataBound="GvTarifasCheck_RowDataBound" 
                                                RowStyle-CssClass="GridView_Row_Data_Normal" CssClass="tbl-generic" 
                                                EmptyDataText="No hay registros" >
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="CbGrupoClausula" EnableViewState="true" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                                                    <asp:BoundField HeaderText="Sufijo" DataField="Sufijo" />
                                                    <asp:TemplateField HeaderText="Anual">
                                                        <ItemTemplate>
                                                            <%#Eval("Anual").ToString() == "False" ? "No": "Sí" %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Modalidad" DataField="TipoModalidad" />
                                                </Columns>
                                                <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                                <PagerStyle CssClass="GridView_Pager_Normal" />
                                                <RowStyle CssClass="GridView_Row_Data_Normal" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                                                                <asp:CustomValidator ID="CVSeleccionTarifas" runat="server" ErrorMessage="Seleccionar tarifa" Text="Seleccionar tarifa" Visible="false" CssClass="Text_Error">
                                            <img src="../IMG/error.gif" alt="Seleccionar tarifa" title="Seleccionar tarifa" />
                                        </asp:CustomValidator>
                                        <asp:ValidationSummary runat="server" ID="vsErrores" ShowMessageBox="false" 
                                            DisplayMode="SingleParagraph" EnableClientScript="true">
                                        </asp:ValidationSummary>
                            <asp:Label runat="server" ID="LErrorTarifas" Visible="False" 
                                CssClass="Text_Error"></asp:Label></td></table></ContentTemplate></asp:UpdatePanel><table border="0" cellpadding="1" cellspacing="1" align="center">
            <tr>
                <td class="btn-cntnr-large">
                    <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" />
                    <asp:Button ID="BContinuar" runat="server" Text="Continuar" OnClick="BContinuar_Click" CssClass="Button_Normal" ValidationGroup="Validar" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
