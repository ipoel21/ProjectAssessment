namespace ConsoleApp2.Repositories
{
    internal interface IBaseRepository<T>
    {
        IEnumerable<T> Values { get; set; }

        void Add(T Data);
        void Delete(T Entity);
        void Update(T Data);
    }
}