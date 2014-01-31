using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocalLinked.Umbraco.Data;

namespace LocalLinked.Umbraco.Services
{
    public class EmailListService
    {
        private readonly EmailListRepository _repository;

        public EmailListService()
        {
            _repository = new EmailListRepository();
        }

        public IEnumerable<string> GetByLocation(string location)
        {
            return _repository.GetByLocation(location);
        }
    }
}