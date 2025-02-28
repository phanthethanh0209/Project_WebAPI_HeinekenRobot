using AutoMapper;
using TheThanh_WebAPI_RobotHeineken.Data;
using TheThanh_WebAPI_RobotHeineken.DTO;

namespace TheThanh_WebAPI_RobotHeineken.Mapper
{
    public class MappingRolePermission : Profile
    {
        public MappingRolePermission()
        {
            CreateMap<RolePermissionDTO, RolePermission>().ReverseMap();
        }
    }
}
