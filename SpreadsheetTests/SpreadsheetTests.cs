using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpreadsheetUtilities;
using SS;

namespace SpreadsheetTests
{
    [TestClass]
    public class SpreadsheetTests
    {
        ///<summary>
        ///Test for all Exception
        ///</summary>
        
        ///<paragraph>
        ///Start of exception test
        ///</paragraph>
        
        //Test for get cell content method
        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]
        public void getInvalidCellName()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.GetCellContents("1A");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]
        public void getNullCellName()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.GetCellContents(null);
        }

        //Set Cell content with number
        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]
        public void setInvalidCellName1()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents("1A1", 1.0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]
        public void setNullCellName1()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents(null, 1.0);
        }

        //Set Cell content with text
        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]
        public void setInvalidCellName2()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents("1A", "hello");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNullCellName2()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents(null, "hello");
        }

        //Set Cell content with formula
        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]
        public void setInvalidCellName3()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents("1A", new Formula("A2+2"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNullCellName3()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents(null, new Formula("A2+2"));
        }
        ///<paragraph>
        ///End of exception test
        ///</paragraph>

        ///<summary>
        ///Functionality test
        ///</summary>

        ///<paragraph>
        ///Start of the Functionality test
        ///</paragraph>
        [TestMethod]
        public void setCellNumber()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents("A1", 42.0);
            sheet.SetCellContents("A2", "hello");
            sheet.SetCellContents("A1", 43.0);
            Assert.AreEqual("hello", sheet.GetCellContents("A2"));
            Assert.AreEqual(43.0, sheet.GetCellContents("A1"));
        }

        [TestMethod]
        public void setCelNumberFormula()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents("A1", new Formula("A2"));
            sheet.SetCellContents("A2", new Formula("A3+3"));
            sheet.SetCellContents("A3", new Formula("2+3+A4"));
            Assert.AreEqual("A3+3", sheet.GetCellContents("A2").ToString());
        }

        [TestMethod]
        public void getNameOfAllNonEmptyCellTest()
        {
            Spreadsheet sheet = new Spreadsheet();
            sheet.SetCellContents("A1", new Formula("A2"));
            sheet.SetCellContents("A2", new Formula("A3+3"));
            sheet.SetCellContents("A3", new Formula("2+3+A4"));
            var cell = sheet.GetNamesOfAllNonemptyCells();
            Assert.IsTrue(cell.Contains("A1"));
            Assert.IsTrue(cell.Contains("A2"));
        }
        ///<paragraph>
        ///End of the Functionality test
        ///</paragraph>
    }
}