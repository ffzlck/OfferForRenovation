using OfferForRenovation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferForRenovation.Services
{
    public class BuyMenuService : IBuyMenuService
    {
        public Work Buy(Work work)
        {
            new BuyMenuWindows(work).ShowDialog();
            return work;
        }
    }
}
