// Course assignment "PersonalID"
// Written by Engin Mustafa, SE-1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalID
{
    class Program
    {
        enum sex //declaration of parameter for clarifying the sex
        {
            Male = 1,
            Female = 2
        };
        static void CheckID(string ID) {
            int[] weight = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 }; //Numbers for multiplying ID 
            long intID; //parameter for ID after parse
            bool isNumerical = long.TryParse(ID, out intID); //declaration of parameter for testing if string is numerical
            int ctrSum = 0; //parameter for Sum of multiplied numbers to verify ID
            
            //loop for validation algorithm
            for (int i = 0; i < ID.Length - 1; i++) {
                int val = (int)Char.GetNumericValue(ID[i]);
                ctrSum += val * weight[i];
            }
            //Calculating the control number
            int ctrDigit = ctrSum % 11;
            if (ctrDigit >= 10) ctrDigit = 0;

            //Getting the last number of ID and converting it into int parameter
            int lastDigit = (int)Char.GetNumericValue(ID[ID.Length - 1]); 

            //(Validation of ID)Checking whether the ID is numerical, it consists of 10 numbers and the last number is equal to the control number.
            if (isNumerical & ID.Length == 10 & lastDigit == ctrDigit) 
            {
                //Getting first two numbers of the ID for the birth year.
                int birthYear = Convert.ToInt32(string.Format("{0}{1}", ID[0], ID[1]));

                //Getting 3th and 4th number for birth month.
                int birthMonth = Convert.ToInt32(string.Format("{0}{1}", ID[2], ID[3]));

                //loop for calculating the year
                if (birthMonth > 20 && birthMonth < 40) {
                    birthYear += 1800;
                }
                else if (birthMonth > 40) {
                    birthYear += 2000;
                }
                else birthYear += 1900;
                int birthDay = Convert.ToInt32(string.Format("{0}{1}", ID[4], ID[5]));

                //loop for calculating the month of birth(before/after 1899/1999).
                if (birthYear <= 1900 && birthMonth == 1 && birthDay == 1) {
                    birthMonth -= 20;
                }
                else if (birthYear <= 1899) {
                    birthMonth -= 20;
                }
                else if (birthYear == 1999 && birthMonth == 1 && birthDay == 31) {
                    birthMonth -= 40;
                }
                else if (birthYear >= 1999 && birthMonth >= 2) {
                    birthMonth -= 40;
                }

                //algorithm to check gender
                sex gender;
                int genderCheck = (int)Char.GetNumericValue(ID[8]);
                if (genderCheck % 2 == 0) {
                    gender = sex.Male;
                } else gender = sex.Female;

                Console.Write("True; \nBirthdate(Y/M/D):{0}/{1}/{2}\nGender: {3};", birthYear, birthMonth, birthDay, gender);
            } else Console.Write("False");

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter valid ID: ");
            string ID = Console.ReadLine();
            CheckID(ID);
        }
    }
}

