using System;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static event Action BurgerPickedUp = delegate { };
    public static event Action CarrotPickedUp = delegate { };

    Rigidbody2D rb;
    public GameObject weapon;
    public LayerMask groundLayer;
    public Animator anim;
    bool isGrounded;
    HelperScript helper;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       groundLayer = LayerMask.GetMask("Ground");
       helper = gameObject.AddComponent<HelperScript>();
    }

    void Update()
    {
        float xvel, yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;
        anim.SetBool("isRunning", false);

        if (Input.GetKey("a"))                  //Increases velocity to move Left
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                xvel = -6;
                anim.SetBool("isRunning", true);
            }
            else
            {
                xvel = -3;
            }
        }

        if (Input.GetKey("d"))                  //Increases velocity to move Right
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                xvel = 6;
                anim.SetBool("isRunning", true);
            }
            else
            {
                xvel = 3;
            }
        }


        if (((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown("w")))))     //Increases velocity to move upward (Jump) if sprite is touching a box collider
        {
            if (isGrounded)
            {
                yvel = 8;
            }
        }

        if (xvel > 0.1f)
        {
            helper.DoFlipObject(true);
        }

        if (xvel < -0.1f)
        {
            helper.DoFlipObject(false);
        }

        if(xvel >= 0.1f || xvel <= -0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

            rb.linearVelocity = new Vector2(xvel, yvel);  //Tells the rigid body to move based on given velocity

        GroundCheck();
        // Shoot();
    }

    void GroundCheck()
    {
        isGrounded = DoRayCollisionCheck();
    }

    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.5f;


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
        }

        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        return hit.collider;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Consumable"))
        {
            BurgerPickedUp();
            Destroy(collision.gameObject);
        }
    }

    /* void Shoot()
    {
        if (Input.GetKeyDown("r"))
        {
            GameObject clone;
            clone = Instantiate(weapon, transform.position, transform.rotation);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            rb.linearVelocity = transform.right * 15;

            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1);
        }
    }
     */


    //Shoot a projectile

}
