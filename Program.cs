using System;
using static System.Console;

namespace TakeHomePay
{
    class TestApp
    {
        static void Main(string[] args)
        {
            //call to opening screen method
            PrintIntro();

            //create a new employee
            Employee employee1 = new Employee();
            //firstName
            employee1.FirstName = AquireStringValues("employee's first name: ");
            //lastName
            employee1.LastName = AquireStringValues("employee's last name: ");
            //employeeID
            employee1.EmployeeID = AquireStringValues("the employee's identification number: ");
            //salary or hourly
            employee1.PayStatus = AquireStringValues("an S for salaried employee, \nor an H for hourly employee: ");
            
            //pay for the period
            if ((employee1.PayStatus == "S") || (employee1.PayStatus == "s"))
            {
                employee1.Pay = AquireDoubleValues("weekly salary: ");
            }
            if ((employee1.PayStatus == "H") || (employee1.PayStatus == "h"))
            {
                employee1.hours = AquireDoubleValues("hours for the week: ");
                employee1.PayRate = AquireDoubleValues("hourly pay rate: ");
            }
            else
            {
                Write("You have entered an incorrect option\n Returning to Main Menu");
                Clear();
                PrintIntro();
            }

            Employee employee2 = new Employee("Alma", "Hitower", "00987", "S", 5000);

            WriteLine(employee1.ToString());

            WriteLine("\t\t\nWeekly Information For {0}\nEmployeeID: {1}\nEmployee Type: Salaried" +
               "\nGross Pay: {2:c}\nFederal Taxes: {3:c}\nSocial Security: {4:c}\nRetirement Contribution: {5:c}" +
               "\n\nTotal Deductions: {6:c}\nTake Home Pay: {7:c}", employee2.ReturnFullName(),
               employee2.EmployeeID, employee2.CalculateGrossPay(), employee2.CalculateFederal(),
               employee2.CalculateSocialSecurity(), employee2.CalculateRetirement(), employee2.CalculateTotalDeductions(),
               employee2.CalculateTakeHomePay());

            ReadKey();
        }

        //Print intro
        static public void PrintIntro()
        {
            Write("\tEMPLOYEE TAKE HOME PAY APPLICATION" +
                "\nYou will be asked to enter the name of an employee" +
                "\nand the type of employee (Hourly or Salaried)." +
                "\n\nCalculations will be preformed to" +
                "\ndetermine his/her deductions and take home pay.\n\n");
        }

        //Asking the user for the string values
        static public String AquireStringValues(String whichString)
        {
            Write("Please enter {0}", whichString);
            String inValue = ReadLine();

            return inValue;
        }

        //Asking the user for the double values
        static public Double AquireDoubleValues(String whichString)
        {
            Write("Please enter {0}", whichString);
            String inValue = ReadLine();

            return double.Parse(inValue); ;
        }


    }
}
