using AppointmentSystem.Core.Bases;
using AppointmentSystem.Core.Entities;
using AppointmentSystem.Core.Interfaces;
using AppointmentSystem.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.infrastructure.Repositories
{
    public class UserReporsitory : IUserRepository
    {
        private readonly AppDbContext context;
        public UserReporsitory(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> IsAlreadyExist(string userEmail)
        {
            return await context.users.AsNoTracking().AnyAsync(d => d.UserEmail.Equals(userEmail));
        }
        public async Task<bool> IsAlreadyExistSelfExcluded(string userEmail, int userId)
        {
            return await context.users.AsNoTracking().AnyAsync(d => d.UserEmail.Equals(userEmail) && !d.Id.Equals(userId));
        }
        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return await context.users.AsNoTracking().FirstOrDefaultAsync(d => d.Id == userId);
        }
        public async Task<string> CreateUser(UserEntity user)
        {
            try
            {
                context.users.Add(user);
                await context.SaveChangesAsync();
                return (ResponseMessages.Success);
            }
            catch (Exception ex)
            {
                return (ResponseMessages.Exception);
            }
        }
        public async Task<IEnumerable<UserEntity>> ListUsers()
        {
            var users = await context.users.ToListAsync();
            return users;
        }
        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            var User = await context.users.FirstOrDefaultAsync(d => d.UserEmail.Equals(email));
            return User;
        }
        public async Task<string> DeleteUser(UserEntity user)
        {
            try
            {

                context.users.Remove(user);
                await context.SaveChangesAsync();
                return ResponseMessages.Success;

            }
            catch (Exception ex)
            {
                return $"{ResponseMessages.Exception} {ex}";
            }
        }
        public async Task<string> UpdateUser(UserEntity userEntity)
        {
            try
            {
                context.users.Update(userEntity);
                await context.SaveChangesAsync();
                return (ResponseMessages.Success);
            }
            catch (Exception ex)
            {
                return (ResponseMessages.Exception + ex);
            }

        }
        public async Task<bool> IsNameExistExcludeSelf(string email, int id)
        {
            var Res = await context.users.Where(x => x.UserEmail.Equals(email) & !x.Id.Equals(id)).FirstOrDefaultAsync();
            if (Res == null) return false;
            return true;
        }
    }
}
