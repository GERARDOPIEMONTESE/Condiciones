<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeGrupoClausulasSLA.aspx.cs" Inherits="Condiciones.GrupoClausulas.SLA.ListaDeGrupoClausulasSLA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
<%@ Register Src="~/Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/Main.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/Espera.css" rel="stylesheet" type="text/css" />
    <script src="../../Js/Condiciones.js" type="text/javascript"></script>

    <script type="text/javascript">
        function Loading() {
            $find('behaivourCargando').show();
            return true;
        }


        function ValidateMe() {
            var ok = Page_ClientValidate("BuscaSucursales");
            if (ok) {
                $find('behaivourCargando').show();
                return true;
            }
            else
                return false;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
    <div class="PaginaPortal">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:UpdatePanel runat="server" ID="UpDatos">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnl" DefaultButton="btnSearch">
                    <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                        <tr style="background-color: #e5ebf7">
                            <td style="text-align: left;">
                                <table border="0" cellpadding="3" cellspacing="3" >
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="Text_Normal" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPais" runat="server" CssClass="DropDownList_M"
                                            EnableViewState="true" OnDataBound="DropDownList_DataBound" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAgencia" runat="server" Text="Agencia:" CssClass="Text_Normal" />
                                            <asp:TextBox runat="server" ID="txtAgencia" Width="40px" CssClass="Text_Normal" EnableViewState="true" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSucursal" runat="server" Text="Nº Sucursal:" CssClass="Text_Normal" />
                                            <asp:TextBox runat="server" ID="txtSucursal" Width="40px" CssClass="Text_Normal" />
                                        </td>
                                        <td class="btn-cntnr-large">
                                            <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_OnClick" CssClass="Button_Normal" ValidationGroup="BuscaSucursales"
                                             OnClientClick="if (!ValidateMe()) return false;" />
                                            <asp:Button ID="btnNew" runat="server" Text="Nuevo" OnClick="btnNew_OnClick" CssClass="Button_Normal" OnClientClick="Loading();" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator runat="server" ID="revtxtSucursal" ErrorMessage="* Nº Sucursal debe ser númerico" CssClass="TextError_Normal"
                                             Display="Dynamic" ValidationGroup="BuscaSucursales" ControlToValidate="txtSucursal" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <br />
                                <asp:GridView ID="grvSLAGroup" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="20" Width="400px" 
                                    HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" 
                                    OnRowDataBound="grvSLAGroup_OnRowDataBound" OnRowCommand="grvSLAGroup_OnRowCommand" 
                                    OnPageIndexChanging="grvSLAGroup_OnPageIndexChanging" RowStyle-CssClass="GridView_Row_Data_Normal"
                                    CssClass="tbl-generic"
                                    PagerType="DropDownList" ExportPDF="Yes">
                                    <Columns>
                                        <asp:BoundField HeaderText="Id" DataField="Id" />
                                        <asp:BoundField HeaderText="Pais" DataField="NombreLocacion" />
                                        <asp:BoundField HeaderText="Agencia" DataField="Agencia" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Nº Sucursal" DataField="Sucursal" ItemStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                            <ItemTemplate>
                                                <asp:Button CssClass="EditarGridButton" ID="btnEdit" runat="server" CommandName="Editar"
                                                OnClientClick="Loading();"  CommandArgument='<%# Eval("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                            <ItemTemplate>
                                                <asp:Button CssClass="CopiarGridButton" ID="btnCopy" runat="server" CommandName="Copiar"
                                                OnClientClick="Loading();"  CommandArgument='<%# Eval("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                            <ItemTemplate>
                                                <asp:Button CssClass="EliminarGridButton" ID="btnDelete" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="grvSLAGroup" />
            </Triggers>
        </asp:UpdatePanel>
        
        <asp:HiddenField runat="server" ID="hdfCargando" />
        <ajx:ModalPopupExtender runat="server" ID="mpeCargando" BehaviorID="behaivourCargando" PopupControlID="UpEsperaAccion"
         TargetControlID="hdfCargando">
        </ajx:ModalPopupExtender>
        <asp:UpdateProgress ID="UpEsperaAccion" runat="server">
            <ProgressTemplate>
                <div class="ProgressBanner">
                    <img src="/IMG/loading.gif" alt="Cargando Página" />
                    <p>
                        Cargando Página ...
                    </p>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
