using System.Globalization;

namespace Day2DemoProblemStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region "pdfLogicRegion"

            //Console.WriteLine("Create");
            //Console.WriteLine("validate");
            //Console.WriteLine(("parse"));
            //Console.WriteLine(("save"));
            #endregion


            #region "hardcoded basic objects creations"
            //now what i can do here is i can create an object of the pdf report here and i can have the pdf-report generator

            //pdfReport report = new pdfReport();
            //docxReport docxReport = new docxReport();

            //report.reportGenerator();
            //docxReport.reportGenerator();
            #endregion


            #region "generalised object creation"
            reportFactory factory = new reportFactory();
            Console.WriteLine("Enter 1 for pdf report and 2 for docx report");
            report myReport = null;

            myReport = factory.GetReport(Convert.ToInt32(Console.ReadLine()));

            myReport.reportGenerator();
            #endregion


            Console.ReadLine();
        }
    }

    //instead of creating the objects in main file its better if we create a factory class which will create the objects for us
    public class reportFactory
    {
        public report GetReport(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new pdfReport();
                case 2:
                    return new docxReport();
                default:
                    throw new ArgumentException("Invalid choice");
            }
        }
    }


    //now i will create a class for report as a base class since the logic is same for both the reports either pdf or docx
    public abstract class report
    {
        //this class will have the common logic for both the reports
        public void reportGenerator()
        {
            Create();
            Validate();
            Parse();
            Save();
        }

        protected abstract void Validate();
        protected abstract void Create();
        protected abstract void Parse();
        protected abstract void Save();
    }


    #region "generalised pdfReportRegion"
    //now i have extracted the logic and put it in the class called PDF report
    public class pdfReport : report
    {
        

        protected override void Save()
        {
            Console.WriteLine(("pdf - saved"));
        }

        protected override void Parse()
        {
            Console.WriteLine(("pdf - parsed"));
        }

        protected override void Validate()
        {
            Console.WriteLine("pdf - validated");
        }

        protected override void Create()
        {
            Console.WriteLine("pdf - Created");
        }
    }
    #endregion

    #region "notgeneralised-docxReportRegion"
    //similarly another class with the docx report
    //public class docxReport
    //{
    //    public void reportGenerator()
    //    {
    //        Console.WriteLine("docx - Created");
    //        Console.WriteLine("docx - validated");
    //        Console.WriteLine(("docx - parsed"));
    //        Console.WriteLine(("docx - saved"));
    //    }
    //}
    #endregion

    #region "generalised-docxReportRegion"
    public class docxReport : report
    {

        protected override void Save()
        {
            Console.WriteLine(("docx - saved"));
        }

        protected override void Parse()
        {
            Console.WriteLine(("docx - parsed"));
        }

        protected override void Validate()
        {
            Console.WriteLine("docx - validated");
        }

        protected override void Create()
        {
            Console.WriteLine("docx - Created");
        }
    }
    #endregion
}
