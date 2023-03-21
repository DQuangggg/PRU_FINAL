using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")] 
    public string _newGameLevel; 
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("Saved Level"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            //PlayerPrefs.SetString("SavedLevel", yourlevelis);
            SceneManager.LoadScene(levelToLoad);
        }
        else {
            noSavedGameDialog.SetActive(true);
        }
    }
    public void ExitButton()
    {
         Application.Quit();
    }
}
