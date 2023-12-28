using EmployeeManagement.Common.Interfaces;
using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.Common.Models.Response;
using EmployeeManagement.DataAccess.Common.Entities;
using EmployeeManagement.DataAccess.Common.Interfaces;
using EmployeeManagement.DataAccess.Common.Models;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace EmployeeManagement.Services
{
    public class LoginService : ILoginService
    {      
        private readonly ILoginDataAccessor loginDataAccessor;        
               
        public LoginService(ILoginDataAccessor loginsDataAccessor) 
        {           
            this.loginDataAccessor = loginsDataAccessor;
        }

        public string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);

        }

        public async Task<CreatePasswordResponse> AddPassword(int employeeId, string username, string password)
        {
            var addResponse =new CreatePasswordResponse();
            try
            {
                var result = await loginDataAccessor.GetUser(employeeId);
                if (result != null)
                {
                    string hashPassword = HashPassword(password);
                    var updateResponse = await loginDataAccessor.CreatePassword(result);
                    addResponse.IsSuccess = updateResponse.IsSuccess;
                    addResponse.ErrorCode = updateResponse.ErrorCode;
                    addResponse.Message = updateResponse.Message;
                    addResponse.HashPassword = hashPassword;
                    return new CreatePasswordResponse 
                    { 
                        IsSuccess = true, 
                        Message = "Password created", 
                        HashPassword = hashPassword 
                    };
                }
                else
                {
                    addResponse.IsSuccess = false;
                    addResponse.Message = "Employee not found";
                    addResponse.ErrorCode = 400;
                }
            }
            catch (Exception ex)
            {
                addResponse.IsSuccess = false;
                addResponse.ErrorCode = 500;
                addResponse.Message = "Error creating password";
            }
            return addResponse;
        }

        public async Task<UpdateResponse> ChangePassword(ChangePasswordRequest request)
        {
            var response = new UpdateResponse();
            var entity = new LoginEntity();
            var result = await loginDataAccessor.GetUser(request.Id);
            if (result != null)           
            {
                entity.EmployeeId = request.Id;
                entity.NewPassword = request.NewPassword;
                entity.OldPassword = request.OldPassword;
                entity.Username = request.Username;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Employee not found";
                response.ErrorCode = 400;               
                
            }
            return response;
        }

       
    }
}