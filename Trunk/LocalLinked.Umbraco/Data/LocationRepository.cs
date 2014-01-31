using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Linq;
using System.Diagnostics;

namespace LocalLinked.Umbraco.Data
{
    public class LocationRepository : Repository
    {
        public LocationRepository(): base()
        {
            var dataOptions = new DataLoadOptions();
            
            dataOptions.LoadWith<CountryRegion>(r => r.Country);

            _context.LoadOptions = dataOptions;
        }

        public IQueryable<Location> Get(string locationName, int count)
        {
            var regions = _context.CountryRegions
                .Where(r => r.RegionName.StartsWith(locationName))
                .Select(r => new Location() 
                        { 
                            CountryCode = r.CountryCode, 
                            RegionName = r.RegionName, 
                            CountryName = r.Country.Name 
                        });

            var countries = _context.Countries.Where(c => c.Name.StartsWith(locationName))
                .Select(c => new Location() 
                        {   
                            CountryCode = c.Code, 
                            CountryName = c.Name, 
                            RegionName = c.CountryRegions.FirstOrDefault() == null ? "" : c.CountryRegions.FirstOrDefault().RegionName
                        });

            return regions.Union(countries).Take(count);
        }
    }
}