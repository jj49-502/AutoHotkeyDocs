using FlowTextDesigner.App.Models.Enums;

namespace FlowTextDesigner.App.Models;

public class NodeModel
{
    // Jednoznačný identifikátor uzlu v rámci stránky (např. N-001).
    public string Id { get; init; } = string.Empty;
    // Typ uzlu určuje textový "shape" (Start/Process/Decision).
    public NodeType Type { get; set; }
    // Text viditelný na plátně, např. "(Start)" nebo "[Kontrola]".
    public string Text { get; set; } = string.Empty;
    // Pozice uzlu na plátně.
    public double X { get; set; }
    public double Y { get; set; }
    // Volitelné klíč-hodnota vlastnosti (pro budoucí rozšíření).
    public Dictionary<string, string> Properties { get; init; } = [];
}
