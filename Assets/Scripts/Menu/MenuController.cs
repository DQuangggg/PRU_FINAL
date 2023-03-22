using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _newGameLevel, _newLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;
    public Slider volumeSlider/*, soundSlider*/;
    public AudioMixer mixer/*, soundMixer*/;
    private float value, value2;
    

    private void Start()
    {
        Time.timeScale = 1; 
        mixer.GetFloat("music", out value); 
        volumeSlider.value = value;
    /*    soundMixer.GetFloat("volumeSound", out value2);
        soundSlider.value=value2;*/
    }

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void NewLevel()
    {
        SceneManager.LoadScene(_newLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("Saved Level"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            //PlayerPrefs.SetString("SavedLevel", yourlevelis);
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetMusic()
    {
        mixer.SetFloat("music", volumeSlider.value);        
    }

    /*public void SetSound()
    {
        soundMixer.SetFloat("volumeSound", soundSlider.value);
    }*/
}