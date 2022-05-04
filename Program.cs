// See https://aka.ms/new-console-template for more information
using DataModels;
void InitialData() {
    using (ApplicationContext db = new ApplicationContext())
    {
        bool isCreated = db.Database.EnsureCreated();
        if (isCreated) Console.WriteLine("База данных была создана");
        else Console.WriteLine("База данных уже существует");
    }
}
void AddEmployee(string name,string sname,string email)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        Employee emp = new Employee() { Name=name,Sname=sname,email=email};
        if (!db.Employees.Any(n => n.Name == name && n.Sname == sname && n.email==email))
        {
            db.Add(emp);
            db.SaveChanges();
        }
    }
}
bool RemoveEmployee(string name,string sname,string email)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        try
        {
            Employee emp = db.Employees.First(n => n.Name == name && n.Sname == sname && n.email == email);
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
InitialData();
AddEmployee("Sergey", "Fedulenko", "joy2431@mail.ru");
RemoveEmployee("Sergey", "Fedulenko", "joy2431@mail.ru");