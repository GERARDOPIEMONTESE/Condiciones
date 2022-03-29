using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AdjuntoDTO
{
    #region Atributos

    private int _IdTipoDocumento;

    private byte[] _Archivo;

    #endregion

    #region Constructores

    public AdjuntoDTO()
    {
    }

    public AdjuntoDTO(int pIdTipoDocumento, byte[] pArchivo)
    {
        _IdTipoDocumento = pIdTipoDocumento;
        _Archivo = pArchivo;
    }

    #endregion

    #region Propiedades

    public int IdTipoDocumento
    {
        get
        {
            return _IdTipoDocumento;
        }
        set
        {
            _IdTipoDocumento = value;
        }
    }


    public byte[] Archivo
    {
        get
        {
            return _Archivo;
        }
        set
        {
            _Archivo = value;
        }
    }

    #endregion

}
