namespace BlazorWasm
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal _cost;
        public decimal Cost
        {
            get { return Math.Round(_cost, 2); }
            set { _cost = value; }
        }

        public Item(Guid id, string name, string description, decimal cost)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));
            if (cost < 0)
                throw new ArgumentOutOfRangeException(nameof(cost));
            Id = id;
            Name = name;
            Description = description;
            _cost = cost;
        }
    }
}
