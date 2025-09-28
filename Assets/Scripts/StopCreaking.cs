using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCreaking : MonoBehaviour
{
    //public GameObject border;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
