using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment.Randomizers
{
    public class EnemyQualityFactoryRandomized : RandomizedFactory<EnemyKind>
    {
        public EnemyQualityFactoryRandomized()
        {
            AddFactory(30, () => EnemyKind.Warrior);
            AddFactory(20, () => EnemyKind.Phalanx);
            AddFactory(15, () => EnemyKind.Pikemen);
            AddFactory(15, () => EnemyKind.Legion);
            AddFactory(10, () => EnemyKind.Knights);
            AddFactory(7, () => EnemyKind.Muskesteers);
            AddFactory(3, () => EnemyKind.Riflemen);


        }
    }
}
