using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{

    LayerMask playerLayerMask;
    LayerMask areaLayerMask;
    Rigidbody2D rb;
    Vector2 vel;
    HelperScript helper;
    
    void Start()
    {
        areaLayerMask = LayerMask.GetMask("area");
        rb = GetComponent<Rigidbody2D>();
        helper = gameObject.AddComponent<HelperScript>();

        vel.x = -5;

    }

    // Update is called once per frame
    void Update()
    {

        if (vel.x > 2f)
        {
            helper.DoFlipObject(false);

            if (ExtendedRayCollisionCheck(0, 0.3f) == false)
            {
                vel.x = -5;
            }
        }
        else
        {
            if (vel.x < 2f)
            {
                helper.DoFlipObject(true);


                if (ExtendedRayCollisionCheck(-0.3f, 0) == false)
                {
                    vel.x = 5;
                }
            }
        }

        rb.linearVelocity = vel;
    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, areaLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }
}
