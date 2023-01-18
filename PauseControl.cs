
using UnityEngine;

public class PauseControl : MonoBehaviour
{

    private GameObject pausePanel,player;

    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);
        player=GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(!pausePanel.activeSelf);//toggle
            player.SetActive(!player.activeSelf);

            if (pausePanel.activeSelf)
            {
                Time.timeScale = 0;
            }
            else Time.timeScale = 1;

        }
    }


    public void ContinueButtonClick()
    {
        pausePanel.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1;
    }


}
