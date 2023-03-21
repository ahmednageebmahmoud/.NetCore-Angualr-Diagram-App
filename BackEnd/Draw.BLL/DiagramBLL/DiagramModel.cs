using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.DiagramBLL
{
    public class DiagramModel
    {
        public int? Id { get; set; }
        [Required]
        public string Tag { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string JsonDiagram { get; set; }

    }
}
