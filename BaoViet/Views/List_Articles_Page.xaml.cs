﻿using BaoViet.Interfaces;
using BaoViet.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Croft.Core.Extensions;
using Microsoft.Practices.ServiceLocation;
using BaoVietCore.Models;
using BaoVietCore.Interfaces;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BaoViet.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class List_Articles_Page : BindablePage
    {
        public List_Articles_ViewModel ViewModel
        {
            get
            {
                return DataContext as List_Articles_ViewModel;
            }
        }
        public List_Articles_Page()
        {
            this.InitializeComponent();
        }

        private void ListArticle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var feed = e.ClickedItem as IFeedItem;
            var detail = ServiceLocator.Current.GetInstance<Detail_ViewModel>();
            detail.CurrentFeed = feed;
            App.Current.NavigationService.NavigateTo(Pages.DetailPage);
        }

        //TODO: move to view model
        private void SlidableListItem_RightCommandRequested(object sender, EventArgs e)
        {
            var model = (sender as FrameworkElement).DataContext as FeedItem;
            if(model != null)
            {
                var attribute = new Dictionary<string, string>();
                attribute.Add("paper name", this.ViewModel.CurrentCategory.Owner.Title);

                App.Current.Manager.TrackingService.TagEvent("Save article", attribute);
                App.Current.Manager.Database.AddItem(model);
                App.Current.InvokeOnToastRise("Đã lưu", 1000);
            }
        }
    }
}
