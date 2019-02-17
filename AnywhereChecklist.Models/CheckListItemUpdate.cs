using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnywhereChecklist.Models
{
    public class CheckListItemUpdate
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Content { get; set; }

        public bool IsCompleted { get; set; }

    }
}
