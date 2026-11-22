using ConsoleApp3;

namespace ConsoleAppLesson.Services
{
    public interface IGenericService<T> where T : BaseEntity
    {
        void Add(T item);
        T[] GetAll();
        T? GetById(int id);
        void Delete(int id);
    }
}