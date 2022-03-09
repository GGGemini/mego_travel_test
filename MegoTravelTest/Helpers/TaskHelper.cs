namespace MegoTravelTest.Helpers;

public static class TaskHelper
{
    /// <summary>
    /// Запуск задачи и получение результата через время. Если время истекает, возвращает null
    /// </summary>
    /// <param name="task"></param>
    /// <param name="time"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> GetResultByTimeout<T>(Task<T> task, int time) where T : class
    {
        task.Start();
        
        var cancellationTokenSource = new CancellationTokenSource();

        var completedTask = await Task.WhenAny(task, Task.Delay(time, cancellationTokenSource.Token));
        if (completedTask == task)
        {
            cancellationTokenSource.Cancel();
            return task.Result;
        }
        else
        {
            return null;
        }
    }
}