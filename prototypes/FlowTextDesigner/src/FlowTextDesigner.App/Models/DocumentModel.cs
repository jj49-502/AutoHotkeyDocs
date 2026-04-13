namespace FlowTextDesigner.App.Models;

public class DocumentModel
{
    public List<PageModel> Pages { get; init; } = [];
    public string? ActivePageId { get; set; }
}
