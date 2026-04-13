using System.Text.Json;
using FlowTextDesigner.App.Models;

namespace FlowTextDesigner.App.Services;

public class JsonDocumentRepository : IDocumentRepository
{
    // Centralizované JSON nastavení pro celý projekt.
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    public async Task SaveAsync(DocumentModel document, string filePath, CancellationToken cancellationToken = default)
    {
        // Vytvoří/overwrite soubor a serializuje celý dokument.
        await using var stream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(stream, document, JsonOptions, cancellationToken);
    }

    public async Task<DocumentModel> LoadAsync(string filePath, CancellationToken cancellationToken = default)
    {
        await using var stream = File.OpenRead(filePath);
        var document = await JsonSerializer.DeserializeAsync<DocumentModel>(stream, JsonOptions, cancellationToken);
        // Fallback: kdyby byl soubor prázdný nebo nevalidní JSON.
        return document ?? new DocumentModel();
    }
}
