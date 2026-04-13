using System;
using System.Globalization;
using Avalonia.Data.Converters;
using FlowTextDesigner.App.Models.Enums;

namespace FlowTextDesigner.App.Converters;

public class NodeTypeToBracketConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value switch
        {
            NodeType.Start => "(Start)",
            NodeType.Process => "[Process]",
            NodeType.Decision => "<Decision>",
            _ => "[Node]"
        };

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
