using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public interface IEstrategiaManejoArbol
{
    void MoverADerecha(TreeView Arbol);

    void MoverAIzquierda(TreeView Arbol);

    void Eliminar(TreeView Arbol, IList<int> NodosEliminados);

    void Eliminar(TreeView Arbol, IList<string> NodosEliminados);

    void MoverNodoArriba(TreeView Arbol, TreeNode Nodo);

    void MoverNodoAbajo(TreeView Arbol, TreeNode Nodo);
}

public class EstrategiaManejoArbolRaiz : IEstrategiaManejoArbol
{
    public EstrategiaManejoArbolRaiz()
    {
    }

    #region IEstrategiaRecorrido Members

    public void MoverADerecha(TreeView Arbol)
    {
        TreeNode ItemSeleccionado = Arbol.SelectedNode;
        int SelectedIndex = Arbol.Nodes.IndexOf(ItemSeleccionado);
        if (SelectedIndex > 0)
        {
            TreeNode ItemPadre = Arbol.Nodes[SelectedIndex - 1];
            ItemPadre.ChildNodes.Add(ItemSeleccionado);
            Arbol.Nodes.Remove(ItemSeleccionado);
        }
    }

    public void MoverAIzquierda(TreeView Arbol)
    {
        //Arbol.Nodes.Remove(Arbol.SelectedNode);
    }

    public void Eliminar(TreeView Arbol, IList<int> NodosEliminados)
    {
        //if (EstrategiasPersistenciaItem.NodoPersistido(Arbol.SelectedNode))
        //{
        //    NodosEliminados.Add(Convert.ToInt32(Arbol.SelectedNode.Value));
        //}
        //Arbol.Nodes.Remove(Arbol.SelectedNode);
    }

    public void MoverNodoArriba(TreeView Arbol, TreeNode Nodo)
    {
        TreeViewUtils.MoverArriba(Arbol.Nodes, Nodo);
    }

    public void MoverNodoAbajo(TreeView Arbol, TreeNode Nodo)
    {
        TreeViewUtils.MoverAbajo(Arbol.Nodes, Nodo);
    }

    #endregion

    #region IEstrategiaManejoArbol Members


    public void Eliminar(TreeView Arbol, IList<string> NodosEliminados)
    {
        //int IdGrupoLocaciones = Convert.ToInt32(
        //    Arbol.SelectedNode.Value.Split(
        //    TreeViewGrupoLocacionesUtils.SEPARADOR.ToCharArray())[0]);
        //if (IdGrupoLocaciones != 0)
        //{
        //    NodosEliminados.Add(Arbol.SelectedNode.Value);
        //}
        Arbol.Nodes.Remove(Arbol.SelectedNode);
    }

    #endregion
}

public class EstrategiaManejoArbolHijo : IEstrategiaManejoArbol
{
    public EstrategiaManejoArbolHijo()
    {
    }

    #region IEstrategiaRecorrido Members

    public void MoverADerecha(TreeView Arbol)
    {
        TreeNode ItemSeleccionado = Arbol.SelectedNode;
        if (ItemSeleccionado.Depth < 2)
        {
            TreeNode PadreOriginal = ItemSeleccionado.Parent;
            int SelectedIndex = ItemSeleccionado.Parent.ChildNodes.IndexOf(ItemSeleccionado);
            TreeNode ItemPadre = ItemSeleccionado.Parent.ChildNodes[SelectedIndex - 1];
            ItemPadre.ChildNodes.Add(ItemSeleccionado);
            PadreOriginal.ChildNodes.Remove(ItemSeleccionado);
        }
    }

    public void MoverAIzquierda(TreeView Arbol)
    {
        TreeNode ItemSeleccionado = Arbol.SelectedNode;
        TreeNode PadreOriginal = ItemSeleccionado.Parent;
        TreeNode NuevoPadre = PadreOriginal.Parent;
        if (NuevoPadre == null)
        {
            Arbol.Nodes.Add(ItemSeleccionado);
        }
        else
        {
            NuevoPadre.ChildNodes.Add(ItemSeleccionado);
        }
        PadreOriginal.ChildNodes.Remove(ItemSeleccionado);
    }

    public void Eliminar(TreeView Arbol, IList<int> NodosEliminados)
    {
        //if (EstrategiasPersistenciaItem.NodoPersistido(Arbol.SelectedNode))
        //{
        //    NodosEliminados.Add(Convert.ToInt32(Arbol.SelectedNode.Value));
        //}
        Arbol.SelectedNode.Parent.ChildNodes.Remove(Arbol.SelectedNode);
    }

    public void MoverNodoArriba(TreeView Arbol, TreeNode Nodo)
    {
        TreeViewUtils.MoverArriba(Nodo.Parent.ChildNodes, Nodo);
    }

    public void MoverNodoAbajo(TreeView Arbol, TreeNode Nodo)
    {
        TreeViewUtils.MoverAbajo(Nodo.Parent.ChildNodes, Nodo);
    }

    #endregion

    #region IEstrategiaManejoArbol Members


    public void Eliminar(TreeView Arbol, IList<string> NodosEliminados)
    {
        //int IdGrupoLocaciones = Convert.ToInt32(
        //    Arbol.SelectedNode.Value.Split(
        //    TreeViewGrupoLocacionesUtils.SEPARADOR.ToCharArray())[0]);
        //if (IdGrupoLocaciones != 0)
        //{
        //    NodosEliminados.Add(Arbol.SelectedNode.Value);
        //}
        Arbol.SelectedNode.Parent.ChildNodes.Remove(Arbol.SelectedNode);
    }

    #endregion
}

public class EstrategiasManejoArbol
{
    private Dictionary<int, IEstrategiaManejoArbol> Estrategias;

    private static EstrategiasManejoArbol Instance;

    private EstrategiasManejoArbol()
    {
        Estrategias = new Dictionary<int, IEstrategiaManejoArbol>();
        Estrategias.Add(0, new EstrategiaManejoArbolRaiz());
        Estrategias.Add(1, new EstrategiaManejoArbolHijo());
        Estrategias.Add(2, new EstrategiaManejoArbolHijo());
    }

    public static EstrategiasManejoArbol ObtenerInstancia()
    {
        if (Instance == null)
        {
            Instance = new EstrategiasManejoArbol();
        }
        return Instance;
    }

    public IEstrategiaManejoArbol ObtenerEstrategia(int Nivel)
    {
        return Estrategias[Nivel];
    }

}
