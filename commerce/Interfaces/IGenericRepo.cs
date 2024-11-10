using commerce.DTOs;

namespace commerce.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();

        public Task<T> Add(T Tmodel);
    }
}
