using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float walk_speed = 5.0f;
    public healthBarScript healthBar;


    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float move_Vert = Input.GetAxis("Vertical");

        if (move < 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * walk_speed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * walk_speed, GetComponent<Rigidbody2D>().velocity.y);

        if (move_Vert < 0) GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, move_Vert * walk_speed);
        if (move_Vert > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, move_Vert * walk_speed);
    }
}
