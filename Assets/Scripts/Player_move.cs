using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player_move : MonoBehaviour
{
    public float walk_speed = 5.0f;
    public healthBarScript healthBar;

    float lockPos = 0;

    public Rigidbody2D bubble;
    public Rigidbody2D arrow;
    private Rigidbody2D player;

   

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 dir;

        dir = bubble.position - player.position;
        dir.Normalize();


        player.freezeRotation = true;
        arrow.position = player.position + dir * 5.0f;
        arrow.velocity = new Vector2(0.0f, 0.0f);

        if(player.position.x - arrow.position.x > 0)
            arrow.rotation = Vector2.Angle(transform.up, dir) + 90;
        else
            arrow.rotation = Vector2.Angle(-transform.up, dir) - 90;

        Debug.Log(arrow.rotation);


        float move = Input.GetAxis("Horizontal");
        float move_Vert = Input.GetAxis("Vertical");

        if (move < 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * walk_speed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * walk_speed, GetComponent<Rigidbody2D>().velocity.y);

        if (move_Vert < 0) GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, move_Vert * walk_speed);
        if (move_Vert > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, move_Vert * walk_speed);

        if(GetComponent<Rigidbody2D>().position.y>400.0f)
        {
            SceneManager.LoadScene(2);
        }

    }

    public void disableArrow()
    {
        arrow.GetComponentInParent<SpriteRenderer>().enabled = false;
    }

    public void enableArrow()
    {
        arrow.GetComponentInParent<SpriteRenderer>().enabled = true;
    }
}
