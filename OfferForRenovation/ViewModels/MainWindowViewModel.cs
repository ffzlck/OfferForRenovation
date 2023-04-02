using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using OfferForRenovation.Logic;
using OfferForRenovation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OfferForRenovation.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IWorkLogic logic;
        private ObservableCollection<Work> availableWork;
        public ObservableCollection<Work> AvailableWork 
        {
            get { return availableWork; }
            set { SetProperty(ref availableWork, value);
                ;
            }
        }
        private ObservableCollection<Work> boughtWork;
        public ObservableCollection<Work> BoughtWork
        {
            get { return boughtWork; }
            set
            {
                SetProperty(ref boughtWork, value);
            }
        }
        
        private Work selectedFromAvaialbleWork;
        public Work SelectedFromAvaialbleWork
        {
            get { return selectedFromAvaialbleWork; }
            set { SetProperty(ref selectedFromAvaialbleWork, value);
                ( AddToBoughtWork as RelayCommand).NotifyCanExecuteChanged();
                ( EditAvaialbleWork as RelayCommand).NotifyCanExecuteChanged();
                
            }
        }
        private Work selectedFromBoughtWork;
        public Work SelectedFromBoughtWork
        {
            get { return selectedFromBoughtWork;}
            set { SetProperty(ref selectedFromBoughtWork, value);
                (DeleteWork as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToAvailableWork { get; set; }
        public ICommand AddToBoughtWork { get; set; }
        public ICommand EditAvaialbleWork { get; set; }
        public ICommand DeleteWork { get; set; }
        public ICommand LoadSavedWork { get; set; }

        public double AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }


        public static bool IsInDesigneMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel() : this(IsInDesigneMode ? null : Ioc.Default.GetService<IWorkLogic>())
        {

        }

        public MainWindowViewModel(IWorkLogic logic)
        {
            this.logic = logic;
            AvailableWork = new ObservableCollection<Work>();
            BoughtWork = new ObservableCollection<Work>();

            logic.SetupCollections(AvailableWork, BoughtWork);

            AddToAvailableWork = new RelayCommand(
                () => AvailableWork.Add(logic.AddToAvailableWork()));

            AddToBoughtWork = new RelayCommand(
                () =>
                {
                    logic.AddToBoughtWork(SelectedFromAvaialbleWork);
                },
                () => SelectedFromAvaialbleWork != null);

            EditAvaialbleWork = new RelayCommand(
                () => logic.EditWork(SelectedFromAvaialbleWork),
                () => SelectedFromAvaialbleWork != null);

            DeleteWork = new RelayCommand(
                () => logic.DeleteWork(SelectedFromBoughtWork),
                () => SelectedFromBoughtWork != null);

            LoadSavedWork = new RelayCommand(
                () =>
                {
                    AvailableWork = logic.LoadWork();
                }
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "WorkInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
            }
            );
        }
    }
}
