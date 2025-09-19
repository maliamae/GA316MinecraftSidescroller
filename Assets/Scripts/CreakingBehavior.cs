using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreakingBehavior : MonoBehaviour
{
    //public float detectRadius = 1;

    //public Collider2D detectionBox;

    public GameObject creakingChar;
    public GameObject steveChar;
    public Transform creakingTracker;

    public float speed;
    //private bool seesPlayer = false;
    private Vector3 dirToSteve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (targetPos.position.x <= (this.transform.position.x + detectRadius) || targetPos.position.x <= (this.transform.position.x - detectRadius))
        {
            Debug.Log("FOLLOW");
        }
        
        if (Vector3.Dot(dirToSteve, creakingChar.transform.up) > 0)
        {
            creakingChar.transform.position += (dirToSteve * speed) * Time.deltaTime;
            Debug.Log("following left");
        }
        
        
        if (seesPlayer == true)
        {
            creakingChar.transform.position += (dirToSteve * speed) * Time.deltaTime;
        }
        */

        if (steveChar.GetComponent<CharCntrl>().facingRight == true) //ONLY WORKS IF STEVE IS ALWAYS ON THE RIGHT SIDE OF CREAKING
        {
            dirToSteve = creakingTracker.position - creakingChar.transform.position;

            creakingChar.transform.position += (dirToSteve * speed) * Time.deltaTime;
        }
        
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("FOLLOW " + collision.gameObject.name);
            
            dirToSteve = collision.transform.position - creakingChar.transform.position;

            //creakingChar.transform.position = (dirToSteve * speed) * Time.deltaTime;
            seesPlayer = true;
        }
        
    }
    */
}
