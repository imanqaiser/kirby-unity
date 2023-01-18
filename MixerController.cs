using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MixerController : MonoBehaviour
{
[SerializeField] private AudioMixer myAudioMixer;
public void SetVolume(string type, float value){ //type exposed mixer params masterVolume,musicVolume,soundVolume
    myAudioMixer.SetFloat(type,Mathf.Log10(value)*20);
}
}
