using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Core.Model
{
    public class Diagram
    {
        public int Id { get; set; }
        public string Tag  { get; set; }
        public string Name { get; set; }

        public string FKUser_Id { get; set; }
        public string JsonDiagram { get; set; }
        public ApplicationUser User { get; set; }
    }
}
