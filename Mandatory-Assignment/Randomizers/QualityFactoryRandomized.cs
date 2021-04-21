using Mandatory_Assignment.Randomizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment
{ 
    /// <summary>Class QualityFactoryRandomized.
    /// Implements the <see cref="Mandatory_Assignment.Randomizers.RandomizedFactory{Mandatory_Assignment.Quality}" /></summary>
    public class QualityFactoryRandomized : RandomizedFactory<Quality>
    {

        /// <summary>Initializes a new instance of the <see cref="T:Mandatory_Assignment.QualityFactoryRandomized" /> class.
        /// Here is the odds for getting each Sword Quality.
        /// </summary>
        public QualityFactoryRandomized()
        {
            AddFactory(50, () => Quality.common);
            AddFactory(37, () => Quality.rare);
            AddFactory(10, () => Quality.epic);
            AddFactory(3, () => Quality.legendary);

        }


    }
}
