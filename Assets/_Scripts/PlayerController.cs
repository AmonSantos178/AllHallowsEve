using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Hello! If you're reading this, I'd like to thank you and everyone over at LSW for the amazing opportunity! :)
    #region Variables
    float speed = 15f;
    Animator anim;
    Rigidbody2D rb;

    #endregion

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Here, i've separately programmed each key, as to avoid diagonal movement so that the animation matches    
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0, speed, 0);
            anim.SetInteger("Direction", 2);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0, -speed, 0);
            anim.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, 0, 0);
            anim.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, 0);
            anim.SetInteger("Direction", 4);

        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            anim.SetInteger("Direction", 0);
        }
    }
}
