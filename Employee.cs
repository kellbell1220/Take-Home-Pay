using System;
using static System.Console;


namespace TakeHomePay
{
    class Employee
    {
        private String firstName;
        private String lastName;
        private String employeeID;
        private String payStatus;
        private Double pay;
        public Double hours;
        private Double payRate;
        public Double FEDERAL = .18;
        public Double SOCIAL_SECURITY = .06;
        public Double RETIREMENT = .10;



        public Employee()
        {

        }

        public Employee(String firstName, String lastName, String employeeID, String payStatus, Double pay)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.employeeID = employeeID;
            this.payStatus = payStatus;
            this.pay = pay;

        }

        public Employee(String firstName, String lastName, String employeeID, String payStatus, Double hours, Double payRate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.employeeID = employeeID;
            this.payStatus = payStatus;
            this.hours = hours;
            this.payRate = payRate;
        }

        //Getter and Setters for all the private variables
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public String EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }

        }

        public String PayStatus
        {
            get
            {
                return payStatus;
            }
            set
            {
                payStatus = value;
            }

        }

        public Double Pay
        {
            get
            {
                return pay;
            }
            set
            {
                pay = value;
            }

        }

        public Double PayRate
        {
            get
            {
                return payRate;
            }
            set
            {
                payRate = value;
            }

        }

        public String ReturnFullName()
        {
            String name = firstName + " " + lastName;
            return name;
        }

        public Double CalculateGrossPay()
        {
            if ((payStatus == "S") || (payStatus == "s"))
            {
                return pay;
            }
            else
            {
                if (hours <= 40)
                {
                    return hours * payRate;
                }
                else
                {
                    Double overtimeHours = hours - 40;
                    Double straightTime = 40 * payRate;
                    Double overtimePay = (payRate * 1.5) * overtimeHours;
                    return straightTime + overtimePay;
                }
            }
        }

        //Calculating Federal Tax
        public Double CalculateFederal()
        {
            return (CalculateGrossPay() * FEDERAL);
        }

        //Calculating Social Security Tax
        public Double CalculateSocialSecurity()
        {
            return (CalculateGrossPay() * SOCIAL_SECURITY);
        }

        //Calculating Retirement Contribution
        public Double CalculateRetirement()
        {
            return (CalculateGrossPay() * RETIREMENT);
        }

        //Calculating Total Deductions 
        public Double CalculateTotalDeductions()
        {
            return (CalculateFederal() + CalculateSocialSecurity() + CalculateRetirement());
        }

        //Calculateing Net Pay
        public Double CalculateTakeHomePay()
        {
            return (CalculateGrossPay() - CalculateTotalDeductions());
        }

        public override string ToString()
        {
            return "\nWeekly Information For " + ReturnFullName() +
                "\n\nEmployee ID: " + employeeID +
                "\nGross Pay: " + CalculateGrossPay().ToString("C") +
                "\nFederal Taxes: " + CalculateFederal().ToString("C") +
                "\nSocial Security: " + CalculateSocialSecurity().ToString("C") +
                "\nRetirement Contribution: " + CalculateRetirement().ToString("C") +
                "\n\nTotal Deductions: " + CalculateTotalDeductions().ToString("C") +
                "\nTake home pay: " + CalculateTakeHomePay().ToString("C");
        }
    }
}
