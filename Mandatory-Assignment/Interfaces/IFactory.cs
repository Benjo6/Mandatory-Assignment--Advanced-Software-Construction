using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{

    /// <summary>Interface IFactory</summary>
    /// <typeparam name="T">En valgfri klasse</typeparam>
    public interface IFactory<out T>
    {
        T GetQuality();
    }
}

