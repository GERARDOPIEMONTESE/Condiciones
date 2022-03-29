using System;
using System.Collections.Generic;
using System.Text;
using Backend.DTO;

public class GrupoClausulaPantallaDTO
{
    #region Atributos

    private GrupoClausulaListaDTO _GrupoDto;

    private TarifaDTO _TarifaDto;

    #endregion

    #region Propiedades

    public int Id
    {
        get
        {
            return _GrupoDto.Id;
        }
    }

    public string NombreTipoGrupoClausula
    {
        get
        {
            return _GrupoDto.NombreTipoGrupoClausula;
        }
    }

    public string NombreLocacion
    {
        get
        {
            return _GrupoDto.NombreLocacion;
        }
    }

    //public bool Anual
    //{
    //    get
    //    {
    //        return _GrupoDto.Anual;
    //    }
    //}

    public string NombreTextoResumen
    {
        get
        {
            return _GrupoDto.NombreTextoResumen;
        }
    }

    public string Producto
    {
        get
        {
            return _GrupoDto.Producto;
        }
    }
    
    public string Tarifa
    {
        get
        {
            return _TarifaDto.Nombre + " (" + _TarifaDto.Codigo + ")";
        }
    }

    public string Sufijo
    {
        get
        {
            return _TarifaDto.Sufijo;
        }
    }

    #endregion

    public GrupoClausulaPantallaDTO(GrupoClausulaListaDTO pGrupoDto, TarifaDTO pTarifaDto)
    {
        _GrupoDto = pGrupoDto;
        _TarifaDto = pTarifaDto;
    }


}