using UnityEngine;
using System.Collections;

public class scr_PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.instance.AddCount(1);
            gameObject.SetActive(false);
            return;
        }
    }
}
