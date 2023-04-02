using OfferForRenovation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferForRenovation.ViewModels
{
    public class WorkEditorViewModel
    {
        public Work Actual { get; set; }

        public void Setup(Work actual)
        {
            this.Actual = actual;
        }
        public WorkEditorViewModel()
        {

        }
    }
}
