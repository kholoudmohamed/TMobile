using System;
using TmobileTask.BaseFramework;

namespace TmobileTask.Pages.EmployeesPage
{
    public class EmployeesPage : BasePage<EmployeesPageMap, EmployeesPageValidator>
    {
        public EmployeesPage() : base(@"/employees")
        { }
    }
}
