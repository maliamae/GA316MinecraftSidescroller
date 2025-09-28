using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    //public GameObject cloud;
    public Vector3 moveDirection;
    public float speed = 1;
    Vector3 startPos;

    public static bool gameOn = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn == false)
        {
            this.transform.position += (moveDirection * speed) * Time.deltaTime;
        }
        else
        {
            StartCoroutine(ResetClouds());
        }
        
    }

    IEnumerator ResetClouds()
    {
        yield return new WaitForSeconds(3f);
        this.transform.position = startPos;
    }
}
