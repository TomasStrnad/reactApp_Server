using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Dtos;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{

    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public TaskController(
            ITaskService taskService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _taskService = taskService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetAll();
            var taskDtos = _mapper.Map<IList<TaskDto>>(tasks);
            return Ok(taskDtos);
        }

[AllowAnonymous]
        [HttpPost("UpdateTask")]
        public IActionResult UpdateTask([FromBody]TaskDto taskDtos)
        {
            // map dto to entity
            var task = _mapper.Map<Task>(taskDtos);

            try
            {
                // save 
                _taskService.UpdateTask(task);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("CreateTask")]
        public IActionResult CreateTask([FromBody]TaskDto taskDtos)
        {
            // map dto to entity
            var task = _mapper.Map<Task>(taskDtos);

            try
            {
                // save 
                _taskService.Create(task);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return Ok();
        }

    }
}
