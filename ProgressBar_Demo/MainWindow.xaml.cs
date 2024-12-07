using System.Windows;

namespace ProgressBar_Demo;

public partial class MainWindow : Window
{
    private readonly ProgressDemo _progressDemo;
    private CancellationTokenSource _cancellationTokenSource;
    private int? _count;
    
    public MainWindow()
    {
        _progressDemo = new ProgressDemo();
        
        InitializeComponent();
    }

    /*private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        await _progressDemo.RunAsync(i =>
        {
            Progress.Value = i;
            ProgressText.Text = i.ToString();
        });
    }*/
    
    private async void ButtonStart_OnClick(object sender, RoutedEventArgs e)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        
        var progress = new Progress<int>();
        progress.ProgressChanged += (_, i) =>
        {
            Progress.Value = i;
            ProgressText.Text = i.ToString();
        };

        var beginValue = _count ?? int.Parse(InputBeginValue.Text);
        var endValue = int.Parse(InputEndValue.Text);
        await _progressDemo.RunAsync(beginValue, endValue, _cancellationTokenSource.Token, progress);
    }

    private void ButtonStop_OnClick(object sender, RoutedEventArgs e)
    {
        _count = (int)Progress.Value;
        _cancellationTokenSource.Cancel();
    }
}