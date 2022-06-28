using System.Collections.Generic;

namespace Shell.API.Models.Entities
{
    public class Row
    {
        public int RowIndex { get; set; }
        public string PageName { get; set; }
        public ICollection<Column> Columns { get; set; }
    }
}
