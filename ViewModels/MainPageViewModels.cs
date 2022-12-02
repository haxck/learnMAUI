using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels;

public class MainPageViewModels : ObservableObject
{
    private IPoetryStorage _poetryStorage;

    public MainPageViewModels(IPoetryStorage poetryStorage)
    {
        _poetryStorage = poetryStorage;
    }
/* ？？？ */
    public ObservableCollection<Poetry> Poetries { get; } = new ObservableCollection<Poetry>();

    private RelayCommand _initializeCommand;
    public RelayCommand InitializeCommand =>
        _initializeCommand ??= new RelayCommand(async () =>
        {
            await _poetryStorage.InitializeAsync();
        });

    private RelayCommand _addCommand;
    public RelayCommand AddCommand => _addCommand ??= new RelayCommand(async () =>
    {

        await _poetryStorage.AddAsync(new Poetry
        {
            Title = "Title",
            Content = "Content"
        });
    });

    private RelayCommand _listCommand;
    public RelayCommand ListCommand => _listCommand ??= new RelayCommand(async () =>
    {
        var list = await _poetryStorage.ListAsync();
        foreach (var item in list)
        {
            Poetries.Add(item); //不懂
        }
    });
}
