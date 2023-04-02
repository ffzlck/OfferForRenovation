using OfferForRenovation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferForRenovation.Services
{
    public class WorkEditorService : IWorkEditorService
    {
        public void Edit(Work work)
        {
            new ComponentEditor(work).ShowDialog();
        }
    }
}
