using System.Collections;
using System.Collections.Concurrent;
using static MudBlazor.CategoryTypes;

namespace BlazorWasm
{
    public class Catalog : ICatalog, IEnumerable<Item>
    {
        private readonly List<Item> _items = new();
        private readonly object _lock = new();

        public void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            lock (_lock)
            {
                _items.Add(item);
            }
        }
        public void Clear()
        {
            lock (_lock)
            {
                _items.Clear();
            }
        }
        public void DeleteById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var item = _items.FirstOrDefault(e => e.Id == id);
            if (item == null)
                throw new NullReferenceException(nameof(item));
            lock (_lock)
            {
                _items.Remove(item);
            }
        }
        public Item GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var item = _items.FirstOrDefault(e => e.Id == id);
            if (item == null)
                throw new NullReferenceException(nameof(item));
            return item;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((IEnumerable<Item>)_items).GetEnumerator();
        }

        public List<Item> ToList()
        {
            return _items;
        }
        public void Update(Guid id, Item item)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            var itemToUpdate = _items.FirstOrDefault(e => e.Id == id);
            if (itemToUpdate == null)
                throw new NullReferenceException(nameof(itemToUpdate));
            lock (_lock)
            {
                itemToUpdate.Id = item.Id;
                itemToUpdate.Description = item.Description;
                itemToUpdate.Cost = item.Cost;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }
    }
}
