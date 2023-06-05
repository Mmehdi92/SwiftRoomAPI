using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Data;
using SwiftRoomAPI.Exceptions;
using SwiftRoomAPI.Models.Room;

namespace SwiftRoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "User")]
    public class RoomsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoomsRepository _roomsRepository;

        public RoomsController(IMapper mapper, IRoomsRepository roomsRepository)
        {
            this._mapper = mapper;
            this._roomsRepository = roomsRepository;
        }

        // GET: api/Rooms
        [HttpGet]

        public async Task<ActionResult<IEnumerable<GetRoomDto>>> GetRooms()
        {
            try
            {
                var rooms = await _roomsRepository.GetAllAsync();
                var records = _mapper.Map<List<GetRoomDto>>(rooms);
                return Ok(records);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            try
            {
                var room = await _roomsRepository.GetDetailsAsync(id);
                if (room == null)
                {
                    return NotFound();
                }
                var roomDto = _mapper.Map<RoomDto>(room);
                return Ok(roomDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<IActionResult> PutRoom(int id, UpDateRoomDto updateRoomDto)
        {
            if (id != updateRoomDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(room).State = EntityState.Modified;

            var room = await _roomsRepository.GetAsync(id);
            if (room == null)
            {
                //throw new NotFoundException(nameof(PutRoom), id);
                return NotFound();
            }
            _mapper.Map(updateRoomDto, room);

            try
            {
                await _roomsRepository.UpdateAsync(room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(CreateRoomDto createRoom)
        {
            var room = _mapper.Map<Room>(createRoom);
            await _roomsRepository.AddAsync(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomsRepository.GetAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            await _roomsRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> RoomExists(int id)
        {
            return await _roomsRepository.Exists(id);
        }
    }
}
