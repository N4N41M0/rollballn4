using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//this defines names we can use as the "states" in the game
//alone this is entirely arbitrary.  There can be any number of
//states with any variety of names.
public enum GameState { MainMenu, Play, Pause, Victory, Defeat};
public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public Transform SpawnPoint;

    public Text collectingtext;
    public Text counttext;
    public Text wintext;

    //this variable will hold the current game state
    private GameState gameState;
    //This will hold the previous game state
    private GameState prevState;

    private float timer;
    private int count;
    private int score = 0;
	// Use this for initialization
	void Start ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("A Level Manager Already Exists");
            Destroy(this.gameObject);
            return;
        }
        prevState = gameState = GameState.MainMenu;
        SetCountText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (gameState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Play:
                if (prevState == GameState.MainMenu)
                {
                    prevState = gameState;
                    GameObject player = Instantiate(Resources.Load("Player"),SpawnPoint.position,SpawnPoint.rotation) as GameObject;
                    Camera.main.GetComponent<CameraController>().parent = player;
                }
                break;
            case GameState.Pause:
                break;
            case GameState.Victory:
                
                break;
            case GameState.Defeat:
                break;
        }
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();

    }


    float RTimer(float timer)
    {
        timer *= 100;
        timer = Mathf.Round(timer);
        timer /= 100;
        return timer;
    }

    public void AddCount(int amount)
    {
        count += amount;
        SetCountText();
        CheckWin();
    }

    void SetCountText()
    {
        counttext.text = "Collected: " + count.ToString();

    }

    void CheckWin()
    {
        if (count >= 8)
        {
            timer = Time.time;
            wintext.text = "WINNER! You collected " + count.ToString() + " cubes!" + " " + RTimer(timer) + " seconds. " + "Escape to exit.";
            gameState = GameState.Victory;
        }
    }

    void OnDestroy()
    {
        instance = null;
        Debug.Log("LevelManagerDestroyed");
    }

    public GameState GetGameState()
    {
        return gameState;
    }
    public GameState GetPrevState()
    {
        return prevState;
    }
    public void SetGameState(GameState newState)
    {
        prevState = gameState;
        gameState = newState;
    }
}
