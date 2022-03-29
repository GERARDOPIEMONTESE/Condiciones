<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucCondicionClausula.ascx.cs" Inherits="Condiciones.Controles.WucCondicionClausula" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>

<ajx:AutoCompleteExtender  ID="AutoCompleteExtender1"  TargetControlID="TbContenido"
          runat="server" ServiceMethod="ObtenerDiccionario"
          ServicePath="~/Servicios/ServicioAutocompletarLenguaje.asmx" 
          MinimumPrefixLength="1" />
<asp:HiddenField runat="server" ID="HfIdioma" />
<asp:TextBox ID="TbContenido" runat="server" CssClass="Text_Normal" 
    MaxLength="500" TextMode="MultiLine" Wrap="true" Columns="42" Rows="9" />
<asp:RequiredFieldValidator ID="RfvContenido" ValidationGroup="None" runat="server" Display="None" ControlToValidate="TbContenido" ErrorMessage="El contenido es requerido." ><img src="../IMG/error.gif" alt="El contenido es requerido" title="El contenido es requerido" /></asp:RequiredFieldValidator>
<br />         

<script language="javascript" type="text/javascript">
    function seleccionClausula(control, hfid) {
        var e;
        e = document.getElementById(hfid);
        
        if(e != null)
        {
            e.value = control.value;
        }
    }
</script>