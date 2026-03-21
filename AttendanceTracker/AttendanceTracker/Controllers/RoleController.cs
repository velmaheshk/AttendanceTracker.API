using AttendanceTracker.Application.DTOs;
using AttendanceTracker.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            IList<RoleDto> roles;
            try
            {
                roles = await roleService.GetAllRoles();
                if (roles == null || roles.Count == 0)
                {
                    return NotFound("No roles found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            RoleDto role;
            try
            {
                role = await roleService.GetRoleById(id);
                if (role == null)
                {
                    return NotFound($"No role found with id: {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDto roleDto)
        {
            int id;
            try
            {
                id = await roleService.AddRole(roleDto);
                if (id == 0)
                {
                    return BadRequest("Failed to add role.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return CreatedAtAction(nameof(GetRoleById), new { id = id }, null);
        }

    }
}
