using FlowTextDesigner.App.Models;

namespace FlowTextDesigner.App.Services;

public interface IDocumentRepository
{
    Task SaveAsync(DocumentModel document, string filePath, CancellationToken cancellationToken = default);
    Task<DocumentModel> LoadAsync(string filePath, CancellationToken cancellationToken = default);
}
