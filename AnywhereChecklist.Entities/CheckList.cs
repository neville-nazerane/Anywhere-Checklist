using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnywhereChecklist.Entities
{
    public class CheckList
    {

        public int Id { get; set; }

        [Required, MaxLength(90)]
        public string Title { get; set; }

        [Required]
        public int? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<CheckListItem> Items { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
