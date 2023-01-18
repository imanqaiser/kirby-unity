using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : StateMachineBehaviour
{
    public float boredTime = 5f;
    public float yawnTime = 3f;
    private float idleTime;
    private AudioManager myAudioManger;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleTime = 0f;
        myAudioManger = FindObjectOfType<AudioManager>();

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleTime += Time.deltaTime;
        if (idleTime > boredTime )
        {
            if (idleTime > boredTime)
            {
                myAudioManger.Play("Bored");

                idleTime = 0f;
            }
        }

    }
}
