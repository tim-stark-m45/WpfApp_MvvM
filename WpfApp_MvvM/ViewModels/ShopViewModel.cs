using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_MvvM.Models;

namespace WpfApp_MvvM.ViewModels
{
    class ShopViewModel : ViewModelBase
    {
        private string text = "Test";
        public string Text { get => text; set => Set(ref text, value); }

        private RelayCommand testCommand;
        public RelayCommand TestCommand
        {
            get => testCommand ?? (testCommand = new RelayCommand(
              () =>
              {
                  var product = new Product
                  {
                      Name = "Test",
                      Image = null,
                      Price = 10,
                      Count = 5
                  };

                  using (var db =new ShopContext())
                  {
                      db.Products.Add(product);
                      db.SaveChanges();
                  }
              }
              ));
        }

    }
}
