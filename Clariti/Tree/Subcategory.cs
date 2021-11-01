
using System.Collections.Generic;

namespace ClaritiProject.Tree
{

    public class Subcategory
    {
        public string Name { get; set; }
        public double Fees { get; set; } = 0;
        public List<Type> Type { get; set; } = new List<Type>();

        public Subcategory(string Name, double Fees) {
            this.Name = Name;
            this.Fees = Fees;
        }

        public void AddType(string name, double fee)
        {
            try
            {
                var t = Type.Find(x => x.Name == name);
                if (t != null) { t.Fees += fee; return; }

                t = new Type(name, fee);
                Type.Add(t);
            }
            catch { throw; }
        }
    }

    public class Type
    {
        public string Name { get; set; }
        public double Fees { get; set; } = 0;
        public Type(string name, double fee)
        {
            Name = name;
            Fees = fee;
        }
    }
}
