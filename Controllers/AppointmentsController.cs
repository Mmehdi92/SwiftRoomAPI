using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return Ok(_mapper.Map<List<AppointmentDto>>(appointments));

        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<AppointmentDto>(appointment));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirements
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the appointment.");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentByUser(string userId)
        {
            try
            {
                var appointments = await _appointmentRepository.GetAppointmentFromuser(userId);
                if (appointments == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<List<AppointmentDto>>(appointments));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirements
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the appointments by user.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, UpdateAppointmentDto updateAppointmentDto)
        {
            if (id != updateAppointmentDto.Id)
            {
                return BadRequest("invalid record Id");
            }

            var appointment = await _appointmentRepository.GetAsync(id);

            if (appointment is null)
            {
                return NotFound();
            }

            _mapper.Map(updateAppointmentDto, appointment);

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
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirements
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the appointment.");
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(CreateAppointmentDto createAppointment)
        {
            try
            {
                var appointment = _mapper.Map<Appointment>(createAppointment);
                await _appointmentRepository.AddAsync(appointment);

                var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
                return CreatedAtAction("GetAppointment", new { id = appointmentDto.Id }, appointmentDto);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirements
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the appointment.");
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                await _appointmentRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirements
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the appointment.");
            }
        }

        private async Task<bool> AppointmentExists(int id)
        {
            try
            {
                return await _appointmentRepository.Exists(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirements
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
