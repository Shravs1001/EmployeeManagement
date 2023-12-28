using AttendanceSystem.DataAccess.Common.Entities;
using AttendanceSystem.DataAccess.Common.Models;

namespace AttendanceSystem.DataAccess.Common.Interfaces
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
