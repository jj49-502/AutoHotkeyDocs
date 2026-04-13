namespace FlowTextDesigner.App.Services;

public class SequentialIdGenerator : IIdGenerator
{
    private int _counter = 1;

    public string Next(string prefix)
    {
        var value = _counter;
        _counter++;
        return $"{prefix}-{value:D3}";
    }
}
