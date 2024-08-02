using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] public Animator animation;

    void Update()
    {
       
    }
    private void FixedUpdate()
    {   /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var sprite = GetComponent<SpriteRenderer>();
        if (moveHorizontal > 0)
        {
            animation.SetBool("isWalk", true);
            sprite.flipX = false;
        }else if(moveHorizontal < 0)
        {
            animation.SetBool("isWalk", true);
            sprite.flipX = true;
        }
        else
        {
            animation.SetBool("isWalk", false);
        }
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        */
        Vector3 movement = new Vector3(1f, 0.0f, 0f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        animation.SetBool("isWalk", true);
    }
}
