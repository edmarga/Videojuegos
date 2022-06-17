using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArteVideojuegos
{

        public abstract class StateData : ScriptableObject
        {
            

            public abstract void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo);
            public abstract void UpdateAbility(CharacterState characterState,Animator animator, AnimatorStateInfo stateInfo);
            public abstract void OnExit(CharacterState characterControl, Animator animator, AnimatorStateInfo stateInfo);

        }
    
}

