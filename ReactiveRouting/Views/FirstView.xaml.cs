using System.Reactive.Disposables;
using ReactiveUI;

namespace ReactiveRouting.Views
{
     /// <summary>
     /// Interaction logic for FirstView.xaml
     /// </summary>
     public partial class FirstView
     {
          public FirstView()
          {
               InitializeComponent();
               this.WhenActivated(disposables =>
               {
                    this.OneWayBind(ViewModel, x => x.UrlPathSegment, x => x.PathTextBlock.Text).DisposeWith(disposables);
               });
          }
     }
}