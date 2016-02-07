using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class playercontroller : MonoBehaviour
{
    public Text collectingtext;
    public Text counttext;
    public Text wintext;
    public float jumpmod;
    public float speed;
    private float timer;
    private float rtimer;
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
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Jump");
        float timer = Time.time;

        float rtimer (float timer) =
            {
            timer *= 100;
            timer = Mathf.Round(timer);
            timer /= 100;
            }


        Vector3 movement = new Vector3(moveX, (moveY * jumpmod), moveZ);
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
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
            wintext.text = "WINNER! You collected " + count.ToString() + " cubes!" + " " + rtimer + " seconds. " + "Escape to exit.";
        }

    }
}