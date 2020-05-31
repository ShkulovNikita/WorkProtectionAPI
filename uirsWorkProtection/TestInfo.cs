using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uirsWorkProtection
{
    public class TestInfo
    {
        public Guid[] Id { get; set; }
        public string[] Names { get; set; }
        public string[] ExpireDates { get; set; }
        public bool[] Passed { get; set; }
        
        public TestInfo(Guid[] id, string[] names, string[] expireDates, bool[] passed)
        {
            Id = id;
            Names = names;
            ExpireDates = expireDates;
            Passed = passed;
        }
    }
}