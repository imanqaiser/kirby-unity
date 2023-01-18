using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int healthMax, playerHealth;
    private int livesMax, lives;
    private Image healthImage;
    private Image livesImage;
    private Scene currentScene;
    private AudioManager myAudioManger;
    private Animator animator;
    public float restartTimer = 3.0f;
    private float timeLeft;
    bool gameOver = false;
    private TextMeshProUGUI restartText;
    private GameObject gameOverPanel, gameOverText;
    private Image gameOverBG;
    void Start()
    {
        animator= GameObject.Find("kirby").GetComponent<Animator>();
        playerHealth = PlayerPrefs.GetInt("health");
        healthMax = PlayerPrefs.GetInt("maxHealth");
        livesMax = PlayerPrefs.GetInt("maxLives");
        lives = PlayerPrefs.GetInt("lives");
        myAudioManger = FindObjectOfType<AudioManager>();
        healthImage = GameObject.Find("HealthFill").GetComponent<Image>();
        livesImage = GameObject.Find("LivesFill").GetComponent<Image>();
        healthImage.fillAmount = playerHealth * 1.0f / healthMax;
        livesImage.fillAmount = lives * 1.0f / livesMax;
        
        currentScene = SceneManager.GetActiveScene();
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverText = GameObject.Find("RestartText");
        restartText = gameOverText.GetComponent<TextMeshProUGUI>();
        gameOverPanel.SetActive(false);
        healthImage.color = Color.HSVToRGB(playerHealth * 0.33f / healthMax, 0.9f, 0.9f);// 0.33 hue is green. 0 is red 
       // livesImage.color = Color.HSVToRGB((lives - 1) * 0.5f / livesMax, 0.9f, 0.9f); //(3-1))/3*0.5 = 0.33,lives -1 to show red with 1 life 

    }
    private void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            timeLeft -= Time.unscaledDeltaTime;
            restartText.text = "Restarting in : " + (int)timeLeft + " sec";
            if (lives<=0) restartText.text = "Game Over\n"+"Restarting\n" + (int)timeLeft + " Sec";
            gameOverPanel.GetComponent<CanvasGroup>().alpha = timeLeft / restartTimer;
            Time.timeScale = 0;
            if (timeLeft < 0)
            {
                Time.timeScale = 1;
                if (lives > 0)
                { RestartLevel(); }
                else
                { RestartGame(); }

            }
        }

    }
    public void TakeDamage(int damage)
    {
        myAudioManger.Play("hit");
        animator.SetTrigger("gotHit");
        playerHealth -= damage;
        healthImage.fillAmount = playerHealth * 1.0f / healthMax;
        healthImage.color = Color.HSVToRGB(playerHealth * 0.33f / healthMax, 0.9f, 0.9f);

        PlayerPrefs.SetInt("heath", playerHealth);
        if (playerHealth <= 0)
        {
            lives--;
            livesImage.fillAmount = (lives * 1.0f / livesMax);
           // livesImage.color = Color.HSVToRGB((lives - 1) * 0.5f / livesMax, 0.9f, 0.9f);
            PlayerPrefs.SetInt("lives", lives);
            gameOver = true; //restart level if lives left else game over
            timeLeft = restartTimer;
        }
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(currentScene.name);

    }
    private void RestartGame()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
