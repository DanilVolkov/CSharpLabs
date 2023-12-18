public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string title, string description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
    }
}

public class TaskManager
{
    public delegate void TaskStatusChangedEventHandler(Task task);

    public event TaskStatusChangedEventHandler TaskStatusChanged;

    public void CompleteTask(Task task)
    {
        task.IsCompleted = true;

        StatusChanged(task);
    }

    public virtual void StatusChanged(Task task)
    {
        TaskStatusChanged?.Invoke(task);
    }
}

public class TaskSubscriber
{
    public static void TaskCompletedNotification(Task task) => Console.WriteLine($"Задача \"{task.Title}\" выполнена");
}

class Task1
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        taskManager.TaskStatusChanged += TaskSubscriber.TaskCompletedNotification;

        Task task1 = new Task("Позавтракать", "Скушать яичницу");
        Task task2 = new Task("Программировать", "Выполнить необходимые задачи на сегодня");
        Task task3 = new Task("Поужинать", "Заказать пиццу");

        taskManager.CompleteTask(task1);
    }
}
