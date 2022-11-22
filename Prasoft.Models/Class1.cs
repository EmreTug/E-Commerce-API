using Prasoft.Data;
using System;
using System.Collections.Generic;

namespace Prasoft.Models
{
    public class PictureAddViewModel
    {
        public long ProductId { get; set; }
        public string ImageUrl { get; set; }
    }


    //----------------------------------------------------------------------------------------


    public class ProductListModel
    {
        public ProductListModel()
        {

            Images = new List<string>();
            Variants = new List<ProductVariantGroupModel>();

        }
        public long Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string CategoryName{ get; set; }
        public string Description { get; set; }
        public long Stock { get; set; }
        public double Price { get; set; }
        public List<string> Images { get; set; }
        public List<ProductVariantGroupModel> Variants { get; set; }
    }


    //----------------------------------------------------------------------------------------
    public class OrderAddModel
    {
        public OrderAddModel()
        {
            OrderLine = new HashSet<OrderLineAddModel>();
        }

        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerMailAddress { get; set; }
        public string CustomerTaxAdministration { get; set; }
        public long CustomerTaxId { get; set; }

        public virtual ICollection<OrderLineAddModel> OrderLine { get; set; }
    }
    public class OrderLineAddModel
    {
        public long ProductVariantGroupId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountRate { get; set; }

       
    }
    public class OrderListModel
    {
        public OrderListModel()
        {
            OrderLine = new HashSet<OrderLineListModel>();
        }

        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerMailAddress { get; set; }
        public string CustomerTaxAdministration { get; set; }
        public long CustomerTaxId { get; set; }

        public virtual ICollection<OrderLineListModel> OrderLine { get; set; }
    }
    public class OrderLineListModel
    {
        public OrderLineListModel()
        {
            Variant = new ProductVariantGroupModel();
        }
        public ProductVariantGroupModel Variant { get; set; }

        public string ProductName { get; set; }
        public long Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountRate { get; set; }


    }
    public class ProductAddModel
    {
        public ProductAddModel()
        {
           
            Images = new List<string>();
            Variants = new List<ProductVariantGroupModel>();

        }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoriName { get; set; }
        public long Stock { get; set; }
        public float Price { get; set; }
        public List<string> Images { get; set; }
        public List<ProductVariantGroupModel> Variants { get; set; }
    }
    //----------------------------------------------------------------------------------------

    public class ProductVariantGroupModel
    {
        public ProductVariantGroupModel()
        {
            VariantNames = new List<VariantNameModel>();
        }
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string Barcode { get; set; }
        public double? Price { get; set; }
        public long? Stock { get; set; }
        public List<string> Images { get; set; }
        public List<VariantNameModel> VariantNames { get; set; }
        
    }
    //----------------------------------------------------------------------------------------

    public class VariantNameModel
    {
        public string VariantValue { get; set; }
        public string VariantName { get; set; }
    }

    public class CategoryListModel
    {
        public CategoryListModel()
        {
            SubCategories = new List<CategoryListModel>();
        }

        public string CategoryName { get; set; }
        public long CategoryId { get; set; }
        public List<CategoryListModel> SubCategories { get; set; }

    }


    //----------------------------------------------------------------------------------------






    public class ApiResultModel
    {
        public ApiResultModel()
        {
            ErrorMessages = new List<string>();
        }
        public bool Success { get; set; }
        public object item  { get; set; }
        public List<string> ErrorMessages  { get; set; }

    }
    //----------------------------------------------------------------------------------------

    public class PaginationParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 100;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
    //----------------------------------------------------------------------------------------
    public class variantListModel
    {
        public variantListModel()
        {
            VariantNames = new List<VariantNamelisteModel>();
        }
        public string Barcode { get; set; }
        public double? Price { get; set; }
        public long? Stock { get; set; }
        public List<VariantNamelisteModel> VariantNames { get; set; }
    }
    public class VariantNamelisteModel
    {
        public VariantNamelisteModel()
        {
            VariantValues = new List<VariantValueListModel>();
        }
        public List<VariantValueListModel> VariantValues { get; set; }
        public string VariantName { get; set; }
    }
    public class VariantValueListModel
    {
        public string VariantValue { get; set; }

    }
}
