using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;



public class playercontroller : MonoBehaviour
{
    public Text collectingtext;
    public Text counttext;
    public Text wintext;
    public float jumpmod;
    public float speed;
    private float timer;
    private Rigidbody solid;
    private int count;
    void Start()
    {
    solid = GetComponent<Rigidbody>();
    count = 0;
        SetCountText();
        wintext.text = "";
        float value = Time.time;
    }
    float RTimer (float timer)
            {
            timer *= 100;
            timer = Mathf.Round(timer);
            timer /= 100;
            return timer;
            }
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Jump");
        

       


        Vector3 movement = new Vector3(moveX, (moveY * jumpmod), moveZ);
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
        if (Input.GetKey("j")) SceneManager.LoadScene(0);
        if (Input.GetKey(KeyCode.Space)) collectingtext.text = "Jumping...";
        solid.AddForce(movement * speed);
    }
  
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("ground"))
        {
            collectingtext.text = "";
        }
    }


    void SetCountText ()
    {
        counttext.text = "Collected: " + count.ToString();
        if (count >= 8)
        {
            timer = Time.time;
            wintext.text = "WINNER! You collected " + count.ToString() + " cubes!" + " " + RTimer(timer) + " seconds. " + "Escape to exit.";
        }

    }
}