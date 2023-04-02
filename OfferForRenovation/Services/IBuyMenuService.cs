using OfferForRenovation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferForRenovation.Services
{
    public interface IBuyMenuService
    {
        Work Buy(Work work);
    }
}
