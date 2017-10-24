using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.WAPI.Models
{
    public abstract class SearchCriteria : Base
    {

    }

    public class UserSearchCriteria : SearchCriteria
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pesel { get; set; }
    }
}
