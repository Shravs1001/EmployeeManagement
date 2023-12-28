using AttendanceSystem.Common.Models.Request;
using AttendanceSystem.DataAccess.Common.Entities;
using AttendanceSystem.DataAccess.Common.Interfaces;
using AttendanceSystem.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AttendanceSystem.DataAccess.DataAccessors
{
    public class LoginDataAccessor: ILoginDataAccessor
    {
        private readonly DataDbContext loginContext;
        public LoginDataAccessor(DataDbContext dataDbContext)
        {
            loginContext = dataDbContext;
        }

        public async Task<LoginEntity> GetUser(int userId)
        {
            return await loginContext.Login.Include(x=>x.Employee).FirstOrDefaultAsync(x=>x.Id == userId);
        }

        public async Task<AddPasswordResponse> CreatePassword(LoginEntity login)
        {
            var saveResponse = new AddPasswordResponse();
            await loginContext.AddAsync(login);
            try
            {
                var existingEmployee = await loginContext.Login.FindAsync(login.EmployeeId);              
                await loginContext.SaveChangesAsync();

                saveResponse.IsSuccess = true;
                saveResponse.ErrorCode = (int)HttpStatusCode.Created;
                saveResponse.Message = "Password Created Successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                saveResponse.IsSuccess = false;
                saveResponse.ErrorCode = (int)HttpStatusCode.InternalServerError;
                saveResponse.Message = "Error Creating password";
            }

            return saveResponse;
        }

       public async Task<UpdatePasswordResponse> UpdatePassword(LoginEntity entity)
       {
            var saveResponse = new UpdatePasswordResponse();
            loginContext.Update(entity);
            try
            {
                var updateEmployee = await loginContext.Login.FindAsync(entity.EmployeeId);
                await loginContext.SaveChangesAsync();
                saveResponse.IsSuccess = true;
                saveResponse.ErrorCode= (int)HttpStatusCode.InternalServerError;
                saveResponse.Message = "Password Updated Successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                saveResponse.IsSuccess = false;
                saveResponse.ErrorCode= (int)HttpStatusCode.InternalServerError;                  
            }
            return saveResponse;
       }
    }
}
