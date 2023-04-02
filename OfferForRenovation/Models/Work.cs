using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferForRenovation.Models
{
    public class Work : ObservableObject
    {
        private string name;
        public string Name 
        { 
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string typePrice;
        public string TypePrice 
        { 
            get { return typePrice; } 
            set { SetProperty(ref typePrice, value); }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        private double amount;
        public double Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }
        private double actualPrice;
        public double ActualPrice
        {
            get { return actualPrice; }
            set { SetProperty(ref actualPrice, value); }
        }

        public Work GetCopy()
        {
            return new Work()
            {
                Name=this.Name,
                TypePrice = this.typePrice,
                Price = this.price,
                Amount = this.amount,
                ActualPrice = this.actualPrice
            };
        }

    }
}
