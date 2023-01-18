using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int maxLives = 3;
    private int maxHealth = 100;
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("numDiamonds", 0);
        PlayerPrefs.SetInt("health", maxHealth);
        PlayerPrefs.SetInt("lives", maxLives);
        PlayerPrefs.SetInt("maxHealth", maxHealth);
        PlayerPrefs.SetInt("maxLives", maxLives);
    }


}
