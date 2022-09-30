using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveRouting.Views;
using ReactiveUI;
using Splat;

namespace ReactiveRouting.ViewModels
{
     public class MainViewModel : ReactiveObject, IScreen
     {
          // The Router associated with this Screen.
          // Required by the IScreen interface.
          public RoutingState Router { get; }

          // The command that navigates a user to first view model.
          public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

          // The command that navigates a user back.
          public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }

          public MainViewModel()
          {
               // Initialize the Router.
               Router = new RoutingState();
               Locator.CurrentMutable.Register(() => new FirstView(), typeof(IViewFor<FirstViewModel>));
               GoNext = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new FirstViewModel()));
               var canGoBack = this.WhenAnyValue(x => x.Router.NavigationStack.Count).Select(count => count > 0);
               GoBack = ReactiveCommand.CreateFromObservable(() => Router.NavigateBack.Execute(Unit.Default), canGoBack);
          }
     }
}