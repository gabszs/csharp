using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Manager
{
    internal interface IStock
    {
        void Show();
        void AddStock();
        void RemoveStock();
    }
}
