using OfferForRenovation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferForRenovation.Logic
{
    public interface IWorkLogic
    {
        double AllCost { get; }
        void AddToBoughtWork(Work work);
        Work AddToAvailableWork();
        void EditWork(Work work);
        void DeleteWork(Work work);
        ObservableCollection<Work> LoadWork();

        void SetupCollections(IList<Work> works, IList<Work> bought);
    }
}
