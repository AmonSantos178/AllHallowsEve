using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Hello! If you're reading this, I'd like to thank you and everyone over at LSW for the amazing opportunity! :)
    #region Variables
    float speed = 10f;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer rndr;
    [SerializeField] GameObject[] costumes;
    Vector2 movement;
    int i;
    public bool canMove = true;
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
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                movement.y = 0;
            }
            else
            {
                movement.x = 0;
            }

            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }
        rndr.sortingOrder = (int)(rndr.transform.position.y * -100);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
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

    public void ProcessTag(int tag)
    {
        costumes[tag].SetActive(true); SetAnimatorActive(tag);
    }

    public string CheckTag()
    {
        return anim.gameObject.tag;
    }
    public bool GetWalking()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
