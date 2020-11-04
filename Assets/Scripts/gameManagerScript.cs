using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    float timer = 0.0f, timeOut = 0.0f, timeSane = 0.0f;
    public float sanity = 100.0f;
    public float score = 0.0f;
    public float sanityDowner = 0.1f;
    // Start is called before the first frame update
    private GameObject player;
    private GameObject bubble;
    private GameObject healthBar;

    bool coinExists = false;

    public GameObject coin;
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
        score += Time.deltaTime * 50;
       
        int numColliders = 1;
        Collider2D[] colliders = new Collider2D[numColliders];
        ContactFilter2D contactFilter = new ContactFilter2D();

        player.GetComponent<BoxCollider2D>().OverlapCollider( contactFilter, colliders);

        if (!isInside) 
        {
            timeOut += Time.deltaTime;
            
            timeSane = 0.0f;
            sanity -= sanityDowner * timeOut / 1000 * timer / 1000;
            player.GetComponent<Player_move>().enableArrow();
            if (!coin.gameObject.activeSelf)
            {
                coinExists = false;
            }

        }
        else
        {
            player.GetComponent<Player_move>().disableArrow();
            timeOut = 0.0f;
            timeSane += Time.deltaTime;
            score += Time.deltaTime * 25;

            if(timeSane > 6 && !coinExists)
            {
                summonCoin();
                coinExists = true;
            }

        }
        healthBar.GetComponent<healthBarScript>().setHealth((int)sanity);
    }


    public float getTimer()
    {
        return timer;
    }

    public void setInside(bool ins)
    {
        isInside = ins;
    }

    public void summonCoin()
    {
        Vector2 coinPos = bubble.GetComponent<Rigidbody2D>().position + bubble.GetComponent<Rigidbody2D>().velocity.normalized * 10;
        if (coinPos.x < -12)
            coinPos.x += 12;
        else if (coinPos.x > 12)
            coinPos.x -= 12;
      //  coin =  Instantiate(coin);
        coin.transform.position = coinPos;
        coin.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        coin.gameObject.SetActive(true);
    }

}
