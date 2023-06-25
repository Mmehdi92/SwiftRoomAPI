﻿using System;
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
using SwiftRoomAPI.Models.Reservation;

namespace SwiftRoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepository reservationRepository, IMapper mapper)
        {
            this._reservationRepository = reservationRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservation()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return Ok(_mapper.Map<List<ReservationDto>>(reservations));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservation(int id)
        {
            var reservation = await _reservationRepository.GetAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReservationDto>(reservation));
        }

        [HttpGet("user/{userId}")]
        public async Task <ActionResult<IEnumerable<ReservationDto>>> GetReservationFromUser(string userId)
        {
            var reservations = await _reservationRepository.GetReservationsFromUser(userId);
            if(reservations is null)
            {
                return NotFound();
            }
            var reservationDto = _mapper.Map<List<ReservationDto>>(reservations);
            return Ok(reservationDto);
        }
      

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, UpdateReservationDto updateReservationDto)
        {
            if (id != updateReservationDto.Id)
            {
                return BadRequest();
            }

            var reservation = await _reservationRepository.GetAsync(id);
            if(reservation is null)
            {
                return NotFound();
            }

            _mapper.Map(updateReservationDto, reservation);

            try
            {
                await _reservationRepository.UpdateAsync(reservation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReservationExists(id))
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

        //[HttpPost]
        //public async Task<ActionResult<Reservation>> PostReservation(ReservationDto createReservation)
        //{

        //    var reservation = _mapper.Map<Reservation>(createReservation);
        //    await _reservationRepository.AddAsync(reservation);

        //    var reservationDto = _mapper.Map<ReservationDto>(reservation);
        //    return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservationDto);
        //}


        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            try
            {
                bool isAvailable =  _reservationRepository.IsTimeSlotAvailable(reservation.StartTime, reservation.EndTime);

                if (!isAvailable)
                {
                    return BadRequest("The specified time slot is already booked.");
                }

                await _reservationRepository.AddReservationUnique(reservation);

                return Ok(reservation);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Invalid request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the reservation: {ex.Message}");
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.GetAsync(id);
            if (reservation is null)
            {
                return NotFound();
            }

            await _reservationRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task <bool> ReservationExists(int id)
        {
            return await _reservationRepository.Exists(id);
        }
    }
}
