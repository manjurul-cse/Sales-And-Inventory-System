using System;
using System.Collections.Generic;

namespace SalesAndInventorySystemModel.BLL
{
    public class PersonType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Category> Category { get; set; }
    }
}
