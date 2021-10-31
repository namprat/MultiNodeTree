
using System.Collections.Generic;

namespace ClaritiProject.Tree
{
    public class MultiNodeTree
    {
        public List<Department> DepartmmentList { get; set; } = new List<Department>();

        public Department AddDepartment(string name, double fee)
        {
            var dept = DepartmmentList.Find(x => x.Name == name);
            if (dept != null) { dept.Fees += fee; return dept; }

            dept = new Department( name, fee);
            DepartmmentList.Add(dept);
            return dept;
        }

    }
}
