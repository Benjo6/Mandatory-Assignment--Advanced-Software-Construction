using Mandatory_Assignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment.StateTable
{
    public class StateMachineTable : IStateMachine
    {
        #region Instance
        private StateMachineEntry[,] _sm;
        private CreatureStatesTypes _currentState;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="T:Mandatory_Assignment.StateTable.StateMachineTable" /> class.
        /// The creator of all State and Actions for CreatureStatesTypes (Situation for our Hero).
        /// </summary>
        public StateMachineTable()
        {
            _currentState = CreatureStatesTypes.North;
            _sm = new StateMachineEntry[6, 6];
            _sm[(int) CreatureStatesTypes.North,(int) InputType.Up] = new StateMachineEntry() { State = CreatureStatesTypes.West, Action = CreatureStatesTypes.West };
            _sm[(int)CreatureStatesTypes.North, (int) InputType.Down] = new StateMachineEntry() { State = CreatureStatesTypes.East, Action = CreatureStatesTypes.East };
            _sm[(int)CreatureStatesTypes.North, (int)InputType.Left] = new StateMachineEntry() { State = CreatureStatesTypes.North, Action = CreatureStatesTypes.North };
            _sm[(int)CreatureStatesTypes.North, (int)InputType.Right] = new StateMachineEntry() { State = CreatureStatesTypes.South, Action = CreatureStatesTypes.South };
            _sm[(int)CreatureStatesTypes.North, (int)InputType.Attack] = new StateMachineEntry() { State = CreatureStatesTypes.North, Action = CreatureStatesTypes.North };
            _sm[(int)CreatureStatesTypes.North, (int)InputType.Loot] = new StateMachineEntry() { State = CreatureStatesTypes.North, Action = CreatureStatesTypes.North };
         
            


            _sm[(int)CreatureStatesTypes.West, (int)InputType.Up] = new StateMachineEntry() { State = CreatureStatesTypes.West, Action = CreatureStatesTypes.West };
            _sm[(int)CreatureStatesTypes.West, (int)InputType.Down] = new StateMachineEntry() { State = CreatureStatesTypes.East, Action = CreatureStatesTypes.East };
            _sm[(int)CreatureStatesTypes.West, (int)InputType.Left] = new StateMachineEntry() { State = CreatureStatesTypes.North, Action = CreatureStatesTypes.North };
            _sm[(int)CreatureStatesTypes.West, (int)InputType.Right] = new StateMachineEntry() { State = CreatureStatesTypes.South, Action = CreatureStatesTypes.South };
            _sm[(int)CreatureStatesTypes.West, (int)InputType.Attack] = new StateMachineEntry() { State = CreatureStatesTypes.West, Action = CreatureStatesTypes.West };
            _sm[(int)CreatureStatesTypes.West, (int)InputType.Loot] = new StateMachineEntry() { State = CreatureStatesTypes.West, Action = CreatureStatesTypes.West };



            _sm[(int)CreatureStatesTypes.East, (int)InputType.Up] = new StateMachineEntry() { State = CreatureStatesTypes.West, Action = CreatureStatesTypes.West };
            _sm[(int)CreatureStatesTypes.East, (int)InputType.Down] = new StateMachineEntry() { State = CreatureStatesTypes.East, Action = CreatureStatesTypes.East };
            _sm[(int)CreatureStatesTypes.East, (int)InputType.Left] = new StateMachineEntry() { State = CreatureStatesTypes.North, Action = CreatureStatesTypes.North };
            _sm[(int)CreatureStatesTypes.East, (int)InputType.Right] = new StateMachineEntry() { State = CreatureStatesTypes.South, Action = CreatureStatesTypes.South };
            _sm[(int)CreatureStatesTypes.East, (int)InputType.Attack] = new StateMachineEntry() { State = CreatureStatesTypes.East, Action = CreatureStatesTypes.East };
            _sm[(int)CreatureStatesTypes.East, (int)InputType.Loot] = new StateMachineEntry() { State = CreatureStatesTypes.East, Action = CreatureStatesTypes.East };




            _sm[(int)CreatureStatesTypes.South, (int)InputType.Up] = new StateMachineEntry() { State = CreatureStatesTypes.West, Action = CreatureStatesTypes.West };
            _sm[(int)CreatureStatesTypes.South, (int)InputType.Down] = new StateMachineEntry() { State = CreatureStatesTypes.East, Action = CreatureStatesTypes.East };
            _sm[(int)CreatureStatesTypes.South, (int)InputType.Left] = new StateMachineEntry() { State = CreatureStatesTypes.North, Action = CreatureStatesTypes.North };
            _sm[(int)CreatureStatesTypes.South, (int)InputType.Right] = new StateMachineEntry() { State = CreatureStatesTypes.South, Action = CreatureStatesTypes.South };
            _sm[(int)CreatureStatesTypes.South, (int)InputType.Attack] = new StateMachineEntry() { State = CreatureStatesTypes.South, Action = CreatureStatesTypes.South };
            _sm[(int)CreatureStatesTypes.South, (int)InputType.Loot] = new StateMachineEntry() { State = CreatureStatesTypes.South, Action = CreatureStatesTypes.South };
        }
        #endregion

        #region Method

        /// <summary>Next move for the Hero.</summary>
        /// <param name="input">This variable is the input you type(if the input is registered in the game) when playing the game.</param>
        /// <returns>It returns the next move for the Hero</returns>
        public CreatureStatesTypes NextMove(InputType input)
        {
            //Locating next move from the current state and input
            CreatureStatesTypes nextMove = _sm[(int)_currentState, (int)input].Action;

            //Locating next state from the current state and input
            _currentState = _sm[(int)_currentState, (int)input].State;
            return nextMove;

        }
        #endregion

        #region StateMachineEntry
        class StateMachineEntry
        {

            /// <summary>Gets or sets the state and action.</summary>
            public CreatureStatesTypes State { get; set; }
            public CreatureStatesTypes Action { get; set; }
        }
        #endregion
    }
}
