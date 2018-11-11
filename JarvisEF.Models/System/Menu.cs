using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Models.System
{
    /// <summary>
    /// http://codecaster.nl/blog/2013/03/posting-sortable-and-editable-items/
    /// </summary>
    public class Menu : BaseEntity
    {
        public int Order { get; set; }
        public string Description { get; set; }
    }

    public class SortableModel
    {
        public List<Menu> CustomItems { get; set; }
    }

    public class HolidayLocations : BaseEntity
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public string Location { get; set; }
        public int Preference { get; set; }
    }
}
