using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    float timer = 0.0f, timeOut = 0.0f, timeSane = 0.0f;
    public float sanity = 100.0f;

    public float sanityDowner = 0.1f;
    // Start is called before the first frame update
    private GameObject player;
    private GameObject bubble;
    private GameObject healthBar;
    bool isInside = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        bubble = GameObject.FindGameObjectWithTag("Bubble");
        healthBar = GameObject.FindGameObjectWithTag("healthBar");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

       
        int numColliders = 1;
        Collider2D[] colliders = new Collider2D[numColliders];
        ContactFilter2D contactFilter = new ContactFilter2D();

        player.GetComponent<BoxCollider2D>().OverlapCollider( contactFilter, colliders);

        if (!isInside) 
        {
            timeOut += Time.deltaTime;
            timeSane = 0.0f;
            sanity -= sanityDowner * timeOut / 1000 * timer / 1000;
        }
        else
        {
            timeOut = 0.0f;
            timeSane += Time.deltaTime;
            if (sanity < 100.0f)
                sanity += sanityDowner * timer / 100000;
            else sanity = 100.0f;
        }
        healthBar.GetComponent<healthBarScript>().setHealth((int)sanity);
    }


    public void setInside(bool ins)
    {
        isInside = ins;
    }    
}
