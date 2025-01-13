using AppointmentSystem.Core.Entities;

namespace AppointmentSystem.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsAlreadyExist(string userEmail);
        Task<bool> IsAlreadyExistSelfExcluded(string userEmail, int Id);
        Task<UserEntity> GetUserByIdAsync(int userId);
        Task<string> CreateUser(UserEntity user);
        Task<IEnumerable<UserEntity>> ListUsers();
        Task<UserEntity> GetUserByEmailAsync(string email);
        Task<string> DeleteUser(UserEntity user);
        Task<string> UpdateUser(UserEntity user);
    }
}
