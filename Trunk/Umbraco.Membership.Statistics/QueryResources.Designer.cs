﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Umbraco.Membership.Statistics {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class QueryResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QueryResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Umbraco.Membership.Statistics.QueryResources", typeof(QueryResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string CumulativeFrequency {
            get {
                return ResourceManager.GetString("CumulativeFrequency", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @nodeType integer
        ///set @nodeType = (select top 1 Id from [umbracoNode] where [TEXT] = @memberType)
        ///
        ///;with results as (
        ///	select	CAST([xml] as xml).value(&apos;(//*[local-name()=sql:variable(&quot;@profilePropertyName&quot;)])[1]&apos;, &apos;nvarchar(max)&apos;) [value]
        ///	from cmsContentXml 
        ///	where CAST([xml] as xml).value(&apos;(//node/@nodeType)[1]&apos;, &apos;int&apos;) = @nodeType
        ///)
        ///
        ///select	COUNT(1) [Frequency], value [PropertyValue]
        ///	from results
        ///		group by value
        ///
        ///.
        /// </summary>
        internal static string GetProfileFrequency {
            get {
                return ResourceManager.GetString("GetProfileFrequency", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @now date
        ///declare @nodeType integer
        ///
        ///set @now = GETDATE()
        ///set @nodeType = (select top 1 Id from [umbracoNode] where [TEXT] = @memberType)
        ///
        ///declare @results table ([Total] integer, [ThisYear] integer, [ThisMonth] integer, [ThisWeek] integer, [Today] integer)
        ///
        ///-- all members
        ///insert into @results(Total) (select COUNT(1)	
        ///					from cmsContentXml 
        ///					where CAST([xml] as xml).value(&apos;(//node/@nodeType)[1]&apos;, &apos;int&apos;) = @nodeType)
        ///
        ///---- this year
        ///update @results 
        ///	set ThisYear =  (select COUNT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetStatistics {
            get {
                return ResourceManager.GetString("GetStatistics", resourceCulture);
            }
        }
    }
}