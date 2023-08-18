using ToDoApp_API.Models;

namespace ToDoApp_API.Seeds
{
    public class TodoSeed
    {
        public static void AddTodosDummy(AppDbContext context)
        {
            if (context.Todos!.Any()) return;
            context.Todos!.Add(new() { Content = "Yapılacak iş 1", Created = DateTime.Now, IsCompleted = false });
            context.Todos!.Add(new() { Content = "yapılacak iş 2", Created = DateTime.Now, IsCompleted = false });
            context.SaveChanges();
        }
    }
}
