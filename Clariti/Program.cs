using System;
using System.Collections.Generic;
using System.IO;
using ClaritiProject.Tree;

namespace ClaritiProject
{
    class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"C:\Zola\Interview\Clariti\raw_fees.csv");
            string line;
            MultiNodeTree t = new MultiNodeTree();

            int i = 0;

            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    if (i == 0) { i++; continue; }

                    string[] input = line.Split(",");
                    double fee = Convert.ToDouble(input[5]) * Convert.ToDouble(input[6]);
                    string department = input[1];
                    string category = input[2];
                    string subCategory = input[3];
                    string type = input[4];


                    var calculatedFee = CalculateFeeByDepartment(department, fee);

                    // add records
                    t.AddDepartment(department, calculatedFee)
                       .AddCategory(category, calculatedFee)
                       .AddSubcategory(subCategory, calculatedFee)
                       .AddType(type, calculatedFee);
                }
                catch (Exception ex)
                {
                    //no configuration 
                    // can use apppsetting, startup.cs configure method to set logging
                    // in asp.net core 
                    logger.Error(ex);
                }
            }

            //What are the total Cat1 fees within Quality Assurance Category of the Development department?

            var question_1_sol = Math.Round(t.DepartmmentList.Find(x => x.Name == "Development")
                .CategoryList.Find(v => v.Name == "Quality Assurance")
                .SubcategoryList.Find(g => g.Name == "Cat1").Fees);

            //What are the total fees for the Human Resources category of the Operations department? A
            var question_2_sol = Math.Round(t.DepartmmentList.Find(x => x.Name == "Operations")
        .CategoryList.Find(v => v.Name == "Human Resources").Fees);
        }

        private static double CalculateFeeByDepartment(string name, double fee)
        {
            return name switch
            {
                "Marketing" => fee * 110 / 100,
                "Sales" => fee * 150 / 100,
                "Development" => fee * 120 / 100,
                "Operations" => fee * 85 / 100,
                "Support" => fee * 95 / 100,
                _ => fee,
            };
        }
    }
}