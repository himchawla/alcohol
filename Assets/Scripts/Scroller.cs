using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private Rigidbody2D RIGIDBODY;
    private Vector2 m_Speed = new Vector2(-1.5f,1.5f);

    void Start()
    {
        RIGIDBODY = GetComponent<Rigidbody2D>();
        RIGIDBODY.velocity = m_Speed;

    }

    // Update is called once per frame
    void Update()
    {

      //  float timer = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManagerScript>.getTimer();

        if (RIGIDBODY.position.x <= -9)
            m_Speed.x = 1.5f;
        else if (RIGIDBODY.position.x >= 9)
            m_Speed.x = -1.5f;

        RIGIDBODY.velocity = m_Speed;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManagerScript>().setInside(true);
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManagerScript>().setInside(true);

    }

    void OnTriggerExit2D(Collider2D col)
    {
        GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManagerScript>().setInside(false);
    }
    
}
