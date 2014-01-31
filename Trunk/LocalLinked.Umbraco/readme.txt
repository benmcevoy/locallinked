using sqlexpress as this is an old old version of umbraco
create the database first, then point umbraco install at it
run the db scripts to bring that upto date

there is a content package that can be installed to get the UDT and masterpages etc set up and some dummy content

in umbraco Users add 

SiteMember as member type
SiteMembers as group

add a tab to SiteMember type called Profile
add properties that reflect the profile properties in the web.config
alias must match, name can be friendly