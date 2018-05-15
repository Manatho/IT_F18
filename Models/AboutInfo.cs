using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_F18.Models
{
    public class AboutInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Description { get; set; }
        public string CurrentOccupation { get; set; }

        //Didn't get around to use this aspect
        public List<Project> Projects { get; set; }
    }
}
