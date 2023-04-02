using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using OfferForRenovation.Models;
using OfferForRenovation.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfferForRenovation.Logic
{
    internal class WorkLogic : IWorkLogic
    {
        IList<Work> bought;
        IList<Work> works;
        IMessenger messenger;
        IWorkEditorService editorService;
        IBuyMenuService buyMenuService;

        public WorkLogic(IMessenger messenger, IWorkEditorService editorService, IBuyMenuService buyMenuService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.buyMenuService = buyMenuService;
        }

        public double AllCost
        {
            get
            {
                return bought.Count == 0 ? 0 : bought.Sum(t => t.ActualPrice);
            }
        }

        public Work AddToAvailableWork()
        {
            Work x= new Work()
            {
                Name = "Új munka szerkeztést igényel."
            };
            return x;
        }

        public void AddToBoughtWork(Work work)
        {
            var x=buyMenuService.Buy(work.GetCopy());
            x.ActualPrice = x.Price * x.Amount;
            bought.Add(x);
            messenger.Send("WorkAdded", "WorkInfo");
        }

        public void DeleteWork(Work work)
        {
            bought.Remove(work);
            messenger.Send("WorkAdded", "WorkInfo");

        }

        public void EditWork(Work work)
        {
            editorService.Edit(work);
        }

        public ObservableCollection<Work> LoadWork()
        {

            string jsonS = File.ReadAllText("Works.json");
            List<Work> works = System.Text.Json.JsonSerializer.Deserialize<List<Work>>(jsonS);
            ObservableCollection<Work> workList =new ObservableCollection<Work>();
            foreach (Work work in works)
            {
                workList.Add(work);
            }
            return workList;
        }

        public void SetupCollections(IList<Work> works, IList<Work> bought)
        {
            this.bought = bought;
            this.works = works;
        }

    }
}
