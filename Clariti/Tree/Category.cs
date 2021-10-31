using System;
using System.Collections.Generic;
using System.Text;

namespace ClaritiProject.Tree
{
    public class Category
    {
        public string Name { get; set; }
        public double Fees { get; set; } = 0;
        public List<Subcategory> SubcategoryList { get; set; } = new List<Subcategory>();

        public Subcategory AddSubcategory(string name, double fee)
        {
            var cat = SubcategoryList.Find(x => x.Name == name);
            if (cat != null) { cat.Fees += fee; return cat; }

            cat = new Subcategory() { Name = name, Type = new List<Type>(), Fees = fee };
            SubcategoryList.Add(cat);
            return cat;
        }
    }
}
