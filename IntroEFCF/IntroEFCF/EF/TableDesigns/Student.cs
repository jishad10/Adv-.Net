using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntroEFCF.EF.TableDesigns
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public virtual Department Dept { get; set; }

    }
}