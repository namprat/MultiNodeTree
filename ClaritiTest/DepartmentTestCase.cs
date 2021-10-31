using NUnit.Framework;
using Saurab;
using System.Linq;

namespace ClaritiTest
{
    public class Tests
    {
        const string DT_NAME = "department-1";
        const string RANDOM = "random";
        const string CT_NAME = "category-1";
        const string SCT_NAME = "subcategory-1";
        const string TYPE_NAME = "type-1";
        const double CONSTANT_FEE = 11.11;
        Tree t;

        [SetUp]
        public void Setup()
        {
            t = new Tree();
        }

        //Department name not found
        #region Department 

        [Test]
        public void GetFees_DepartmentNameNotExist_ReturnsSameFee()
        {

            //arrange
            t.AddDepartment(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE);
            //assert
            Assert.AreEqual(t.DepartmmentList.Last<Department>().Fees, CONSTANT_FEE);

        }

        [Test]
        public void GetFees_DepartmentNameNotExist_ReturnsSameDepartmentName()
        {

            //arrange
            t.AddDepartment(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE);
            //assert
            Assert.AreEqual(t.DepartmmentList.Last<Department>().Name, DT_NAME);

        }

        [Test]
        public void GetFees_DepartmentNameExist_ReturnsDoubleFee()
        {

            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE);
            //assert
            Assert.AreEqual(t.DepartmmentList.Last<Department>().Fees, 2 * CONSTANT_FEE);

        }

        #endregion

        #region Category

        [Test]
        public void GetFees_CategoryNameNotExist_ForSameParent_ReturnsSameFee()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE);
            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME).CategoryList.Last<Category>().Fees, CONSTANT_FEE);

        }

        [Test]
        public void GetName_CategoryNameNotExist_ForSameParent_ReturnSameCategoryName()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME).CategoryList.Last<Category>().Name, CT_NAME);

        }

        [Test]
        public void GetFees_CategoryNameExist_ForSameParent_ReturnsDoubleFee()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE);

            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME).CategoryList.Last<Category>().Fees, 2 * CONSTANT_FEE);

        }

        [Test]
        public void GetFees_CategoryNameExist_ForSameParent_ReturnLastCategorySame()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME).CategoryList.Last<Category>().Name, CT_NAME);

        }
        #endregion

        #region Subcategory

        [Test]
        public void GetFees_SubCategoryNameNotExist_ForSameParent_ReturnsSameFee()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                .CategoryList.Find(x => x.Name == CT_NAME)
                .SubcategoryList.Last<Subcategory>().Fees, CONSTANT_FEE);

        }

        [Test]
        public void GetName_SubCategoryNameNotExist_ForSameParent_ReturnSameSubCategoryName()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                  .CategoryList.Find(x => x.Name == CT_NAME)
                  .SubcategoryList.Last<Subcategory>().Name, SCT_NAME);

        }

        [Test]
        public void GetFees_SubCategoryNameExist_ForSameParent_ReturnsDoubleFee()
        {

            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                 .CategoryList.Find(x => x.Name == CT_NAME)
                 .SubcategoryList.Last<Subcategory>().Fees, 2 * CONSTANT_FEE);

        }

        [Test]
        public void GetFees_SubCategoryNameExist_ForSameParent_ReturnLastCategoryName()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                .CategoryList.Find(x => x.Name == CT_NAME)
                .SubcategoryList.Last<Subcategory>().Name, SCT_NAME);

        }

        #endregion

        #region Type

        [Test]
        public void GetFees_TypeNotExist_ForSameParent_ReturnsSameFee()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(TYPE_NAME, CONSTANT_FEE); ;

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                .CategoryList.Find(x => x.Name == CT_NAME).SubcategoryList.Find(v => v.Name == SCT_NAME)
                .Type.Last<Type>().Fees, CONSTANT_FEE);

        }

        [Test]
        public void GetName_TypeNameNotExist_ForSameParent_ReturnSameTypeName()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(RANDOM, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(TYPE_NAME, CONSTANT_FEE);

            //assert
            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                   .CategoryList.Find(x => x.Name == CT_NAME).SubcategoryList.Find(v => v.Name == SCT_NAME)
                   .Type.Last<Type>().Name, TYPE_NAME);

        }

        [Test]
        public void GetFees_TypeNameExist_ForSameParent_ReturnsTypeFee()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(TYPE_NAME, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(TYPE_NAME, CONSTANT_FEE);

            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                   .CategoryList.Find(x => x.Name == CT_NAME).SubcategoryList.Find(v => v.Name == SCT_NAME)
                   .Type.Last<Type>().Fees, 2 * CONSTANT_FEE);


        }

        [Test]
        public void GetFees_TypeNameExist_ForSameParent_ReturnLastTypeName()
        {
            //arrange
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(TYPE_NAME, CONSTANT_FEE);
            //act 
            t.AddDepartment(DT_NAME, CONSTANT_FEE).AddCategory(CT_NAME, CONSTANT_FEE).AddSubcategory(SCT_NAME, CONSTANT_FEE)
                .AddType(TYPE_NAME, CONSTANT_FEE);

            Assert.AreEqual(t.DepartmmentList.Find(x => x.Name == DT_NAME)
                   .CategoryList.Find(x => x.Name == CT_NAME).SubcategoryList.Find(v => v.Name == SCT_NAME)
                   .Type.Last<Type>().Name, TYPE_NAME);

        }

        #endregion
    }
}