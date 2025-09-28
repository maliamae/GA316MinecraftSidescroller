using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public int playSpeed = 1;
    public Animator anim;
    public bool atBorder = false;
    public CanvasGroup blackScreen;
    bool hasTouchedSteve = false;
    public ScreenTransition fadeScript;
    //public Transform steveSpawnPoint;
    //public Transform creakingSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //anim.speed = playSpeed;
        
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
        
        //following for CharCntrl script
        if (steveChar.GetComponent<CharCntrl>().facingRight == true) //ONLY WORKS IF STEVE IS ALWAYS ON THE RIGHT SIDE OF CREAKING
        {
            dirToSteve = creakingTracker.position - creakingChar.transform.position;

            creakingChar.transform.position += (dirToSteve * speed) * Time.deltaTime;
        }
        */

        //following for Controller script (animations)
        if (steveChar.GetComponent<Controller>().facingRight == true && atBorder == false) //ONLY WORKS IF STEVE IS ALWAYS ON THE RIGHT SIDE OF CREAKING
        {
            dirToSteve = creakingTracker.position - creakingChar.transform.position;

            creakingChar.transform.position += (dirToSteve * speed) * Time.deltaTime;
            playSpeed = 1;
            anim.speed = playSpeed;
        }
        else if (steveChar.GetComponent<Controller>().facingRight == false)
        {
            playSpeed = 0;
            anim.speed = playSpeed;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Creaking at border");
        if (collision.gameObject.tag == "CreakingBorder")
        {
            //Debug.Log("creaking at border");
            //anim.speed = 0;
            atBorder = true;
            anim.SetBool("atBorder", atBorder);
        }

        if(collision.gameObject.tag == "Player" && hasTouchedSteve == false)
        {
            //Debug.Log("steve dies");
            //blackScreen.gameObject.SetActive(true);
            StartCoroutine(fadeScript.AnimateTransitionIn());
            hasTouchedSteve=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CreakingBorder")
        {
            //Debug.Log("creaking at border");
            //anim.speed = 0;
            atBorder = true;
            anim.SetBool("atBorder", atBorder);
        }
    }

    /*
    public IEnumerator AnimateTransitionIn()
    {
        var tweener = blackScreen.DOFade(1f, 2f);
        yield return tweener.WaitForCompletion();
        steveChar.transform.position = steveSpawnPoint.position;
        creakingChar.transform.position = creakingSpawnPoint.position;
        creakingChar.SetActive(false);
        StartCoroutine(AnimateTransitionOut());
    }

    public IEnumerator AnimateTransitionOut()
    {
        var tweener = blackScreen.DOFade(0f, 2f);
        yield return tweener.WaitForCompletion();
    }

    
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
