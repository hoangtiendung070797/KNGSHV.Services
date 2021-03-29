using KNGSHV.Application.Interfaces;
using KNGSHV.Data.EF;
using KNGSHV.Data.Entities;
using KNGSHV.Data.Enums;
using KNGSHV.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNGSHV.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _accountService;
        private readonly ApplicationSettings _appSettings;
        private readonly UserManager<Account> _userManager;

        public SeedDataController(AppDbContext context
            , IAccountService accountService
            , IOptions<ApplicationSettings> appSettings
            , UserManager<Account> userManager)
        {
            _context = context;
            _accountService = accountService;
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }


        [HttpGet]
        [Route("seed-data")]
        //POST : api/AppUsers/Register
        public async Task<Object> SeedData()
        {
            if (!_context.Accounts.Any())
            {
                var appnUser = new Account()
                {
                    UserName = "admin",
                    FullName = "Admin",
                    BirthDay = DateTime.Now,
                    Avatar = "",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active,
                    Address = "Hai Phong",
                    PhoneNumber = "09635821471",
                };

                var result = await _userManager.CreateAsync(appnUser, "123123aA@");

                if (result.Succeeded)
                {
                    var fuctions = new List<Function>() { 
                    new Function(){ Name = "Main-Layout.Access"},
                    new Function(){ Name = "Account.Access"},
                    new Function(){ Name = "Lecture.Access"},
                    new Function(){ Name = "Learner.Access"},
                    new Function(){ Name = "Subject.Access"},
                    new Function(){ Name = "Blog.Access"},

                    };


                    _context.Functions.AddRange(fuctions);
                    _context.SaveChanges();

                    var currentUser =  await _userManager.FindByNameAsync(appnUser.UserName);

                    foreach (var function in fuctions)
                    {
                        var permission = new IdentityUserRole<Guid>();
                        permission.RoleId = function.Id;
                        permission.UserId = currentUser.Id;

                        _context.UserRoles.Add(permission);
                        _context.SaveChanges();
                    }
                }


                   
              
            }

            return "";
        }
    }
}
