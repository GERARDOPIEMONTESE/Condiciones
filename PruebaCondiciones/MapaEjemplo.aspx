<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapaEjemplo.aspx.cs" Inherits="PruebaCondiciones.MapaEjemplo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:ImageMap ID="ImageMap2" ImageUrl="~/IMG/None.gif" HotSpotMode="PostBack" OnClick="mapMenu_Click" runat="server">
        <asp:RectangleHotSpot Top="20"  Left="20" AlternateText="Top L" PostBackValue="TOPL" />
        <asp:RectangleHotSpot Top="200" Left="20" AlternateText="Down L" PostBackValue="DOWNL" />
        <asp:RectangleHotSpot Top="20" Left="500" AlternateText="Top R" PostBackValue="TOPR" />
        <%--<asp:RectangleHotSpot Top="200" Left="500" AlternateText="Down R" PostBackValue="DOWNR" NavigateUrl="~/MapaEjemplo.aspx" />--%>
    </asp:ImageMap>
    
    </div>
    </form>
</body>
</html>
