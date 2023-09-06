namespace ToDoListApi.Data
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool Done { get; set; }

    }
}
