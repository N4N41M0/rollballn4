using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum MenuState {Main, Options, HighScore }
public class scr_ButtonManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public GameObject playMenu;

    public void StartClicked()
    {
        LevelManager.instance.SetGameState(GameState.Play);
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
        
    }
    public void OptionsClicked()
    {
    }
    public void QuitClicked()
    {
        //only works in build
        Application.Quit();
    }
}
