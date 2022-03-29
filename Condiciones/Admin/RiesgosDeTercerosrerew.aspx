<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiesgosDeTerceros.aspx.cs" Inherits="Condiciones.RiesgosDeTerceros" 
uiculture="auto" culture="auto" meta:resourcekey="PageResource1" ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="ajx"%>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Espera.css" type="text/css" />
    <script src="../Js/Condiciones.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function ShowPopUp() {
            $find('ModalBehavior').show();
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="True"></ajx:ToolkitScriptManager>
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
        <!-- Buscador de cuentas -->
            <tr style="background-color: #e5ebf7">
                <td style="text-align: left;">
                    <table border="0" cellpadding="1" cellspacing="1">
                        <tr>
                            <td>
                                <asp:Label ID="lblPais" runat="server" Text="Pais:" CssClass="Text_Normal" />

                            </td>
                            <td>
                                <asp:DropDownList ID="DdlPais" runat="server" CssClass="DropDownList_M" />
                            </td>
                            <td>
                                <asp:Label ID="lblTipoNegocio" runat="server" Text="Tipo Negocio:" CssClass="Text_Normal" />
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlTipoNegocio" runat="server" CssClass="DropDownList_M" />
                            </td>
                            <td>
                                <asp:Label ID="lblCompaniaSeguro" runat="server" Text="Compañia de seguro:" CssClass="Text_Normal" />
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlCompaniaSeguro" runat="server" CssClass="DropDownList_M" />
                            </td>
                            <td class="btn-cntnr">
                                <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" CausesValidation="true" />
                            </td>
                            <td class="btn-cntnr">
                                <asp:Button ID="BAgregar" runat="server" Text="Agregar" OnClick="BAgregar_Click" CssClass="Button_Normal" />
                            </td>
                        </tr>
                    </table>
                </td>  
            </tr>        
            <tr>
                <td align="center">
                    
                    <div style="text-align:left; overflow:auto ;height:650px; width:900px">
                        <cc1:GridKua ID="grvListaRiesgoTerceros" runat="server" AutoGenerateColumns ="False"
                            AllowPaging="True" Export="Yes" PageSize = "20" DataKeyNames="Id"
                            HeaderStyle-CssClass="GridView_Row_Header_Normal"
                            RowStyle-CssClass="GridView_Row_Data_Normal" Width="800px"
                            PagerStyle-CssClass="GridView_Pager_Normal"
                            OnPageIndexChanging="grvListaRiesgoTerceros_PageIndexChanging"
                            OnRowCommand="grvListaRiesgoTerceros_RowCommand"
                            PagerType="DropDownList" ExportPDF="No" 
                            meta:resourcekey="grvListaRiesgoTercerosResource1">
                            <RowStyle CssClass="GridView_Row_Data_Normal"/>
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="Id" meta:resourcekey="BoundFieldResource1" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Codigo Pais" DataField="IdPais" meta:resourcekey="BoundFieldResource2" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Pais" DataField="DescripcionPais" meta:resourcekey="BoundFieldResource3" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Tipo de Negocio" DataField="TipoNegocio" meta:resourcekey="BoundFieldResource4" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Codigo" DataField="Codigo" meta:resourcekey="BoundFieldResource5" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" meta:resourcekey="BoundFieldResource6" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Compañia Seguro" DataField="CompaniaSeguro" meta:resourcekey="BoundFieldResource7" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Fecha Inicio Vigencia" DataField="FechaInicioVigencia" meta:resourcekey="BoundFieldResource8" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Fecha Fin Vigencia" DataField="FechaFinVigencia" meta:resourcekey="BoundFieldResource9" ItemStyle-HorizontalAlign="Center" />
                                <asp:ButtonField runat="server" ButtonType="Button" CommandName="Editar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center">
                                    <ControlStyle CssClass="EditarGridButton" />
                                </asp:ButtonField>
                                <asp:ButtonField runat="server" ButtonType="Button" CommandName="Eliminar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center">
                                    <ControlStyle CssClass="EliminarGridButton" />
                                </asp:ButtonField>
                            </Columns>
                            <PagerStyle CssClass="GridView_Pager_Normal"/>
                            <EmptyDataTemplate>
                                <asp:Label ID="LblPromocionesCuentaEmpty" runat="server" CssClass="TextLegend_Normal" 
                                            Text="No hay registros disponibles" meta:resourcekey="LblPromocionesCuentaEmpty"/>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridView_Row_Header_Normal"/>
                        </cc1:GridKua>
                    </div>
                </td>
            </tr>
        </table>

        <asp:HiddenField runat="server" ID="BtHidden" />
        <asp:Panel ID="POcupado" runat="server" BackColor="Transparent" Width="300px" 
            Height="130px" Style="display: none;" meta:resourcekey="POcupadoResource1" >
            <div id="TableFormulario" runat="server">
                <table width="100%" style="background-color: White;">
                    <tr>
                        <td align="center">
                            <asp:Image ID="ImgUpdate" Width="70px" Height="70px" runat="server" ImageUrl="~/IMG/cargando.gif" meta:resourcekey="ImgUpdateResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="LbProcessando" Font-Bold="True" Font-Size="X-Large" runat="server" meta:resourcekey="LbProcessandoResource1" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="MpOcupado" runat="server" 
            TargetControlID="BtHidden" RepositionMode="None" BackgroundCssClass="modalBackground" 
        PopupControlID="POcupado" BehaviorID="ModalBehavior" Enabled="True" 
            DynamicServicePath="" />

    </div>
    </form>
</body>
</html>
