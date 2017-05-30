using GenFu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrainStormTest
{

    public class UserGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Leader> Leaders { get; set; }
        public DateTime Founded { get; set; }
        public int Members { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }


    }

    public class Leader
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
    }

    public class Meeting
    {
        public string Subject { get; set; }
        public string Location { get; set; }

    }

}
