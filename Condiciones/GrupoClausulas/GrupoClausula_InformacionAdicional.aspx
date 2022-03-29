<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrupoClausula_InformacionAdicional.aspx.cs" Inherits="Condiciones.GrupoClausulas.GrupoClausula_InformacionAdicional" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Src="../Controles/SessionController.ascx" TagName="SessionController" TagPrefix="uc1" %>
<%@ Register src="../Controles/WucTabsDocumentos.ascx" tagname="WucTabsDocumentos" tagprefix="uc2" %>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" AsyncPostBackTimeout="600" />
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr>
                        <td style="text-align: left;">
                            <asp:Label ID="LNombreTexto" runat="server" Text="Nombre:" CssClass="Text_Normal" />
                            <asp:TextBox runat="server" ID="TbNombre" Width="150px" CssClass="Text_Normal" />
                            <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" />
                        </td>
                    </tr>
                </table>
                <br />
                <table width="95%" border="0" align="center">
                    <tr>
                        <td align="center">
                            <asp:Label ID="LbTextosTitulo" runat="server" CssClass="TextLegend_Normal" Text="Textos"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label runat="server" ID="LDocumentos" Text="Documentos" CssClass="TextLegend_Normal" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:GridView ID="GvTextosResumen" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="20" Width="100%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                AllowPaging="true" OnRowDataBound="GvTextosResumen_RowDataBound" AllowSorting="true" RowStyle-VerticalAlign="Top" RowStyle-CssClass="GridView_Row_Data_Normal" OnPageIndexChanging="GvTextosResumen_PageIndexChanging"
                                OnSorting="GvTextoResumen_Sorting">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="CbTextoResumen" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre" />
                                    <asp:TemplateField HeaderText="Tipo Plan">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DdlTipoPlan" runat="server"  DataTextField="Descripcion" DataValueField="Id" CssClass="DropDownList_SM" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Texto Resumen">
                                        <ItemTemplate>
                                            <asp:Label ID="LbTextoResumen" runat="server" Text='<%#((String)Eval("ContenidoTexto")).Length < 30?Eval("ContenidoTexto"):((String)Eval("ContenidoTexto")).Substring(0,30) + "..." %>'></asp:Label>
                                            <ajx:HoverMenuExtender ID="HoverMenuExtender1" PopDelay="30" runat="server" HoverCssClass="popupHoverPanel" PopupControlID="PopupMenu" TargetControlID="LbTextoResumen" PopupPosition="Right">
                                            </ajx:HoverMenuExtender>
                                            <asp:Panel ID="PopupMenu" runat="server" Width="100%" Style="display: none" CssClass="popupHoverPanel">
                                                <div style="max-height: 500px; max-width: 400px; width: 100%; overflow: auto; border-color: Black; border-width: thin;">
                                                    <asp:Label ID="lblCode" runat="server" CssClass="MuestraTexto" BorderColor="ActiveBorder" BorderWidth="2px" Text='<%# Eval("ContenidoTexto") %>' />
                                                </div>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <span class="Text_Normal"><b><i>No se han encontrado textos</i></b></span></EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                        <td align="center" valign="top">
                            
                            <uc2:WucTabsDocumentos ID="WucTabsDocumentos1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" />
                            <asp:Button ID="BAceptar" runat="server" Text="Aceptar" OnClick="BAceptar_Click" CssClass="Button_Normal" ValidationGroup="Guardar" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                </table>
                <br />
                <table border="0" cellpadding="1" cellspacing="1" align="center">
                    <tr>
                        <td align="left">
                            <asp:ValidationSummary runat="server" DisplayMode="BulletList" CssClass="TextError_Normal" ValidationGroup="Guardar" ID="VsValidador" />
                        </td>
                    </tr>
                </table>
      
        <uc1:SessionController ID="SessionController1" runat="server" />
    </div>
    </form>
</body>
</html>
