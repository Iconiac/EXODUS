﻿using UnityEngine;
using System.Collections;

public class PortBehavior : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PortBase.SetDialoge(stateInfo.shortNameHash);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Options.Option1)
        {
            Options.Option1 = false;
            Decisions.SisterChosen = true;
            Decisions.BrotherChosen = false;
            animator.SetTrigger("Option 1");
        }

        else if (Options.Option2)
        {
            Options.Option2 = false;
            Decisions.BrotherChosen = true;
            Decisions.SisterChosen = false;
            animator.SetTrigger("Option 2");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    GameObject dialoge = GameObject.Find("Dialoge");
    //    dialoge.SetActive(false);
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}