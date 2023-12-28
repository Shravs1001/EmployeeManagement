using EmployeeManagement.DataAccess.Common.Entities;
using EmployeeManagement.DataAccess.Common.Models;

namespace EmployeeManagement.DataAccess.Common.Interfaces
{
    public interface IEmployeeDataAccessor
    {
        List<EmployeeEntity> GetEmployeeList();
        EmployeeEntity GetbyId(int employeeId);

        Task<AddResponse> AddEmployee(EmployeeEntity newEmp); 

        Task<ChangeResponse> UpdateUser(EmployeeEntity updateEmp);

        Task<DeleteEmpResponse> DelEmployee(EmployeeEntity employee);
    }
}
