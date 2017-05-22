﻿using System.Windows;
using System.Windows.Controls;
using Popcorn.ViewModels.Pages.Home.Show.Tabs;

namespace Popcorn.UserControls.Home.Show.Tabs
{
    /// <summary>
    /// Logique d'interaction pour ShowTab.xaml
    /// </summary>
    public partial class ShowTab
    {
        public ShowTab()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ShowTabsViewModel;
            if (vm == null) return;
            if (vm is PopularShowTabViewModel || vm is GreatestShowTabViewModel || vm is RecentShowTabViewModel ||
                vm is FavoritesShowTabViewModel)
            {
                if (!vm.IsLoadingShows && vm.NeedSync)
                {
                    await vm.LoadShowsAsync(true).ConfigureAwait(false);
                    vm.NeedSync = false;
                }
            }
            else if (vm is SearchShowTabViewModel)
            {
                var searchVm = vm as SearchShowTabViewModel;
                if (!searchVm.IsLoadingShows && vm.NeedSync)
                {
                    await searchVm.LoadShowsAsync(true).ConfigureAwait(false);
                    vm.NeedSync = false;
                }
            }
        }

        /// <summary>
        /// Load shows if control has reached bottom position
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private async void ScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var totalHeight = e.VerticalOffset + e.ViewportHeight;
            if (totalHeight < 2d / 3d * e.ExtentHeight) return;
            var vm = DataContext as ShowTabsViewModel;
            if (vm == null) return;
            if (vm is PopularShowTabViewModel || vm is GreatestShowTabViewModel || vm is RecentShowTabViewModel ||
                vm is FavoritesShowTabViewModel)
            {
                if (!vm.IsLoadingShows)
                    await vm.LoadShowsAsync().ConfigureAwait(false);
            }
            else if (vm is SearchShowTabViewModel)
            {
                var searchVm = vm as SearchShowTabViewModel;
                if (!searchVm.IsLoadingShows)
                    await searchVm.LoadShowsAsync().ConfigureAwait(false);
            }
        }
    }
}