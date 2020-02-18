using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Auth.Server.Data;

namespace Rs.App.Core.Auth.Server.Controllers
{
    [Authorize]
    public class UserAdminController : Controller
    {
        private readonly AuthIdentityDbContext _dbContext;

        public UserAdminController(AuthIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IQueryable<ApplicationUser> users = GetUser();

            return View(users);
        }

        public async Task<IActionResult> Approve([FromQuery]string userName)
        {
            var user = _dbContext.Users.Where(x => x.UserName == userName).FirstOrDefault();

            //let it me if(user == null) { 
            user.Status = EnumUserStatus.Approved;
            _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private IQueryable<ApplicationUser> GetUser()
        {
            return _dbContext.Users
                .AsQueryable<ApplicationUser>()
                .Where(x => x.Status == EnumUserStatus.Submitted);
        }
    }
}