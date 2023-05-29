using AutoMapper;
using SwiftRoomAPI.Data;
using SwiftRoomAPI.Models.Appointment;
using SwiftRoomAPI.Models.Room;

namespace SwiftRoomAPI.Configurations
{
    public class MapperConfig: Profile 
    {
        public MapperConfig()
        {
            //Room Dto Mapping
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<Room, GetRoomDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, UpDateRoomDto>().ReverseMap();  

            //Appointment Dto Mapping
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
        }
    }
}
