// See https://aka.ms/new-console-template for more information
using DataModels;
string InitialData()
{
    using (ApplicationContext db = new ApplicationContext())
    {
        bool isCreated = db.Database.EnsureCreated();
        if (isCreated) return "База данных была создана";
        else return "База данных уже существует";
    }
}
void AddEmployee(string name, string sname, string email)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        Employee emp = new Employee() { Name = name, Sname = sname, Email = email };
        if (!db.Employees.Any(n => n.Name == name && n.Sname == sname && n.Email == email))
        {
            db.Add(emp);
            db.SaveChanges();
        }
    }
}
bool RemoveEmployee(string name, string sname, string email)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        try
        {
            Employee emp = db.Employees.First(n => n.Name == name && n.Sname == sname && n.Email == email);
            if (emp != null)
            {
                db.Remove(emp);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (ArgumentNullException)
        {
            return false;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}
Employee? FindEmployee(string name, string sname, string email)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        try
        {
            Employee emp = db.Employees.First(n => n.Name == name && n.Sname == sname && n.Email == email);
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }
        catch (ArgumentNullException)
        {
            return null;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}
void EditEmployee(Employee emp, string name="", string sname="", string email="")
{
    using (ApplicationContext db = new ApplicationContext())
    {
        if (emp != null)
        {
            if(name!="")
            emp.Name = name;
            if(sname!="")
            emp.Sname = sname;
            if(email!="")
            emp.Email = email;
            db.Employees.Update(emp);
            db.SaveChanges();
        }
    }
}
InitialData();
AddEmployee("Sergey", "Fedulenko", "joy2431@mail.ru");
//RemoveEmployee("Serg", "Fedulenko", "joy2431@mail.ru");
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
//EditEmployee(FindEmployee("Sergey", "Fedulenko", "joy2431@mail.ru"), "Serg");
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
