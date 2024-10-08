﻿using AutoMapper;
using HR_Management.MVC.Models.LeaveType;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeVM, UpdateLeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeDto, UpdateLeaveTypeVM>().ReverseMap();
        }
    }
}
