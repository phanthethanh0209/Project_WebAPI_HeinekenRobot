﻿using AutoMapper;
using TheThanh_WebAPI_RobotHeineken.Data;
using TheThanh_WebAPI_RobotHeineken.DTO;

namespace TheThanh_WebAPI_RobotHeineken.Mapper
{
    public class MappingMachine : Profile
    {
        public MappingMachine()
        {
            CreateMap<CreateMachineDTO, RecyclingMachine>();

            CreateMap<UpdateMachineDTO, RecyclingMachine>() // update
                 .ForMember(dest => dest.CreateAt, opt => opt.Ignore()); // Bỏ qua CreateAt khi map;

            CreateMap<RecyclingMachine, MachineDTO>() // getAll
            .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status == 1 ? "Online" : "Offline"))
            .ForMember(dest => dest.ContainerStatus,
                    opt => opt.MapFrom(src => src.ContainerStatus == 1 ? "Sắp đầy" : "Chưa đầy"));

            CreateMap<RecyclingMachine, ListMachineDTO>() // getSingle
            .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status == 1 ? "Online" : "Offline"))
            .ForMember(dest => dest.ContainerStatus,
                    opt => opt.MapFrom(src => src.ContainerStatus == 1 ? "Sắp đầy" : "Chưa đầy"));

        }
    }
}
