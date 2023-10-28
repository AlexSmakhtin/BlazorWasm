namespace BlazorWasm
{
    public interface ICatalog: IEnumerable<Item>
    {
        void Add(Item item);
        void Clear();
        void DeleteById(Guid id);
        Item GetById(Guid id);
        List<Item> ToList();
        void Update(Guid id, Item item);
    }
}