namespace FlowTextDesigner.App.ViewModels;

public class PropertyGridViewModel : ViewModelBase
{
    public string SelectedId { get; set; } = "N-001";
    public string SelectedType { get; set; } = "Start";
    public string SelectedText { get; set; } = "(Start)";
    public double SelectedX { get; set; }
    public double SelectedY { get; set; }
}
