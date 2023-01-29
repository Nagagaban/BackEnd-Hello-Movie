using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using System.Security.Cryptography;
using System.Text;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MovieDbContext _movieDbContext;

        public UserController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        //private string HashPassword(string password)
        //{
        //    byte[] salt;
        //    new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        //    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        //    byte[] hash = pbkdf2.GetBytes(20);
        //    byte[] hashBytes = new byte[36];
        //    Array.Copy(salt, 0, hashBytes, 0, 16);
        //    Array.Copy(hash, 0, hashBytes, 16, 20);
        //    return Convert.ToBase64String(hashBytes);
        //}

        [HttpGet]
        [Route("GetUser")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _movieDbContext.Users.ToListAsync();
        }

        //[HttpPost]
        //[Route("LoginUser")]
        //public async Task<IActionResult> Login(User objUser)
        //{
        //    // Check if the user exists in the database
        //    var currentUser = await _movieDbContext.Users.SingleOrDefaultAsync(u => u.UserName == objUser.UserName);
        //    if (currentUser != null)
        //    {
        //        // Verify the user's password
        //        var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, currentUser.Salt, 10000);
        //        byte[] hash = pbkdf2.GetBytes(20);
        //        if (Convert.ToBase64String(hash) == currentUser.UserPassword)
        //        {
        //            return Ok(new { message = "Login successful" });
        //        }
        //        else
        //        {
        //            return BadRequest(new { message = "Incorrect password" });
        //        }
        //    }
        //    else
        //    {
        //        return NotFound(new { message = "User not found" });
        //    }
        //}

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> Login(User objUser)
        {
            // Check if the user exists in the database
            var currentUser = await _movieDbContext.Users.SingleOrDefaultAsync(u => u.UserName == objUser.UserName);
            if (currentUser != null)
            {
                // Verify the user's password
                if (objUser.UserPassword == currentUser.UserPassword)
                {
                    if (currentUser.UserType == "Administrator")
                    {
                        return Ok(new { message = "Login successful as Administrator" });
                    }
                    else if (currentUser.UserType == "Normal User")
                    {
                        return Ok(new { message = "Login successful as Normal User" });
                    }
                    else
                    {
                        return Ok(new { message = "I dont know what are you" });
                    }
                }
                else
                {
                    return BadRequest(new { message = "Incorrect password" });
                }
            }
            else
            {
                return NotFound(new { message = "User not found" });
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<User> AddUser(User objUser)
        {
            _movieDbContext.Users.Add(objUser);
            await _movieDbContext.SaveChangesAsync();
            return objUser;
        }

        //[HttpPost]
        //[Route("AddUser")]
        //public async Task<User> AddUser(User objUser)
        //{
        //    // Generate a new salt
        //    objUser.Salt = new byte[16];
        //    new RNGCryptoServiceProvider().GetBytes(objUser.Salt);

        //    // Hash the password
        //    var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, objUser.Salt, 10000);
        //    byte[] hash = pbkdf2.GetBytes(20);
        //    objUser.UserPassword = Convert.ToBase64String(hash);

        //    _movieDbContext.Users.Add(objUser);
        //    await _movieDbContext.SaveChangesAsync();
        //    return objUser;
        //}

        //[HttpPost]
        //[Route("AddUser")]
        //public async Task<User> AddUser(User objUser)
        //{
        //    if (objUser.Salt != null && objUser.Salt.Length > 0)
        //    {
        //        // Hash the password using the provided salt
        //        var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, objUser.Salt, 10000);
        //        byte[] hash = pbkdf2.GetBytes(20);
        //        objUser.UserPassword = Convert.ToBase64String(hash);
        //    }
        //    else
        //    {
        //        // Generate a new salt
        //        objUser.Salt = new byte[16];
        //        new RNGCryptoServiceProvider().GetBytes(objUser.Salt);

        //        // Hash the password using the new salt
        //        var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, objUser.Salt, 10000);
        //        byte[] hash = pbkdf2.GetBytes(20);
        //        objUser.UserPassword = Convert.ToBase64String(hash);
        //    }

        //    _movieDbContext.Users.Add(objUser);
        //    await _movieDbContext.SaveChangesAsync();
        //    return objUser;
        //}

        //[HttpPost]
        //[Route("AddUser")]
        //public async Task<User> AddUser(User objUser)
        //{
        //    // Generate a new salt
        //    byte[] salt = new byte[16];
        //    new RNGCryptoServiceProvider().GetBytes(salt);

        //    // Hash the password
        //    var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, salt, 10000);
        //    byte[] hash = pbkdf2.GetBytes(20);
        //    objUser.UserPassword = Convert.ToBase64String(hash);

        //    // Save the salt in the user object
        //    objUser.Salt = salt;

        //    _movieDbContext.Users.Add(objUser);
        //    await _movieDbContext.SaveChangesAsync();
        //    return objUser;
        //}

        [HttpPatch]
        [Route("UpdateUser/{id}")]
        public async Task<User> UpdateUser(User objUser)
        {
            _movieDbContext.Users.Update(objUser);
            await _movieDbContext.SaveChangesAsync();
            return objUser;
        }

        //[HttpPatch]
        //[Route("UpdateUser/{id}")]
        //public async Task<IActionResult> UpdateUser(int id, User objUser)
        //{
        //    var currentUser = await _movieDbContext.Users.FindAsync(id);
        //    if (currentUser != null)
        //    {
        //        // Generate a new salt
        //        currentUser.Salt = new byte[16];
        //        new RNGCryptoServiceProvider().GetBytes(currentUser.Salt);

        //        // Hash the password
        //        var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, currentUser.Salt, 10000);
        //        byte[] hash = pbkdf2.GetBytes(20);
        //        currentUser.UserPassword = Convert.ToBase64String(hash);

        //        //update other properties
        //        currentUser.UserName = objUser.UserName;
        //        currentUser.UserType = objUser.UserType;

        //        _movieDbContext.Users.Update(currentUser);
        //        _movieDbContext.SaveChangesAsync();
        //        return Ok(currentUser);
        //    }
        //    else
        //    {
        //        return NotFound(new { message = "User not found" });
        //    }
        //}

        //[HttpPatch]
        //[Route("UpdateUser/{id}")]
        //public async Task<IActionResult> UpdateUser(int id, User objUser)
        //{
        //    var currentUser = await _movieDbContext.Users.FindAsync(id);
        //    if (currentUser != null)
        //    {
        //        if (objUser.Salt != null && objUser.Salt.Length > 0)
        //        {
        //            // Hash the password using the provided salt
        //            var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, objUser.Salt, 10000);
        //            byte[] hash = pbkdf2.GetBytes(20);
        //            currentUser.UserPassword = Convert.ToBase64String(hash);
        //        }
        //        else
        //        {
        //            // Generate a new salt
        //            currentUser.Salt = new byte[16];
        //            new RNGCryptoServiceProvider().GetBytes(currentUser.Salt);

        //            // Hash the password using the new salt
        //            var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, currentUser.Salt, 10000);
        //            byte[] hash = pbkdf2.GetBytes(20);
        //            currentUser.UserPassword = Convert.ToBase64String(hash);
        //        }

        //        //update other properties
        //        currentUser.UserName = objUser.UserName;
        //        currentUser.UserType = objUser.UserType;

        //        _movieDbContext.Users.Update(currentUser);
        //        _movieDbContext.SaveChangesAsync();
        //        return Ok(currentUser);
        //    }
        //    else
        //    {
        //        return NotFound(new { message = "User not found" });
        //    }
        //}

        //[HttpPatch]
        //[Route("UpdateUser/{id}")]
        //public async Task<IActionResult> UpdateUser(int id, User objUser)
        //{
        //    var currentUser = await _movieDbContext.Users.FindAsync(id);
        //    if (currentUser != null)
        //    {
        //        // Generate a new salt
        //        byte[] salt = new byte[16];
        //        new RNGCryptoServiceProvider().GetBytes(salt);

        //        // Hash the password
        //        var pbkdf2 = new Rfc2898DeriveBytes(objUser.UserPassword, salt, 10000);
        //        byte[] hash = pbkdf2.GetBytes(20);
        //        currentUser.UserPassword = Convert.ToBase64String(hash);

        //        // Save the salt in the user object
        //        currentUser.Salt = salt;

        //        //update other properties
        //        currentUser.UserName = objUser.UserName;
        //        currentUser.UserType = objUser.UserType;

        //        _movieDbContext.Users.Update(currentUser);
        //        _movieDbContext.SaveChangesAsync();
        //        return Ok(currentUser);
        //    }
        //    else
        //    {
        //        return NotFound(new { message = "User not found" });
        //    }
        //}

        //[HttpDelete]
        //[Route("DeleteUser/{id}")]
        //public bool DeleteUser(int id)
        //{
        //    bool a = false;
        //    var user = _movieDbContext.Users.Find(id);
        //    if(user != null)
        //    {
        //        a = true;
        //        _movieDbContext.Entry(user).State = EntityState.Deleted;
        //        _movieDbContext.SaveChanges();
        //    }
        //    else
        //    {
        //        a = false;
        //    }
        //    return a;
        //}

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _movieDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _movieDbContext.Users.Remove(user);
            await _movieDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
