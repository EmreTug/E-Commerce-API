﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Prasoft.Data
{
    public partial class ProductVariant
    {
        public long Id { get; set; }
        public long ProductVariantGroupId { get; set; }
        public long VariantNameId { get; set; }
        public long VariantValueId { get; set; }

        public virtual ProductVariantGroup ProductVariantGroup { get; set; }
        public virtual VariantName VariantName { get; set; }
        public virtual VariantValue VariantValue { get; set; }
    }
}