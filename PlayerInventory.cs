using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour
{
    private AudioManager myAudioManger;
    public int NumberofDiamonds;
    public int Score;
    private TextMeshProUGUI ScoreText, DiamondsText;
    private GameObject ScoreObject, DiamondsObject, TreasureObject;
    private Image TreasureFill;



    void Start()
    {
        ScoreObject = GameObject.Find("Score");
        DiamondsObject = GameObject.Find("DiamondsNum");
        TreasureObject = GameObject.Find("Treasure");
        TreasureFill = GameObject.Find("TreasureFill").GetComponent<Image>(); ;
        ScoreText = ScoreObject.GetComponent<TextMeshProUGUI>();
        DiamondsText = DiamondsObject.GetComponent<TextMeshProUGUI>();
        myAudioManger = FindObjectOfType<AudioManager>();
        Score = PlayerPrefs.GetInt("score", 0);
        NumberofDiamonds = PlayerPrefs.GetInt("numDiamonds", 0);
        ScoreText.text = Score.ToString();
    }
    public void DiamondCollected()
    {
        NumberofDiamonds++;
        Score += 10;
        PlayerPrefs.SetInt("numDiamonds", NumberofDiamonds);
        PlayerPrefs.SetInt("score", Score);
        ScoreText.text = Score.ToString();
        DiamondsText.text = " " + NumberofDiamonds.ToString();
        myAudioManger.Play("Ding");
    }
    public void TreasureCollected()
    {
        Score += 100;
        PlayerPrefs.SetInt("score", Score);
        ScoreText.text = Score.ToString();
        TreasureFill.fillAmount = 1;
        myAudioManger.Play("Treasure");

    }

}
