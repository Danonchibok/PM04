using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pm04.Model
{
    internal interface IChangebale : INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string name = "");
    }
}
