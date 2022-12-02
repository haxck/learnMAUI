using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Services;

namespace MauiApp1.ViewModels;

public class MainPageViewModels : ObservableObject
{
    private string _result = string.Empty;

    public string Result
    {
        get => _result;
        set => SetProperty(ref _result, value);
    }

    private IKeyValueStorage _keyValueStorage;
    public MainPageViewModels(IKeyValueStorage KeyValueStorage){
        _keyValueStorage = KeyValueStorage;
    }


    private RelayCommand _readCommand;
    public RelayCommand ReadCommand => _readCommand ??= new RelayCommand(() => Result = _keyValueStorage.Get("Mykey", string.Empty));


    private RelayCommand _writeCommand;
    public RelayCommand WriteCommand => _writeCommand ?? new RelayCommand(() => _keyValueStorage.Set("Mykey",Result));



    private RelayCommand _clickMeCommand;
    public RelayCommand ClickMeCommand => _clickMeCommand ??= new RelayCommand(() => Result = "hello world");

}
