using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class CategoryService
    {
        private void _fillChildrenCategories(Categories category, CategoryListModel newCategory)
        {
            foreach (var children in category.InverseParent)
            {
                var categoryChild = (new CategoryListModel { CategoryName = children.Name });

                _fillChildrenCategories(children, categoryChild);
                newCategory.SubCategories.Add(categoryChild);

            }

        }
        public List<CategoryListModel> getAllCategories()
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                try
                {
                    var categoryList = new List<CategoryListModel>();

                    var categories = prapazdbContext.Categories.Where(a => a.ParentId == null).ToList();
                    foreach (var category in categories)
                    {
                        var newCategory = new CategoryListModel() { CategoryName = category.Name };

                        _fillChildrenCategories(category, newCategory);
                        categoryList.Add(newCategory);
                    }
                    return categoryList;
                }
                catch (Exception e)
                {

                    throw;
                }



            }
        }

    }
}
