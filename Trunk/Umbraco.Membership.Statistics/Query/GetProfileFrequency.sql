declare @nodeType integer
set @nodeType = (select top 1 Id from [umbracoNode] where [TEXT] = @memberType)

declare @dataTypeId int
declare @propertyTypeId int
select @propertyTypeId = id, @dataTypeId = dataTypeId from cmsPropertyType where Alias = @profilePropertyName


;with results as (
	--select	CAST([xml] as xml).value('(//*[local-name()=sql:variable("@profilePropertyName")])[1]', 'nvarchar(max)') [value]
	--from cmsContentXml 
	--where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType

	select case @dataTypeId 
				when -49 then cast(dataInt as nvarchar(max))
				when -51 then cast(dataInt			 as nvarchar(max))
				when -87 then cast(dataNtext		 as nvarchar(max))
				when -88 then cast(dataNvarchar		 as nvarchar(max))
				when -89 then cast(dataNtext		 as nvarchar(max))
				when -90 then cast(dataNvarchar		 as nvarchar(max))
				when -92 then cast(dataNvarchar		 as nvarchar(max))
				when -36 then cast(dataDate			 as nvarchar(max))
				when -37 then cast(dataNvarchar		 as nvarchar(max))
				when -38 then cast(dataNvarchar		 as nvarchar(max))
				when -39 then cast(dataNvarchar		 as nvarchar(max))
				when -40 then cast(dataNvarchar		 as nvarchar(max))
				when -41 then cast(dataDate			 as nvarchar(max))
				when -42 then cast(dataInt			 as nvarchar(max))
				when -43 then cast(dataNvarchar		 as nvarchar(max))
			end [value]
	
	 from cmsPropertyData where propertytypeid = @propertyTypeId
)

select	COUNT(1) [Frequency], value [PropertyValue]
	from results
		group by value

