using ServicioPruebaTecnica.Repository;

namespace ServicioPruebaTecnica.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await userRepository.GetUserByIdAsync(id);
        }

        public async Task<int> AddUserAsync(User user)
        {
            return await userRepository.AddUserAsync(user);
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            return await userRepository.UpdateUserAsync(user);
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await userRepository.DeleteUserAsync(id);
        }
    }

}
