using UnityEngine;
using System.Collections;

public class scr_PickUp : MonoBehaviour {
    
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
