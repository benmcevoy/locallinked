declare @nodeType integer
declare @cumulativeStartValue int

declare @dateKeys table (DateKey int, [Year] int, [Month] int)
declare @tempdate date

set @tempDate = @startDate

while(@tempdate < @endDate)
begin
	insert into @dateKeys (DateKey, [Year], [Month]) values (year(@tempdate) * 100 + month(@tempdate), YEAR(@tempdate), MONTH(@tempdate))
	set @tempdate = DATEADD(month, 1, @tempdate)
end

set @nodeType = (select top 1 Id from [umbracoNode] where [TEXT] = @memberType)

set @cumulativeStartValue = (select count(CAST([xml] as xml).value('(//node/@createDate)[1]', 'date')) 
			from cmsContentXml 
				where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType
				and CAST([xml] as xml).value('(//node/@createDate)[1]', 'date') < @startDate)

;with results as (
	select	CAST([xml] as xml).value('(//node/@createDate)[1]', 'date') [value]
	from cmsContentXml 
	where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType
	and CAST([xml] as xml).value('(//node/@createDate)[1]', 'date') between @startDate and @endDate
)

select	@cumulativeStartValue [CumulativeStart], 
		count(r.value) [Frequency], 
		dk.[Year] [Year], 
		dk.[Month] [Month],
		datename(month, dk.[Month]) [MonthName], 
		dk.[Year] * 100 + dk.[Month] [DateKey]
	from @dateKeys dk
	left outer join results r on year(r.value) = dk.[YEAR] and month(r.value) = dk.[MONTH]
	group by dk.[Year], datename(month, dk.[Month]), dk.[Month]
	order by dk.[Year], dk.[Month]
	 
	 