using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models.LeaveType;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;
        private readonly ILocalStorageService _localStorage;

        public LeaveTypeService(IClient client, IMapper mapper, ILocalStorageService localStorage) 
            : base(client, localStorage)
        {
            _client = client;
            _mapper = mapper;
            _localStorage = localStorage;
        }


        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                var data = _mapper.Map<CreateLeaveTypeDto>(leaveType);
                var apiResponse = await _client.LeaveTypesPOSTAsync(data);

                response.Success = apiResponse.Success;
                response.Message = apiResponse.Message;

                if (apiResponse.Success)
                {
                    response.StatusCode = 200;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.StatusCode = 400;
                    foreach ( var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += $"{error}{Environment.NewLine}";
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                var apiResponse = await _client.LeaveTypesDELETEAsync(id);
                return new Response<int> 
                { 
                    Success = apiResponse.Success, 
                    Message = apiResponse.Message,
                    StatusCode = 200
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var result = await _client.LeaveTypesGETAsync(id);
            var leaveType = _mapper.Map<LeaveTypeVM>(result);
            return leaveType;
        }

        public async Task<UpdateLeaveTypeVM> GetLeaveTypeDetailsForUpdate(int id)
        {
            var leaveType = await GetLeaveTypeDetails(id);
            var final = _mapper.Map<UpdateLeaveTypeVM>(leaveType);
            return final;
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var result = await _client.LeaveTypesAllAsync();
            var leaveTypes = _mapper.Map<List<LeaveTypeVM>>(result);
            return leaveTypes;
        }

        public async Task<Response<int>> UpdateLeaveType(int id, UpdateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                var data = _mapper.Map<UpdateLeaveTypeDto>(leaveType);
                var apiResponse = await _client.LeaveTypesPUTAsync(id, data);

                response.Success = apiResponse.Success;
                response.Message = apiResponse.Message;

                if (apiResponse.Success)
                {
                    response.StatusCode = 200;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.StatusCode = 400;
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += $"{error}{Environment.NewLine}";
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
