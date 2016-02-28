﻿using BaoViet.Interfaces;
using BaoViet.Models;
using BaoVietCore.Interfaces;
using BaoVietCore.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using WinUX.Extensions;

namespace BaoViet.ViewModels
{
    public class MarkDown_ViewModel : ViewModelBase, INavigable, ITrackingAble
    {
        bool _IsPreviewOpen = false;
        public bool IsPreviewOpen
        {
            get
            {
                return _IsPreviewOpen;
            }
            set
            {
                Set(ref _IsPreviewOpen, value);
            }
        }


        private string _PreviewMarkDown = "";

        public string PreviewMarkDown
        {
            get
            {
                return _PreviewMarkDown;
            }
            set
            {
                Set(ref _PreviewMarkDown, value);
            }
        }


        private string _SourceInput = "";

        public string SourceInput
        {
            get
            {
                return _SourceInput;
            }
            set
            {
                Set(ref _SourceInput, value);
            }
        }

        public string ScreenName
        {
            get
            {
                return Localytics.LocalyticsScreen.MarkDown_Page;
            }
        }

        public RelayCommand PreviewCommand { get; set; }

        public MarkDown_ViewModel()
        {
            PreviewCommand = new RelayCommand(Preview);
        }

        private void Preview()
        {
            //TODO: set PreviewMarkDown to converted markdown
            PreviewMarkDown = App.Current.Manager.MarkDownService.ConvertToMarkDown(SourceInput);
            IsPreviewOpen = !IsPreviewOpen;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                return;
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        public bool AllowGoBack()
        {
            //TODO: Close confirm asking
            return true;
        }
    }
}
