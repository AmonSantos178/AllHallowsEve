using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Hello! If you're reading this, I'd like to thank you and everyone over at LSW for the amazing opportunity! :)
    #region Variables
    float speed = 15f;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer rndr;
    [SerializeField] GameObject[] costumes;
    int i;

    #endregion

    void Start()
    {
        i = 0;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rndr = GetComponentInChildren<SpriteRenderer>();
        SetAnimatorActive(0);
    }

    void Update()
    {
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

        rndr.sortingOrder = (int)(rndr.transform.position.y * -100);
    }

    void SetAnimatorActive(int index)
    {
        i = 0;
        foreach (GameObject go in costumes)
        {
            if (i == index)
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
        rndr = GetComponentInChildren<SpriteRenderer>();
    }

    public void ProcessTag(string tag)
    {
        switch (tag)
        {
            case "Base": costumes[0].SetActive(true); SetAnimatorActive(0); return;
            case "C1": costumes[1].SetActive(true); SetAnimatorActive(1); return;
            case "C2": costumes[2].SetActive(true); SetAnimatorActive(2); return;
            case "C3": costumes[3].SetActive(true); SetAnimatorActive(3); return;
            case "C4": costumes[4].SetActive(true); SetAnimatorActive(4); return;
            case "C5": costumes[5].SetActive(true); SetAnimatorActive(5); return;
            default: costumes[0].SetActive(true); SetAnimatorActive(0); return;
        }
    }

    public string CheckTag()
    {
        return anim.gameObject.tag;
    }
}
