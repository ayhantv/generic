using ConsoleApp3;
using ConsoleAppLesson.Datas;

namespace ConsoleAppLesson.Services
{
    public class GenericService<T> : IGenericService<T>
        where T : BaseEntity
    {
        private readonly GenericAppDbContext<T> _context;

        public GenericService(GenericAppDbContext<T> context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            item.Id = _context.Items.Length > 0
                ? _context.Items.Max(x => x.Id) + 1 : 1;

            Array.Resize(ref _context.Items, _context.Items.Length + 1);

            _context.Items[_context.Items.Length - 1] = item;
        }

        public T[] GetAll()
        {
            return _context.Items;
        }

        public T? GetById(int id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }
        public void Delete(int id)
        {
            var result = GetById(id);

            if (result == null)
            {
                Console.WriteLine("Kitab tapilmadi");
                return;
            }

            _context.Items = _context.Items .Where(x => x.Id != id).ToArray();

            Console.WriteLine("Kitab silindi");
        }


    }
    }
