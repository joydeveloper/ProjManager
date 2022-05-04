using Microsoft.EntityFrameworkCore;
using System;

namespace DataModels
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return $"{Id}/{Name} {Description}";
        }
    }
    [Index("Email", IsUnique = true, Name = "Email_Index")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public string? Fname { get; set; }
        public string? Email { get; set; }
        public override string ToString()
        {
            return $"{Id}/{Name} {Sname} {Fname} {Email}";
        }

    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ExecutorCompanyName { get; set; }
        public string? CustomerCompanyName { get; set; }
        public int Lead { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime Finish_date { get; set; }
        public int Priority { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
        public int ProjId { get; set; }
        public int EmployeeId { get; set; }
    }


}
