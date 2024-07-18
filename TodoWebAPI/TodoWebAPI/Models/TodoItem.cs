namespace TodoWebAPI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        //DATO OCULTO
        public sbyte? Secred { get; set; }

    }
}
