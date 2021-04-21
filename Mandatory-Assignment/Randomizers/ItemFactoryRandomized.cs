using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment.Randomizers
{
    /// <summary>Class ItemFactoryRandomized.
    /// Implements the <see cref="Mandatory_Assignment.Randomizers.RandomizedFactory{System.Object}" />
    /// </summary>
    public class ItemFactoryRandomized : RandomizedFactory<object>
    {
        #region Instance
        private WorldObject _object;
        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="T:Mandatory_Assignment.Randomizers.ItemFactoryRandomized" /> class.
        /// Here is the odds for getting a Items.
        /// </summary>
        public ItemFactoryRandomized()
        {
            AddFactory(25, () => new Sword());
            AddFactory(25, () => new Shield());
            AddFactory(25, () => new WorldObject().Health);
            AddFactory(25, () => new WorldObject().Horse);
            

        }
        #endregion
    }
}
