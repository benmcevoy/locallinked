LocalLinked sample
==================

## Solution structure: ##

LinkedLocal *(the root)*

- Builds\Debug *(this should contain your umbraco instance)*
- Lib *(referenced assemblies and libraries)*
- Packages *(umbraco packages, including umbraco)*
- Trunk *(Source trunk)*
	
The main project is LinkedLocal.Umbraco.  On build this will deploy itself into Builds\Debug.

LinkedLocal.Umbraco should contain any scripts, css, master pages, macros and assets.

Document types are defined in Umbraco.  Export them from Umbraco as UDT (xml) and source control them as well.


