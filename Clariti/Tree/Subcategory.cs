
using System.Collections.Generic;

namespace ClaritiProject.Tree
{

    public class Subcategory
    {
        public string Name { get; set; }
        public double Fees { get; set; } = 0;
        public List<Type> Type { get; set; } = new List<Type>();
        public void AddType(string name, double fee)
        {
            var t = Type.Find(x => x.Name == name);
            if (t != null) { t.Fees += fee; return; }

            t = new Type() { Name = name, Fees = fee };
            Type.Add(t);
        }
    }

    public class Type
    {
        public string Name { get; set; }
        public double Fees { get; set; } = 0;
    }
}
