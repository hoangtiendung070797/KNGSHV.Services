using KNGSHV.Application.Interfaces;
using KNGSHV.Application.ViewModels;
using KNGSHV.Application.ViewModels.Login;
using KNGSHV.Application.ViewModels.ReponseApi;
using KNGSHV.Data.EF;
using KNGSHV.Data.Entities;
using KNGSHV.Data.Enums;
using KNGSHV.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KNGSHV.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _accountService;
        private readonly ApplicationSettings _appSettings;
        private readonly UserManager<Account> _userManager;

        public AccountsController(AppDbContext context
            , IAccountService accountService
            , IOptions<ApplicationSettings> appSettings
            , UserManager<Account> userManager)
        {
            _context = context;
            _accountService = accountService;
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        // GET: api/Accounts
        [HttpGet]
        public ActionResult<IEnumerable<AccountViewModel>> GetAccounts()
        {
            return _accountService.GetAccounts();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public ActionResult<AccountViewModel> GetAccount(Guid id)
        {
            return _accountService.GetById(id);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAccount(AccountViewModel accountView)
        {
            _accountService.Update(accountView);
            _accountService.SaveChanges();
            return Ok();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<AccountViewModel> PostAccount(AccountViewModel accountView)
        {
            _accountService.Add(accountView);
            _accountService.SaveChanges();

            return CreatedAtAction("GetAccount", new { id = accountView.Id }, accountView);
        }

        [HttpPost]
        [Route("Register")]
        //POST : api/AppUsers/Register
        public async Task<Object> PostApplicationUser(AccountViewModel model)
        {
            var appnUser = new Account()
            {
                UserName = model.UserName,
                FullName = model.FullName,
                BirthDay = model.BirthDay,
                Avatar = model.Avatar,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified,
                Status = Status.Active,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
            };

            try
            {
                var result = await _userManager.CreateAsync(appnUser, model.PasswordHash);

                //var user = await _userManager.FindByNameAsync(appnUser.UserName);
                //var functions = _context.Functions;
                //foreach (var item in functions)
                //{
                //    Permission permission = new Permission
                //    {
                //        AppUserId = user.Id,
                //        FunctionId = item.Id,
                //        CanCreate = false,
                //        CanUpdate = false,
                //        CanDelete = false,
                //        CanRead = false,
                //        Status = Status.Active
                //    };
                //}

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : api/AppUsers/Login
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var permission = (from p in _context.UserRoles
                                  join f in _context.Functions on p.RoleId equals f.Id
                                  where user.Id == p.UserId
                                  select f.Name
                                 ).ToList();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim("Status",user.Status.ToString()),
                        new Claim("Permissions",string.Join(", ", permission))
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public object DeleteAccount(Guid id)
        {
            try
            {
                _accountService.Delete(id);
                _accountService.SaveChanges();
                return new ResponseApi<string>("Xóa thành công!", Application.ViewModels.ReponseApi.StatusCode.Success);
            }
            catch (Exception)
            {

                return new ResponseApi<string>("Xóa thất bại!", Application.ViewModels.ReponseApi.StatusCode.Error);
            }
          

        }

        private bool AccountExists(Guid id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
