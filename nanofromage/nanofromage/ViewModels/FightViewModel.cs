using nanofromage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nanofromage.ViewModels
{
    public class FightViewModel
    {
        public FightViewModel(Fight page)
        {
            this.page = page;
        }
        

        public Fight page { get; private set; }
    }
}
