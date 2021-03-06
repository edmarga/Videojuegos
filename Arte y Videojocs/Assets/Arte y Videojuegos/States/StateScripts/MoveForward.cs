using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArteVideojuegos{

    [CreateAssetMenu(fileName ="New State", menuName = "ArteVideojuegos/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {

        public AnimationCurve SpeedGraph;
        public float Speed;
        public float BlockDistance;
        
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState,Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            
            if (control.Jump){
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (control.MoveRight && control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!control.MoveRight && !control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (control.MoveRight){
                if(!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                    control.transform.rotation = Quaternion.Euler(0f,0f,0f);
                }


                
            }

            if (control.MoveLeft){

                if(!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                    control.transform.rotation = Quaternion.Euler(0f,180f,0f);
                }


            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFront(CharacterControl control)
        {

            foreach (GameObject o in control.FrontSpheres)
            {
                RaycastHit hit;
                if(Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance ))
                {
                    return true;
                }
            }

            return false;
        }

    }

}