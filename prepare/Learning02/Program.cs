using System;

class Program
{
    static void Main(string[] args)
    {
       Job job1 = new Job();
       job1._jobTitle = "Janitor";
       job1._company = "BYU_Idaho";
       job1._startYear = 2021;
       job1.endYear = 2023;
    job1.Display();
    
        Applicant applicant1 = new Applicant();
        applicant1._firstName = "Justin";
        applicant1._lastName = "Maynes";
        applicant1._phoneNumber = "5099195050";
        applicant1._emailAddress = "jtmaynes01@gmail.com";
        applicant1._rank = 1;
    applicant1.Display();
    
    Resume myResume = new Resume();
    myResume._name = "Justin";
    myResume._jobs.Add(job1);

    myResume.Display();

    }
}

