using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnywhereChecklist.Models
{
    public class CheckListItemAdd
    {

        [Required, MaxLength(100)]
        public string Content { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public int? CheckListId { get; set; }
    }
}
