using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CusJoTask.Models;
using CusJoTask.Dtos;
using AutoMapper;

namespace CusJoTask.Controllers.API
{
    public class RegisterUserController : ApiController
    {
        private UserDBContext _context;

        public RegisterUserController()
        {
            _context = new UserDBContext();
        }

        [HttpPost]
        [AllowAnonymous]
        // POST api/<controller>
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("User not added.");

            var user = Mapper.Map<UserDto, User>(userDto);
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                userDto.UserId = user.UserId;
            }
            catch (Exception e)
            {
                return BadRequest("User not added.");
            }

            return Created(new Uri(Request.RequestUri + "/" + user.UserId), userDto);
        }

    }
}
