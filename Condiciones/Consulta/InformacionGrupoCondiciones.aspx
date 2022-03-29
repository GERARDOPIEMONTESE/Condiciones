<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformacionGrupoCondiciones.aspx.cs" ValidateRequest="false" Inherits="Condiciones.Consulta.InformacionGrupoCondiciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>


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
        <asp:ScriptManager ID="ScriptManager2" runat="server" />
        <asp:UpdatePanel runat="server" ID="UPHelp">
            <ContentTemplate>
                <fieldset>
                    <asp:Panel runat="server" ID="pnl" DefaultButton="BVerDocumentos">
                        <table width="750px" style="margin: 0 auto;">
                            <tr>
                                <td width="100%" align="left">
                                    <asp:Label ID="LBusinessPlan" runat="server" Visible="false" CssClass="title-condicion"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="80%" align="center">
                                    <ajx:Accordion ID="ACondiciones" runat="server" TransitionDuration="100" FramesPerSecond="200" SelectedIndex="-1" FadeTransitions="true" RequireOpenedPane="false" OnItemDataBound="ACondiciones_ItemDataBound"
                                        ContentCssClass="Accordion_Content" HeaderCssClass="Accordion_Header" HeaderSelectedCssClass="Accordion_Header_Selected">
                                        <HeaderTemplate>
                                            <table width="750px">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label runat="server" ID="LTituloClausula" Text='<%#DataBinder.Eval(Container.DataItem,"CodigoClausula") %>' CssClass="Text_Subtitle"></asp:Label>&nbsp;&nbsp;-&nbsp;&nbsp;
                                                        <asp:Label runat="server" ID="LCodigoClausula" Text='<%#DataBinder.Eval(Container.DataItem,"TituloClausula") %>' CssClass="Text_Subtitle"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView ID="GvCondiciones" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="10" Width="100%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                AllowPaging="True" AllowSorting="True" OnRowDataBound="GvCondiciones_RowDataBound" RowStyle-CssClass="GridView_Row_Data_Normal_Center" Export="Yes" class="tbl-generic">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Min. Age" DataField="EdadMinima" meta:resourcekey="MinAge" />
                                                    <asp:BoundField HeaderText="Max. Age" DataField="EdadMaxima" meta:resourcekey="MaxAge" />
                                                    <asp:BoundField HeaderText="Plan" DataField="TipoPlan" meta:resourcekey="Plan" />
                                                    <asp:BoundField HeaderText="Modality" DataField="TipoModalidad" meta:resourcekey="Modality" />
                                                    <asp:BoundField HeaderText="Upgrade Category" DataField="Categoria" meta:resourcekey="UpgradeCategory" />
                                                    <asp:BoundField HeaderText="Territorial Validity" DataField="ValidezTerritorial" meta:resourcekey="territorialValidity" />
                                                    <asp:BoundField HeaderText="Description" DataField="Leyenda" meta:resourcekey="Description" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </ajx:Accordion>
                                </td>
                                <td width="20%">
                                    <asp:ImageButton runat="server" ID="BIHelp" ImageUrl="../IMG/help.gif" OnClick="BIHelp_Click" />
                                    <ajx:Accordion ID="AAyuda" runat="server" TransitionDuration="100" FramesPerSecond="200" SelectedIndex="0" FadeTransitions="true" RequireOpenedPane="false" ContentCssClass="Accordion_Content_Help" HeaderCssClass="Accordion_Header_Help"
                                        Visible="false" HeaderSelectedCssClass="Accordion_Header_Selected_Help">
                                        <HeaderTemplate>
                                            <table width="250px">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label runat="server" ID="LNombre" Text='<%#DataBinder.Eval(Container.DataItem,"Nombre") %>' CssClass="Text_Subtitle"></asp:Label>&nbsp;&nbsp;-&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:Label runat="server" ID="LDescripcion" Text='<%#DataBinder.Eval(Container.DataItem,"Descripcion") %>' CssClass="Text_Normal"></asp:Label>&nbsp;&nbsp;-&nbsp;&nbsp;
                                            <br />
                                        </ContentTemplate>
                                    </ajx:Accordion>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="btn-cntnr-large">
                                    <asp:Button ID="BVolver" runat="server" Text="Atras" OnClick="BVolver_Click" CssClass="Button_Normal" meta:resourceKey="back" />
                                    <asp:Button ID="BVerDocumentos" runat="server" CssClass="Button_Normal" Text="Documentos" OnClick="BVerDocumentos_Click" meta:resourceKey="documents" />
                                    <asp:Button runat="server" ID="BHide" Style="display: none;" />
                                    <ajx:ModalPopupExtender runat="server" ID="MpeDocumentos" PopupControlID="PDocumentos" BackgroundCssClass="modalBackground" TargetControlID="BHide" OkControlID="BOK" />
                                    <asp:Panel runat="server" ID="PDocumentos" BackColor="Transparent">
                                        <asp:Panel runat="server" ID="PPopDocumentos" Style="background-color: White;" Width="400">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        &nbsp;&nbsp;<asp:Label Font-Size="Medium" runat="server" ID="LTituloDocumentos" CssClass="Text_Normal" Text="Documentos" />
                                                    </td>
                                                </tr>
                                                <tr style="height: 15;" />
                                                <tr>
                                                    <td align="left">
                                                        <asp:DataList runat="server" ID="DlLinks" RepeatColumns="1" RepeatDirection="Vertical" OnItemDataBound="dlDocumentos_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <ul style="letter-spacing: 0;">
                                                                    <li style="padding-left: 0; list-style-type: square">
                                                                        <asp:HyperLink runat="server" ID="HlDocumento" Target="_blank" CssClass="Text_Link" /></li>
                                                                    <li style="padding-left: 0; list-style-type: square">
                                                                        <asp:Label runat="server" ID="LIdiomaDocumento" CssClass="Text_Normal"></asp:Label>
                                                                    </li>
                                                                </ul>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="btn-cntnr-large">
                                                        <asp:Button runat="server" ID="BOK" Text="OK" CssClass="Button_Normal" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <ajx:RoundedCornersExtender runat="server" ID="RceDocumentos" TargetControlID="PPopDocumentos" Radius="6" Corners="All" BorderColor="White" Color="White" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
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
    </div>
    </form>
</body>
</html>
