namespace J2S.Server.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using J2S.Server.Models;
    using J2S.Shared;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext? _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
            
        }
       

        [HttpPost]
        public User Create(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return  user;
        }

        [HttpGet("")]
        public List<User> Read()
        {
            return  _userContext.Users.ToList();
        }

        [HttpGet("{userId}")]
        public List<User> ReadById(int userId)
        {
            return  _userContext.Users.Where(w => w.UserId == userId).ToList();
        }

        [HttpPut("{userId}")]
        public  User Update(int userId, User user)
        {
            var u = _userContext.Users.First(f => f.UserId == userId);
            u.Name = user.Name;
            u.Email= user.Email;
            return u;
            //u.Name = user.Name;
        }

        [HttpDelete("{userId}")]
        public void Delete(int userId)
        {
            var u = _userContext.Users.FirstOrDefault(f => f.UserId == userId);
            if(u != null)
            _userContext.Users.Remove(u);
            _userContext.SaveChanges();
        }
    }
}