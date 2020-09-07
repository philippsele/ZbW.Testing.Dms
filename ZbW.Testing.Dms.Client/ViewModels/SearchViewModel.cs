using System;
using System.Windows;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Collections.Generic;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;

    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _filteredMetadataItems;

        private MetadataItem _selectedMetadataItem;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        private readonly DocumentManagementService _documentManagementService;

        private readonly IMessageBoxService _messegaBoxService;

        public SearchViewModel(DocumentManagementService documentManagementService, IMessageBoxService messegaBoxService)
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);

            _messegaBoxService = messegaBoxService;
            _documentManagementService = documentManagementService;
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public List<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
            _documentManagementService.OpenDocument(SelectedMetadataItem.DokumentenGuid, SelectedMetadataItem.ValutaDatum.Year, SelectedMetadataItem.FileName);
        }

        private void OnCmdSuchen()
        {
            if (string.IsNullOrEmpty(_suchbegriff) && string.IsNullOrEmpty(_selectedTypItem))
            {
                _messegaBoxService.Show("Bitte einen Filter setzen.");

            }
            else
            {
                FilteredMetadataItems = _documentManagementService.SearchDocument(_suchbegriff, _selectedTypItem);
            }
        }

        private void OnCmdReset()
        {
            Suchbegriff = null;
            SelectedTypItem = null;

            FilteredMetadataItems = null;
        }
    }
}