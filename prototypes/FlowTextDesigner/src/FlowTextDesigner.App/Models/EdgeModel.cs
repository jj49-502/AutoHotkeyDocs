namespace FlowTextDesigner.App.Models;

public class EdgeModel
{
    public string Id { get; init; } = string.Empty;
    public string FromNodeId { get; init; } = string.Empty;
    public string ToNodeId { get; init; } = string.Empty;
    public string Label { get; set; } = string.Empty;
}
