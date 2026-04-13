namespace FlowTextDesigner.App.Services;

public interface IIdGenerator
{
    string Next(string prefix);
}
