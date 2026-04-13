namespace FlowTextDesigner.App.Models;

public class PageModel
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<NodeModel> Nodes { get; init; } = [];
    public List<EdgeModel> Edges { get; init; } = [];
}
