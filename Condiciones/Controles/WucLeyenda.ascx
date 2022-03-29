<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucLeyenda.ascx.cs" Inherits="Condiciones.Controles.WucLeyenda" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
<ajx:TabContainer ID="TcLeyenda" runat="server" Visible="true" Style="text-align: left" AutoPostBack="false" CssClass="small-text">
</ajx:TabContainer>
<asp:Button runat="server" ID="BTextoClausula" CssClass="CopiarGridButton" ToolTip="Textos Clausula" />
<!-- INICIO TEXTOS LEYENDA -->
<ajx:ModalPopupExtender ID="MpeTextosClausula" runat="server" TargetControlID="BTextoClausula" PopupControlID="PTextosClausula" BackgroundCssClass="ModalPopupExtender" DropShadow="false" CancelControlID="BCancelarTextoClausula"
    X="250" Y="90" />
<asp:Panel runat="server" ID="PTextosClausula" CssClass="PanelModalPopUpExtender" Width="750px" >
    <asp:UpdatePanel runat="server" ID="UpTextos">
        <ContentTemplate>
            <table width="100%">
                <tr style="background-color: #e5ebf7">
                    <td class="btn-cntnr-large">
                        <asp:Label runat="server" ID="LNombreTexto" CssClass="Text_Normal" Text="Nombre"></asp:Label>
                        <asp:TextBox runat="server" ID="TbNombreTexto" CssClass="Text_Normal"></asp:TextBox>
                        <asp:Button runat="server" ID="BBuscarNombreTexto" CssClass="Button_Normal" Text="Buscar" OnClick="BBuscarNombreTexto_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                        <asp:HiddenField runat="server" ID="HfIdclausulaTexto" EnableViewState="true" />
                        <asp:GridView ID="GvTextosClausula" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" PageSize="10" DataKeyNames="Id" Width="500px" Height="250px" HeaderStyle-CssClass="GridView_Row_Header_Normal"
                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnRowDataBound="GvTextosClausula_RowDataBound" OnRowCreated="GvTextosClausula_RowCreated" OnPageIndexChanging="GvTextosClausula_PageIndexChanging" CssClass="tbl-generic">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Literal ID="LTextoClausula" runat="server" Mode="PassThrough"></asp:Literal>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                    <ItemStyle CssClass="GridView_Row_Data_Normal" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Id" DataField="Id">
                                    <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                    <ItemStyle CssClass="GridView_Row_Data_Normal" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                                    <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                    <ItemStyle CssClass="GridView_Row_Data_Normal" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Texto" DataField="Texto">
                                    <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                    <ItemStyle CssClass="GridView_Row_Data_Normal" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="btn-cntnr-large">
                        <asp:Button ID="BAplicarTextoClausula" runat="server" CausesValidation="false" Text="Aceptar" CssClass="Button_Normal" OnClick="BAplicarTextoClausula_Click" />
                        &nbsp;&nbsp;<asp:Button ID="BCancelarTextoClausula" runat="server" Text="Cancelar" CssClass="Button_Normal" />
                        <br />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
