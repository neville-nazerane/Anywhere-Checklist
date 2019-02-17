using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnywhereChecklist.Models
{
    public class CheckListAdd
    {

        [Required, MaxLength(90)]
        public string Title { get; set; }


    }
}
