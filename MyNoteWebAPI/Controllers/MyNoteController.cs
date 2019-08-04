using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteBusinessLibrary;
using NoteBusinessLibrary.Exceptions;

namespace MyNoteWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyNoteController : ControllerBase
    {
        private readonly IMyNoteService service;
        public MyNoteController(IMyNoteService myNoteService)
        {
            service = myNoteService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.GetAllNotes());
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet]
        [Route("{NoteId}")]
        public IActionResult Get(int NoteId)
        {
            try
            {
                return Ok(service.GetNoteById(NoteId));
            }
            catch (NoteNotFoundException nnf)
            {
                return NotFound(nnf.Message);

            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MyNote mynote)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.Created, service.CreateNote(mynote));
            }
            catch (NoteAlreadyExistsException nae)
            {
                return Conflict(nae.Message);

            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{NoteId}")]
        public IActionResult Delete(int NoteId)
        {
            try
            {
                return Ok(service.RemoveNoteById(NoteId));
            }
            catch (NoteNotFoundException nnf)
            {
                return NotFound(nnf.Message);

            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}