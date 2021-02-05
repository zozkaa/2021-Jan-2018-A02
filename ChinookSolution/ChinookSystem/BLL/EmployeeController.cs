using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.Entities;
using ChinookSystem.DAL;
using ChinookSystem.ViewModels;
using System.ComponentModel;    //is for ODS
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class EmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<EmployeeCustomerList> Employee_EmployeeCustomersList()
        {
            using (var context = new ChinookSystemContext())
            {
				IEnumerable<EmployeeCustomerList> resultsM = context.Employees
			   .Where(x => x.Title.Contains("Sales Support"))
			   .OrderBy(x => x.LastName)
			   .ThenBy(x => x.FirstName)
			   .Select(x =>
						new EmployeeCustomerList
						 {
							 EmployeeName = ((x.LastName + ", ") + x.FirstName),
							 Title = x.Title,
							 CustomerSupportCount = x.Customers.Count(),
							 CustomerList = x.Customers
							  .Select(
								 y =>
									new CustomerSupportItem
									 {
										 CustomerName = ((y.LastName + ", ") + y.FirstName),
										 Phone = y.Phone,
										 City = y.City,
										 State = y.State
									 }).ToList()
						 });
				return resultsM.ToList();
			}
        }
    }
}
