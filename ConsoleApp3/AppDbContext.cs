using ConsoleApp3;

namespace ConsoleAppLesson.Datas
{
    public class GenericAppDbContext<T> where T : BaseEntity
    {
        public T[] Items = [];
    }
}