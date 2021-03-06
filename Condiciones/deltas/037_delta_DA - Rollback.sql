GO
/****** Object:  StoredProcedure [dbo].[Documento_TX_BuscarPorParametros]    Script Date: 9/8/2019 10:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- dbo.Documento_TX_BuscarPorParametros 1, 'ccgg'
ALTER PROCEDURE [dbo].[Documento_TX_BuscarPorParametros]
	 @IdTipoDocumento	INT = -1,
	 @Nombre			VARCHAR(50)='',
	 @IdEstadoEliminado INT = 25002
AS
BEGIN
	DECLARE @sql        NVARCHAR(MAX),                                 
			@paramlist  NVARCHAR(4000)                                 
	                                                                   
	SELECT @sql =                                                      
		'SELECT *                                        
		 FROM
			Documento
		 WHERE 
			IdEstado <> @IdEstadoEliminado' 
	            
	IF @Nombre <> '' 
	   SELECT @sql = @sql + ' AND UPPER(Documento.Nombre) LIKE ''%'' + UPPER(@Nombre) + ''%'''
	      
	IF @IdTipoDocumento <> -1                                         
	   SELECT @sql = @sql + ' AND Documento.IdTipoDocumento = @IdTipoDocumento'
	            

	SELECT @paramlist = '@IdTipoDocumento               INT,               
						 @Nombre                 VARCHAR(50),
						 @IdEstadoEliminado             INT'                     

	SELECT @sql = @sql + ' ORDER BY IdDocumento'         
	            
	EXEC sp_executesql @sql, @paramlist,
					  @IdTipoDocumento, @Nombre, @IdEstadoEliminado

	/*SELECT *
	FROM
		Documento
	WHERE
		(@IdTipoDocumento = -1 OR Documento.IdTipoDocumento = @IdTipoDocumento)
	AND 
		(UPPER(Documento.Nombre) like UPPER(@Nombre) + '%' )
	AND
		IdEstado <> @IdEstadoEliminado
	ORDER BY IdDocumento*/
END

