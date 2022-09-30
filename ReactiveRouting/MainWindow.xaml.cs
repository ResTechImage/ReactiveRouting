using System.Reactive.Disposables;
using ReactiveRouting.ViewModels;
using ReactiveUI;

namespace ReactiveRouting
{
     /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
     public partial class MainWindow
     {
          public MainWindow()
          {
               InitializeComponent();
               var ViewModel = new MainViewModel();
               this.WhenActivated(disposables =>
               {
                    // Bind the view model router to RoutedViewHost.Router property.
                    this.OneWayBind(ViewModel,
                         x => x.Router,
                         x => x.RoutedViewHost.Router).DisposeWith(disposables);
                    this.BindCommand(ViewModel,
                         x => x.GoNext,
                         x => x.GoNextButton).DisposeWith(disposables);
                    this.BindCommand(ViewModel,
                         x => x.GoBack,
                         x => x.GoBackButton).DisposeWith(disposables);
               });
          }
     }
}