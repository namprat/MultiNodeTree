
using System.Collections.Generic;

namespace ClaritiProject.Tree
{
    public class Department
    {
        public string Name { get; set; }
        public double Fees { get; set; } = 0;
        public List<Category> CategoryList { get; set; } = new List<Category>();
        public Department(string Name, double Fees)
        {
            this.Name = Name;
            this.Fees = Fees;
        }

        public Category AddCategory(string name, double fee)
        {
            var cat = CategoryList.Find(x => x.Name == name);
            if (cat != null) { cat.Fees += fee; return cat; }

            cat = new Category(name, fee);
            CategoryList.Add(cat);
            return cat;
        }
    }
}
