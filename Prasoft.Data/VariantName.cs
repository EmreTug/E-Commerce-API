﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Prasoft.Data
{
    public partial class VariantName
    {
        public VariantName()
        {
            ProductVariant = new HashSet<ProductVariant>();
            VariantValue = new HashSet<VariantValue>();
        }

        public long Id { get; set; }
        public string VariantName1 { get; set; }

        public virtual ICollection<ProductVariant> ProductVariant { get; set; }
        public virtual ICollection<VariantValue> VariantValue { get; set; }
    }
}