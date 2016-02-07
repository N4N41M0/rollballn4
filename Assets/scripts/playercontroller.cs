using UnityEngine;
using System.Collections;



public class playercontroller : MonoBehaviour
{

    public float jumpmod;
    public float speed;
    private bool grounded = true;
    private bool holdingjump = false;
    private Rigidbody solid;
    void Start()
    {
        solid = GetComponent<Rigidbody>();
        float value = Time.time;
    }


    void Update()
    {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            if (holdingjump == false)
            {
                    if (grounded == true)
                    {
                        solid.velocity += new Vector3(0, 2.8f, 0) * jumpmod;
                    }
                    holdingjump = true;
            }
        }
        if (Input.GetAxisRaw("Jump") == 0)
        {
            holdingjump = false;
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        //float moveY = Input.GetAxis("Jump");
        

       


        Vector3 movement = new Vector3(moveX, (0 * jumpmod), moveZ);
        solid.AddForce(movement * speed);
    }
  
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            //LevelManager.instance.AddCount(1);
            return;
        }
        if (other.gameObject.CompareTag("ground"))
        {
            grounded =true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }

    }

}









