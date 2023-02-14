using Lean.Transition.Method;
using UnityEngine;

namespace Source
{
    public class ToolBarTarget : LeanTransformPosition
    {
        private void Register(Vector3 position)
        {
            PreviousState = Register(GetAliasedTarget(Data.Target), position, Data.Duration, Data.Ease);
        }

        public void MoveTo(Vector3 position)
        {
            Register(position);
        }

    }
}