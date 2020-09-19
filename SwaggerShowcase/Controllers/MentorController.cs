using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerShowcase.Database;
using SwaggerShowcase.Models;

namespace SwaggerShowcase.Controllers
{
    /// <summary>
    /// The main api controller class.
    /// Contains all action methods that are mapped to specific endpoints
    /// </summary>
    /// <remarks>
    /// This class provides fetch and add functions.
    /// </remarks>
    [ApiController]
    [Route("api/")]
    public class MentorController : Controller
    {   
        public static DummyDatabase DummyDB = new DummyDatabase();
        
        /// <summary>
        /// Gets all mentors 
        /// </summary>
        // GET: Mentor
        [HttpGet("mentors")]
        public ActionResult Index()
        {
            var mentors = DummyDB.GetAll();
            return Ok(mentors);
        }

        /// <summary>
        /// Gets single mentor by its id 
        /// </summary>
        // GET: Mentor/Details/5
        [HttpGet("mentors/{id}")]
        public ActionResult Details(int id)
        {
            var targetMentor = DummyDB.GetSingleByID(id);
            return Ok(targetMentor);
        }

        /// <summary>
        /// Creates new mentor
        /// </summary>
        [HttpPost("mentor")]
        public ActionResult Create(Mentor mentor)
        {   
            var newMentor = new Mentor()
            {   
                Id = mentor.Id,
                Name = mentor.Name,
                Surname = mentor.Surname,
                Age = mentor.Age,
                Specialization = mentor.Specialization
            };
            DummyDB.AddMentor(newMentor);
            return Created("get", mentor);
        }

    }
}