using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationcontrollerbehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("RightANswer"))
        {
            animator.SetBool("right", false);
        }
        else if (stateInfo.IsName("wrongAnswer"))
        {
            animator.SetBool("wrong", false);
        }
        else if (stateInfo.IsName("FadIn"))
        {
            animator.SetBool("show", false);
        }
        else if (stateInfo.IsName("EndGAme"))
        {
            animator.SetBool("FadeIn", false);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("RightANswer"))
        {
            LevelController.Instance.ChangeLevel();
        }
        else if (stateInfo.IsName("EndGAme"))
        {
            UIController.Instance.restartButton.SetActive(true);
        }
        else if (stateInfo.IsName("StartGame"))
        {
            LevelController.Instance.MakeLastScenElemetns(false);
           
        }
     
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
