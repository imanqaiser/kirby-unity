using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class UIMenu : MonoBehaviour
{
    private VisualElement root, settingsPanel, mainMenuPanel;
    private Button playButton, settingsButton, exitButton, soundButton, backButton;
    private Slider masterVol, soundVol, musicVol;
    [SerializeField]
    private Sprite soundIcon;
    [SerializeField]
    private Sprite soundMutedIcon;
    private bool muted;
    private MixerController myMixerController;
    private AudioManager myAudioManger;
    void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        myMixerController = FindObjectOfType<MixerController>();
        myAudioManger = FindObjectOfType<AudioManager>();
        mainMenuPanel = root.Q<VisualElement>("MainMenu");
        settingsPanel = root.Q<VisualElement>("SettingsMenu");
        playButton = root.Q<Button>("PlayButton");
        settingsButton = root.Q<Button>("SettingsButton");
        exitButton = root.Q<Button>("ExitButton");
        soundButton = root.Q<Button>("SoundButton");
        backButton = root.Q<Button>("BackButton");
        masterVol = root.Q<Slider>("MasterVolume");
        soundVol = root.Q<Slider>("SoundVolume");
        musicVol = root.Q<Slider>("MusicVolume");
        
        playButton.clicked += playButtonClicked;
        exitButton.clicked += exitButtonClicked;
        soundButton.clicked += soundButtonClicked;
        settingsButton.clicked += settingsButtonClicked;
        backButton.clicked += backButtonClicked;
        //callback functions for slider changes

        masterVol.RegisterValueChangedCallback(v =>
        {
            //var oldValue = v.previousValue;
            myMixerController.SetVolume("masterVolume", v.newValue);
        });
        soundVol.RegisterValueChangedCallback(v =>
       {
           myMixerController.SetVolume("soundVolume", v.newValue);
           myAudioManger.Play("Ding");
       });
        musicVol.RegisterValueChangedCallback(v =>
       {
           myMixerController.SetVolume("musicVolume", v.newValue);
       });
        mainMenuPanel.style.display = DisplayStyle.Flex;
        settingsPanel.style.display = DisplayStyle.None;
    }
    private void Start()
    {
        //set inital volume values from UI
        myMixerController.SetVolume("masterVolume", masterVol.value);
        myMixerController.SetVolume("soundVolume", soundVol.value);
        myMixerController.SetVolume("musicVolume", musicVol.value);
    }
    private void playButtonClicked()
    {
        SceneManager.LoadScene("level1");
    }
    private void exitButtonClicked()
    {
        Application.Quit();
    }
    private void soundButtonClicked()
    {
        muted = !muted;
        var soundBg = soundButton.style.backgroundImage;
        soundBg.value = Background.FromSprite(muted ? soundMutedIcon : soundIcon);
        soundButton.style.backgroundImage = soundBg;
        AudioListener.volume = muted ? 0 : 1;
    }
    private void settingsButtonClicked()
    {
        mainMenuPanel.style.display = DisplayStyle.None;
        settingsPanel.style.display = DisplayStyle.Flex;

    }
    private void backButtonClicked()
    {
        mainMenuPanel.style.display = DisplayStyle.Flex;
        settingsPanel.style.display = DisplayStyle.None;

    }


}
