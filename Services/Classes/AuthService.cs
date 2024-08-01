using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Password_Crypth_Implementations;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Classes
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordEncoder _passwordEncoder;
        private readonly DataContext _db;

        public AuthService(IPasswordEncoder passwordEncoder, DataContext db)
        {
            _passwordEncoder = passwordEncoder;
            _db = db;
        }

        public async Task<User> AddRoleToUser(int userId, string roleName)
        {
            var user = await _db.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.Id == userId);
            var role = await _db.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
            if(!user.Roles.Contains(role))
            {
                user.Roles.Add(role);
            }
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> Create(UserViewModel entity)
        {
            var defaultRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "User");
            var user = new User
            {
                Name = entity.Name,
                Email = entity.Email,
                Password = _passwordEncoder.Encode(entity.Password),
            };
            user.Roles.Add(defaultRole);
            
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(int id)
        {
           var user = await GetById(id);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _db.Users
                    .Include(x => x.Roles)
                    .ToListAsync();
            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _db.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(x => x.Id == id);
            return user!;
        }

        public async Task<User> Login(UserViewModel entity)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == entity.Email);    
            if (user != null && _passwordEncoder.IsSame(entity.Password, user.Password))
            {

                return new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Roles = await _db.Roles
                            .Include(r => r.Users)
                            .Where(user => user.Name == entity.Name)
                            .ToListAsync()
                };
            }
            return null!;
        }

        public async Task<User> RemoveRoleToUser(int userId, string roleName)
        {
            var user = await _db.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.Id == userId);
            var role = await _db.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
            if (user.Roles.Contains(role))
            {
                user.Roles.Remove(role);
            }
            await _db.SaveChangesAsync();
            return user;
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
