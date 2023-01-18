using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    private AudioManager myAudioManager;
    void Start()
    {
        myAudioManager= FindObjectOfType<AudioManager>();
    }

public void audioPlay(string name){
    myAudioManager.Play(name);
}
}
