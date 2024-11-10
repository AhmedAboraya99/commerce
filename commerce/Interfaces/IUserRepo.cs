using commerce.DTOs;

namespace commerce.Interfaces
{
    public interface IUserRepo
    {
        public Task<UserDTO> GetUserById(int id);
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> GetUserByName(string name);
        public Task<UserDTO> UpdateUser(UserDTO userDTO);
        public Task<UserDTO> AddUser(UserDTO userDTO);
    }
}
