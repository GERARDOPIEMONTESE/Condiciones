using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public class TreeViewUtils
{
    //private static IList<CapaNegocioDatos.CapaNegocio.Menu> Filtrar(IList<CapaNegocioDatos.CapaNegocio.Menu> Items, int Nivel, int IdMenuPadre)
    //{
    //    IList<CapaNegocioDatos.CapaNegocio.Menu> ItemsFiltrados = new List<CapaNegocioDatos.CapaNegocio.Menu>();
    //    foreach (CapaNegocioDatos.CapaNegocio.Menu Item in Items)
    //    {
    //        if (Item.Nivel == Nivel && Item.IdMenuPadre == IdMenuPadre)
    //        {
    //            ItemsFiltrados.Add(Item);
    //        }
    //    }
    //    return ItemsFiltrados;
    //}

    //private static TreeNode ObtenerTreeNode(CapaNegocioDatos.CapaNegocio.Menu Item)
    //{
    //    TreeNode Nodo = new TreeNode();
    //    Nodo.Text = Item.Nombre;
    //    Nodo.Value = Convert.ToString(Item.Id);
    //    Nodo.ToolTip = Item.Descripcion + "||" + Item.Url;
    //    Nodo.Expanded = true;

    //    return Nodo;
    //}

    //public static void CargarArbol(IList<CapaNegocioDatos.CapaNegocio.Menu> Items, int Nivel, int IdMenuPadre, TreeNodeCollection Nodos)
    //{
    //    IList<CapaNegocioDatos.CapaNegocio.Menu> ItemsAgregar = Filtrar(Items, Nivel, IdMenuPadre);

    //    foreach (CapaNegocioDatos.CapaNegocio.Menu Item in ItemsAgregar)
    //    {
    //        TreeNode Nodo = ObtenerTreeNode(Item);
    //        Nodos.Add(Nodo);
    //        CargarArbol(Items, Item.Nivel + 1, Item.Id, Nodo.ChildNodes);
    //    }
    //}

    //public static void CargarIdiomasAsociados(IDictionary<string, IList<MenuIdioma>> IdiomasAsociados,
    //                            IList<CapaNegocioDatos.CapaNegocio.Menu> Items)
    //{
    //    foreach (CapaNegocioDatos.CapaNegocio.Menu Item in Items)
    //    {
    //        if (!IdiomasAsociados.Keys.Contains(Convert.ToString(Item.Id)))
    //        {
    //            IdiomasAsociados.Add(Convert.ToString(Item.Id), Item.IMenuIdioma);
    //        }
    //    }
    //}

    public static void EncontrarNodo(string Valor, TreeNodeCollection Nodos, ref TreeNode NodoEncontrado)
    {
        foreach (TreeNode Nodo in Nodos)
        {
            if (Nodo.Value.Equals(Valor))
            {
                NodoEncontrado = Nodo;
                break;
            }
            else
            {
                EncontrarNodo(Valor, Nodo.ChildNodes, ref NodoEncontrado);
            }
        }
    }

    public static TreeNode EncontrarNodo(string Valor, TreeView Arbol)
    {
        TreeNode NodoEncontrado = null;
        foreach (TreeNode Nodo in Arbol.Nodes)
        {
            if (Nodo.Value.Equals(Valor))
            {
                NodoEncontrado = Nodo;
                break;
            }
            else
            {
                EncontrarNodo(Valor, Nodo.ChildNodes, ref NodoEncontrado);
            }
        }
        return NodoEncontrado;
    }

    public static void MoverArriba(TreeNodeCollection Nodos, TreeNode Nodo)
    {
        int Posicion = Nodos.IndexOf(Nodo);

        if (Posicion > 0)
        {
            Nodos.AddAt(Posicion - 1, Nodo);
        }
    }

    public static void MoverAbajo(TreeNodeCollection Nodos, TreeNode Nodo)
    {
        int Posicion = Nodos.IndexOf(Nodo);

        if (Posicion < (Nodos.Count - 1))
        {
            Nodos.AddAt(Posicion + 1, Nodo);
        }
    }
}