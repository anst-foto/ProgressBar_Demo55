namespace ProgressBar_Demo;

public class ProgressDemo
{
    /*public async Task RunAsync(Action<int> progress)
    {
        for (int i = 0; i <= 100; i++)
        {
            progress(i);
            await Task.Delay(100);
        }
    }*/
    
    public async Task RunAsync(int beginValue, int endValue, CancellationToken? cancellationToken = null, IProgress<int>? progress = null)
    {
        for (int i = beginValue; i <= endValue; i++)
        {
            if (cancellationToken is { IsCancellationRequested: true })
            {
                return;
            }
            
            progress?.Report(i);
            await Task.Delay(100);
        }
    }
}