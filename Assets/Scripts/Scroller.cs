using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private Rigidbody2D RIGIDBODY;
    private float m_Speed = 1.5f;

    void Start()
    {
        RIGIDBODY = GetComponent<Rigidbody2D>();
        RIGIDBODY.velocity = new Vector2(-m_Speed , m_Speed);

    }

    // Update is called once per frame
    void Update()
    {

        if (RIGIDBODY.position.x <= -9)
            RIGIDBODY.velocity = new Vector2(m_Speed, m_Speed);
        else if (RIGIDBODY.position.x >= 9)
            RIGIDBODY.velocity = new Vector2(-m_Speed, m_Speed);        
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
