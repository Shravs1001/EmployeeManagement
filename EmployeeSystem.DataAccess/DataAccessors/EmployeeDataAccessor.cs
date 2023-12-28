using AttendanceSystem.DataAccess.Common.Entities;
using AttendanceSystem.DataAccess.Common.Interfaces;
using AttendanceSystem.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AttendanceSystem.DataAccess.DataAccessors
{
    public class EmployeeDataAccessor : IEmployeeDataAccessor
    {
        private readonly DataDbContext employeeContext;

        public EmployeeDataAccessor(DataDbContext dataDbContext) 
        { 
            this.employeeContext = dataDbContext; 
        }

        public List<EmployeeEntity> GetEmployeeList()
        {
            return employeeContext.Employees.ToList();
        }

        public EmployeeEntity GetbyId(int employeeId)
        {
            return employeeContext.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }
        public async Task<AddResponse> AddEmployee(EmployeeEntity newEmp)
        {
            var saveResponse = new AddResponse();
            await employeeContext.AddAsync(newEmp);
            try
            {              
                await employeeContext.SaveChangesAsync();               
                saveResponse.IsSuccess= true;
                saveResponse.ErrorCode = (int)HttpStatusCode.Created;
            }            
            catch (DbUpdateConcurrencyException)
            {
                saveResponse.IsSuccess = false;
            }
            return saveResponse;
        }

        public async Task<ChangeResponse> UpdateUser(EmployeeEntity updateEmp)
        {
            var saveresponse = new ChangeResponse();            
            try
            {
                employeeContext.Update(updateEmp);
                await employeeContext.SaveChangesAsync();
                saveresponse.ErrorCode = (int)HttpStatusCode.OK;
                saveresponse.IsSuccess = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                saveresponse.IsSuccess = false;
            }
            return saveresponse;
        }

        public async Task<DeleteEmpResponse> DelEmployee(EmployeeEntity employee)
        {
            var deleteresponse = new DeleteEmpResponse();           
            employeeContext.Remove(employee);
            try
            {
                await employeeContext.SaveChangesAsync();
                deleteresponse.IsSuccess = true;
                deleteresponse.ErrorCode = (int)HttpStatusCode.OK;
            }
            catch (DbUpdateConcurrencyException)
            {
                deleteresponse.IsSuccess = false;
            }
            return deleteresponse;
        }

    }
}
