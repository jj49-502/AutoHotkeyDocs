using System.Collections.ObjectModel;
using FlowTextDesigner.App.Commands;

namespace FlowTextDesigner.App.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    // Interní čítač pro generování názvů nových stránek (Page2, Page3, ...).
    private int _nextPage = 2;

    // Seznam stránek zobrazených v dolní liště.
    public ObservableCollection<PageViewModel> Pages { get; } =
    [
        new PageViewModel("page-1", "Page1")
    ];

    // Data napojená na pravý panel vlastností.
    public PropertyGridViewModel Properties { get; } = new();

    // Základní příkazy pro toolbar (zatím MVP kostra).
    public RelayCommand AddStartNodeCommand { get; }
    public RelayCommand AddProcessNodeCommand { get; }
    public RelayCommand AddDecisionNodeCommand { get; }
    public RelayCommand ConnectSelectedCommand { get; }
    public RelayCommand SaveCommand { get; }
    public RelayCommand LoadCommand { get; }
    public RelayCommand AddPageCommand { get; }
    public RelayCommandT<string> SelectPageCommand { get; }

    public MainWindowViewModel()
    {
        // Jen demonstračně měníme text vybraného uzlu, dokud nebude hotový canvas editor.
        AddStartNodeCommand = new RelayCommand(() => Properties.SelectedText = "(Start)");
        AddProcessNodeCommand = new RelayCommand(() => Properties.SelectedText = "[Process]");
        AddDecisionNodeCommand = new RelayCommand(() => Properties.SelectedText = "<Decision>");
        ConnectSelectedCommand = new RelayCommand(() => { });
        SaveCommand = new RelayCommand(() => { });
        LoadCommand = new RelayCommand(() => { });
        AddPageCommand = new RelayCommand(AddPage);
        SelectPageCommand = new RelayCommandT<string>(SelectPage);
    }

    private void AddPage()
    {
        Pages.Add(new PageViewModel($"page-{_nextPage}", $"Page{_nextPage}"));
        _nextPage++;
    }

    private void SelectPage(string? pageId)
    {
        // Guard clause proti null/empty hodnotám z UI.
        if (string.IsNullOrWhiteSpace(pageId))
        {
            return;
        }

        // MVP: vybranou stránku promítáme do panelu vlastností jako "Selected ID".
        Properties.SelectedId = pageId;
        RaisePropertyChanged(nameof(Properties));
    }
}
