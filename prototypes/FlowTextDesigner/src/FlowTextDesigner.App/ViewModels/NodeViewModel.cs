using FlowTextDesigner.App.Models.Enums;

namespace FlowTextDesigner.App.ViewModels;

public class NodeViewModel : ViewModelBase
{
    public string Id { get; init; } = string.Empty;
    public NodeType Type { get; init; }
    public string Text { get; set; } = string.Empty;
    public double X { get; set; }
    public double Y { get; set; }
}
