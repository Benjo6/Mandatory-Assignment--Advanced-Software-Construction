using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment.Interfaces
{

    /// <summary>Enum CreatureStatesTypes</summary>
    public enum CreatureStatesTypes
    {
        North,
        East,
        West,
        South
    };

    /// <summary>Enum InputType</summary>
    public enum InputType
    {
        Left,
        Right,
        Up,
        Down,
        Attack,
        Loot
    }



    /// <summary>Interface IStateMachine</summary>
    public interface IStateMachine
    {
        CreatureStatesTypes NextMove(InputType input);

    }
}
