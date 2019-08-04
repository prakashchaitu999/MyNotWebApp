using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class MyLabel
    {
        [Key]
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public string LabelDescription { get; set; }
        public DateTime LabelDate { get; set; }



    }
}
