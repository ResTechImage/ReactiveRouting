using System;
using ReactiveUI;
using Splat;

namespace ReactiveRouting.ViewModels
{
     public class FirstViewModel : ReactiveObject, IRoutableViewModel
     {
          public string? UrlPathSegment => "first";

          public IScreen HostScreen { get; }

          public FirstViewModel(IScreen screen = null)
          {
               HostScreen = screen ?? Locator.Current.GetService<IScreen>();
          }
     }
}