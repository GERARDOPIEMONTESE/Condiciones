USE [Condiciones]
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 03/06/2012 17:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Split](@String varchar(8000), @Delimiter char(1))        
returns @temptable TABLE (items varchar(8000))        
as        
begin        
    declare @idx int        
    declare @slice varchar(8000)        
       
    select @idx = 1        
        if len(@String)<1 or @String is null  return        
       
    while @idx!= 0        
    begin        
        set @idx = charindex(@Delimiter,@String)        
        if @idx!=0        
            set @slice = left(@String,@idx - 1)        
        else        
            set @slice = @String        
           
        if(len(@slice)>0)   
            insert into @temptable(Items) values(@slice)        
  
        set @String = right(@String,len(@String) - @idx)        
        if len(@String) = 0 break        
    end    
return        
end
GO
/****** Object:  StoredProcedure [dbo].[AsociacionDocumento_CrearAsociacionesADocumento]    Script Date: 03/06/2012 17:18:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joaquin de las Heras>
-- Create date: <06/03/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AsociacionDocumento_CrearAsociacionesADocumento]
	@IdDocumento int,
	@Asociados varchar(8000),
	@TipoAsociacion int,
	@IdUsuario int
AS
BEGIN
	
	DECLARE @TablaAsociados Table
	(
		Id int identity(1,1),
		Asociado int
	)
	
	INSERT INTO @TablaAsociados
	SELECT items FROM dbo.Split(@Asociados,',')
		
	DECLARE @Id int
	DECLARE @Asociado int
	
	SELECT @Id = Id, @Asociado = Asociado FROM @TablaAsociados
	WHERE Id = 1
	
	WHILE @Asociado IS NOT NULL
	BEGIN
		INSERT INTO AsociacionDocumento(IdDocumento,IdTipoAsociacionDocumento,IdObjeto,IdUsuario,FechaCreacion,FechaModificacion,IdEstado)
		VALUES(@IdDocumento,@TipoAsociacion, @Asociado, @IdUsuario, GETDATE(), GETDATE(), 25000 )
			
		SET @Asociado = NULL	
		SET @Id = @Id + 1
		
		SELECT @Id = Id, @Asociado = Asociado FROM @TablaAsociados
		WHERE Id = @Id
			
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[AsociacionDocumento_BorrarPorDocumento]    Script Date: 03/06/2012 17:18:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Joaquin de las Heras>
-- Create date: <06/03/2012>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[AsociacionDocumento_BorrarPorDocumento]
	@IdDocumento int
AS
BEGIN
	
	DELETE AsociacionDocumento 
	WHERE IdDocumento = @IdDocumento
	AND (IdTipoAsociacionDocumento = 1 OR IdTipoAsociacionDocumento = 2)
	
END
GO
