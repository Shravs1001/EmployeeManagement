using EmployeeManagement.Common.Interfaces;
using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.Common.Models.Response;
using EmployeeManagement.DataAccess.Common.Entities;
using EmployeeManagement.DataAccess.Common.Interfaces;

namespace AttendanceSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDataAccessor employeeDataAccessor;

        public EmployeeService(IEmployeeDataAccessor employeeData)
        {
            this.employeeDataAccessor = employeeData;
        }

        public List<EmployeesResponse> GetEmployees()
        {
            var listEntities = employeeDataAccessor.GetEmployeeList();
            var employeesList = new List<EmployeesResponse>();
            foreach (var entity in listEntities)
            {
                var employees = new EmployeesResponse
                {
                    EmployeeID = entity.EmployeeId,
                    Designation = entity.Designation,
                    Firstname = entity.Firstname,
                    Lastname = entity.Lastname,
                    Fullname = entity.Fullname,
                    Gender = entity.Gender,
                    Email = entity.Email,
                    Role = entity.Role
                };
                employeesList.Add(employees);

            }

            return employeesList;

        }

        public EmployeesResponse GetEmployeeById(int employeeId)
        {
            var employeeEntity = employeeDataAccessor.GetbyId(employeeId);
            if (employeeEntity != null)
            {
                var employeeDetails = new EmployeesResponse
                {
                    EmployeeID = employeeEntity.EmployeeId,
                    Designation = employeeEntity.Designation,
                    Firstname= employeeEntity.Firstname,
                    Lastname= employeeEntity.Lastname,
                    Fullname= employeeEntity.Fullname,
                    Gender = employeeEntity.Gender,
                    Email = employeeEntity.Email,
                    Role = employeeEntity.Role,
                };
                return employeeDetails;
            }
            return null;                    
        }

        public async Task<CreateResponse> CreateEmployee(AddEmployeeRequest model)
        {
            
            var entity = new EmployeeEntity
            {
                EmployeeId = model.EmployeeID,
                Designation = model.Designation,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Fullname = model.Fullname,
                Gender = model.Gender,
                Email = model.Email,
                Role = model.Role
            };
            var addResponse = await employeeDataAccessor.AddEmployee(entity);
            CreateResponse response = new CreateResponse
            {
                IsSuccess = addResponse.IsSuccess,
                ErrorCode = addResponse.ErrorCode,
                Id= addResponse.Id,
                Message = addResponse.Message,
            };
            return response;
        }

        public async Task<UpdateResponse> UpdateEmployee(UpdateEmployeeRequest update)
        {
           
            var entity = new EmployeeEntity
            {
                EmployeeId = update.EmployeeID,
                Designation = update.Designation,
                Firstname = update.Firstname,
                Lastname = update.Lastname,
                Fullname = update.Fullname,
                Gender = update.Gender,
                Email = update.Email,
                Role = update.Role
            };
            var updateResponse = await employeeDataAccessor.UpdateUser(entity);
            UpdateResponse response = new UpdateResponse
            {
                ErrorCode = updateResponse.ErrorCode,
                Message = updateResponse.Message,
                IsSuccess = updateResponse.IsSuccess,
            };
            return response;
        }

        public async Task<DeleteResponse> RemoveEmployee(DeleteEmployeeRequest remove)
        {
            
            var entity = new EmployeeEntity
            {
                EmployeeId = remove.EmployeeId
            };
            var delResponse = await employeeDataAccessor.DelEmployee(entity);
            DeleteResponse response = new DeleteResponse
            {
                ErrorCode = delResponse.ErrorCode,
                Message = delResponse.Message,
                IsSuccess = delResponse.IsSuccess,

            };
            return response;
        }
    }
}