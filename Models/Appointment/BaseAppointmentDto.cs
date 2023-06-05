﻿using System.ComponentModel.DataAnnotations;

namespace SwiftRoomAPI.Models.Appointment
{
    public abstract class BaseAppointmentDto
    {
  
       
        public string Title { get; set; }
        public string Description { get; set; }
        
        public DateTime Begin { get; set; }
      
        public DateTime End { get; set; }
      
    }

}