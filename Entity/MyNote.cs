using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class MyNote
    {
       // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NoteId { get; set; }
        //[Required]
        public string NoteName { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }

        public virtual ICollection<MyLabel> Labels { get; set; }
    }
}
