using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    public Text collectingtext;
    public Text counttext;
    public Text wintext;

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
        
        SetCountText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
        if (Input.GetKey("j")) SceneManager.LoadScene(0);

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
        }
    }

    void OnDestroy()
    {
        instance = null;
        Debug.Log("LevelManagerDestroyed");
    }
}
