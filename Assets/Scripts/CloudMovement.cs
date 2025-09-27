using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    //public GameObject cloud;
    public Vector3 moveDirection;
    public float speed = 1;

    public static bool gameOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn == false)
        {
            this.transform.position += (moveDirection * speed) * Time.deltaTime;
        }
        
    }
}
