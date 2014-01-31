declare @now date
declare @nodeType integer

set @now = GETDATE()
set @nodeType = (select top 1 Id from [umbracoNode] where [TEXT] = @memberType)

declare @results table ([Total] integer, [ThisYear] integer, [ThisMonth] integer, [ThisWeek] integer, [Today] integer)

-- all members
insert into @results(Total) (select COUNT(1)	
					from cmsContentXml 
					where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType)

---- this year
update @results 
	set ThisYear =  (select COUNT(1)	
					from cmsContentXml 
					where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType
					and YEAR(CAST([xml] as xml).value('(//node/@createDate)[1]', 'date')) = YEAR(@now))

-- this month
update @results 
	set ThisMonth =  (select COUNT(1)	
					from cmsContentXml 
					where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType
					and DATEDIFF(month, CAST([xml] as xml).value('(//node/@createDate)[1]', 'date'), @now) = 0)

-- this week
update @results 
	set ThisWeek =  (select COUNT(1)	
					from cmsContentXml 
					where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType
					and DATEDIFF(week, CAST([xml] as xml).value('(//node/@createDate)[1]', 'date'), @now) = 0)

-- today
update @results 
	set Today =  (select COUNT(1)	
					from cmsContentXml 
					where CAST([xml] as xml).value('(//node/@nodeType)[1]', 'int') = @nodeType
					and DATEDIFF(day, CAST([xml] as xml).value('(//node/@createDate)[1]', 'date'), @now) = 0)

select * from @results