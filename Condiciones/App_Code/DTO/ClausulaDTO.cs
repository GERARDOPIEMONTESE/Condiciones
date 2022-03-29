using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ClausulaDTO
{
    #region Atributos

    private int _Id;

    private int _Orden;

    private string _TextoIdentificatorioPadre;

    private string _TextoIdentificatorio;

    private int _Posicion;

    private string _NombreClausula;

    private int _IdClausula;

    private int _IdTipoClausula;

    private string _Contenido;

    private bool _Imprimir;

    private bool _ResumenBeneficios;

    #endregion

    #region Propiedades

    public int Id
    {
        get
        {
            return _Id;
        }
        set
        {
            _Id = value;
        }
    }


    public int Orden
    {
        get
        {
            return _Orden;
        }
        set
        {
            _Orden = value;
        }
    }

    public string TextoIdentificatorioPadre
    {
        get
        {
            return _TextoIdentificatorioPadre;
        }
        set
        {
            _TextoIdentificatorioPadre = value;
        }
    }

    public string TextoIdentificatorio
    {
        get
        {
            return _TextoIdentificatorio;
        }
        set
        {
            _TextoIdentificatorio = value;
        }
    }

    public int Posicion
    {
        get
        {
            return _Posicion;
        }
        set
        {
            _Posicion = value;
        }
    }

    public string NombreClausula
    {
        get
        {
            return _NombreClausula;
        }
        set
        {
            _NombreClausula = value;
        }
    }

    public int IdClausula
    {
        get
        {
            return _IdClausula;
        }
        set
        {
            _IdClausula = value;
        }
    }

    public int IdTipoClausula
    {
        get
        {
            return _IdTipoClausula;
        }
        set
        {
            _IdTipoClausula = value;
        }
    }

    public string Contenido
    {
        get
        {
            return _Contenido;
        }
        set
        {
            _Contenido = value;
        }
    }

    public bool Imprimir
    {
        get
        {
            return _Imprimir;
        }
        set
        {
            _Imprimir = value;
        }
    }

    public bool ResumenBeneficios
    {
        get
        {
            return _ResumenBeneficios;
        }
        set
        {
            _ResumenBeneficios = value;
        }
    }

    #endregion

}
