using FlowTextDesigner.App.Models;

namespace FlowTextDesigner.Tests;

public class ModelTests
{
    [Fact]
    public void Document_CanContainPage()
    {
        var page = new PageModel { Id = "page-1", Name = "Page1" };
        var document = new DocumentModel { Pages = [page], ActivePageId = page.Id };

        Assert.Single(document.Pages);
        Assert.Equal("page-1", document.ActivePageId);
    }
}
