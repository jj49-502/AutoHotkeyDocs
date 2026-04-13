using FlowTextDesigner.App.Models;
using FlowTextDesigner.App.Services;

namespace FlowTextDesigner.Tests;

public class JsonRepositoryTests
{
    [Fact]
    public async Task SaveAndLoad_RoundTrip_Works()
    {
        var repository = new JsonDocumentRepository();
        var path = Path.GetTempFileName();

        try
        {
            var source = new DocumentModel
            {
                ActivePageId = "page-1",
                Pages =
                [
                    new PageModel
                    {
                        Id = "page-1",
                        Name = "Page1"
                    }
                ]
            };

            await repository.SaveAsync(source, path);
            var loaded = await repository.LoadAsync(path);

            Assert.Equal("page-1", loaded.ActivePageId);
            Assert.Single(loaded.Pages);
        }
        finally
        {
            File.Delete(path);
        }
    }
}
