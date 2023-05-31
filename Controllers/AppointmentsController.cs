using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Data;
using SwiftRoomAPI.Models.Appointment;

namespace SwiftRoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._appointmentRepository = appointmentRepository;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return Ok(_mapper.Map<List<AppointmentDto>>(appointments));

        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AppointmentDto>(appointment));
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentByUser(string userId)
        {
            var appointments = await _appointmentRepository.GetAppointmentFromuser(userId);
            if (appointments == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<AppointmentDto>>(appointments));
        }


        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(appointment).State = EntityState.Modified;
            var appointment = await _appointmentRepository.GetAsync(id);
            
            if(appointment is null)
            {
                return NotFound();
            }
            _mapper.Map<UpdateAppointmentDto>(appointment);
            try
            {
                await _appointmentRepository.UpdateAsync(appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(CreateAppointmentDto createAppointment)
        {
            var appointment = _mapper.Map<Appointment>(createAppointment);
            await _appointmentRepository.AddAsync(appointment);

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return CreatedAtAction("GetAppointment", new { id = appointmentDto.Id }, appointmentDto);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrator")]

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> AppointmentExists(int id)
        {
            return await _appointmentRepository.Exists(id);
        }
    }
}
