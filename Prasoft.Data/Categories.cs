﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Prasoft.Data
{
    public partial class Categories
    {
        public Categories()
        {
            InverseParent = new HashSet<Categories>();
            Product = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public virtual Categories Parent { get; set; }
        public virtual ICollection<Categories> InverseParent { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}