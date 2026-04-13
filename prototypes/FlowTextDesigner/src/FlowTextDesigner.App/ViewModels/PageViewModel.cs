namespace FlowTextDesigner.App.ViewModels;

public class PageViewModel : ViewModelBase
{
    public string Id { get; }
    public string Name { get; }

    public PageViewModel(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
