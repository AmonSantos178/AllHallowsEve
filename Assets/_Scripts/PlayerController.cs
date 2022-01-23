using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Hello! If you're reading this, I'd like to thank you and everyone over at LSW for the amazing opportunity! :)
    #region Variables
    float speed = 15f;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer renderer;
    [SerializeField] GameObject[] costumes;
    int i;

    #endregion

    void Start()
    {
        i = 0;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
        SetAnimatorActive(-1);
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

        renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
    }

    public void SetAnimatorActive(int index)
    {
        Debug.Log("aa");
        i = 0;
        foreach (GameObject go in costumes)
        {
            if (i == index + 1)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
            i++;
        }
        anim = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }
}
