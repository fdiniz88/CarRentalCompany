using System.Collections.Generic;

namespace CarRentalCompany.Common.Domain.DTO
{
    public class ReturnResult
    {
        public string Action { get; set; }

        public bool Success
        {
            get { return _Inconsistencies == null || Inconsistencies.Count == 0; }
        }

        private List<string> _Inconsistencies = new List<string>();
        public List<string> Inconsistencies
        {
            get { return _Inconsistencies; }
        }
    }
}