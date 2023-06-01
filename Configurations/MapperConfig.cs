using AutoMapper;
using SwiftRoomAPI.Data;
using SwiftRoomAPI.Models;
using SwiftRoomAPI.Models.Appointment;
using SwiftRoomAPI.Models.Reservation;
using SwiftRoomAPI.Models.Room;
using SwiftRoomAPI.Models.Users;

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
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentDto>().ReverseMap();

            //Reservation Dto Mapping
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();

            //User Dto Mapping
            CreateMap<ApiUserDto, ApiUser>().ReverseMap();

        }
    }
}
