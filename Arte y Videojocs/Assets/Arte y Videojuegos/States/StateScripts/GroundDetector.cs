using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArteVideojuegos{

    [CreateAssetMenu(fileName = "New State", menuName = "ArteVideojuegos/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.1f, 1f)]
        public float CheckTime;
        public float Distance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator,AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if(stateInfo.normalizedTime <= CheckTime)
            {
                if (IsGrounded(control))
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }                
            }

            if (IsGrounded(control))
            {
                animator.SetBool(TransitionParameter.Grounded.ToString(), true);
            }
            else
            {
                animator.SetBool(TransitionParameter.Grounded.ToString(), false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        bool IsGrounded (CharacterControl control)
        {
            if (control.RIGID_BODY.velocity.y > -0.001f && control.RIGID_BODY.velocity.y <= 0f)
            {
                return true;
            }

            if (control.RIGID_BODY.velocity.y < 0)
            {
                foreach (GameObject o in control.BottomSpheres)
                {
                    RaycastHit hit;
                    if(Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance ))
                    {
                        return true;
                    }
            }
            }

            return false;
        }
    }
}

