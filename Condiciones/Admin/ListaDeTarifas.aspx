<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeTarifas.aspx.cs" Inherits="Condiciones.Admin.ListaDeTarifas" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
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
            var pais = document.getElementById("TbCodigoPais").value != '';
            var producto = document.getElementById("TbProducto").value != '';
            var codigo = document.getElementById("TbCodigo").value != '';
            var nombre = document.getElementById("TbNombre").value != '';

            if (pais && producto && codigo && nombre) {
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
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td style="text-align: left;">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="LTipoGrupo" runat="server" Text="Tipo:" CssClass="Text_Normal" />
                                    </td>
                                    <td width="15%">
                                        <asp:DropDownList ID="DdlTipoGrupoClausula" runat="server" CssClass="DropDownList_M" DataTextField="Nombre" AutoPostBack="true" OnSelectedIndexChanged="DdlTipoGrupoClausula_SelectedIndexChanged" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="Text_Normal" />
                                    </td>
                                    <td width="5%">
                                        <asp:DropDownList ID="DdlPais" runat="server" CssClass="DropDownList_M" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="DdlPais_SelectedIndexChanged" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvddlPais" runat="server" SetFocusOnError="true" ControlToValidate="DdlPais" ErrorMessage="Seleccione un País" InitialValue="0" CssClass="Text_Error" ValidationGroup="Buscar"><img src="../IMG/error.gif" alt="Seleccione un País" title="Seleccione un País" /> </asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="LProducto" runat="server" Text="Producto:" CssClass="Text_Normal" />
                                    </td>
                                    <td width="20%">
                                        <asp:DropDownList ID="DdlProducto" runat="server" AutoPostBack="true" CssClass="DropDownList_XX" EnableViewState="true" DataValueField="Id" DataTextField="CodigoYNombre" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" SetFocusOnError="true" ControlToValidate="DdlProducto" ErrorMessage="Seleccione un Producto" InitialValue="" CssClass="Text_Error" ValidationGroup="Buscar"><img src="../IMG/error.gif" alt="Seleccione un Producto" title="Seleccione un Producto" /> </asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="LCodigoTarifa" runat="server" Text="Tarifa:" CssClass="Text_Normal" />
                                    </td>
                                    <td width="10%">
                                        <asp:TextBox runat="server" ID="TbCodigoTarifa" Width="40px" CssClass="Text_Normal" EnableViewState="true" />
                                        <ajx:AutoCompleteExtender ID="AceCodigoTarifa" runat="server" ServicePath="~/Servicios/ServicioAutocompletarTarifa.asmx" ServiceMethod="GetSuggestions" TargetControlID="TbCodigoTarifa" MinimumPrefixLength="1"
                                            CompletionSetCount="12" ContextKey="">
                                        </ajx:AutoCompleteExtender>
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" ValidationGroup="Buscar" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BNuevo" runat="server" Text="Nuevo" OnClick="BNuevo_Click" CssClass="Button_Normal" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:GridView ID="GvTarifas" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" Width="70%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False" Export="Yes"
                                PageSize="30" AllowPaging="True" OnRowDataBound="GvTarifas_RowDataBound" RowStyle-CssClass="GridView_Row_Data_Normal" OnPageIndexChanging="GvTarifas_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:BoundField HeaderText="Pais" DataField="CodigoPais" />
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Sufijo" DataField="Sufijo" />
                                    <asp:TemplateField HeaderText="Es Anual">
                                        <ItemTemplate>
                                            <%# Eval("Anual").ToString() == "False" ? "No" : "Sí"  %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Modalidad" DataField="TipoModalidad" />
                                </Columns>
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="GvTarifas" />
            </Triggers>
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
