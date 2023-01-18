using UnityEngine;
[System.Serializable] //to show up in unity inspector for attaching clips
public class Sound
{
    public enum AudioTypes{soundEffect,music}
    public AudioTypes audioType;
public string name;
public AudioClip clip;
[Range(0f,1f)] public float volume;
[Range(0.1f,3f)] public float pitch;
public bool loop;
[HideInInspector] public AudioSource source;

}
