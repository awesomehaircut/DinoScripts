using UnityEngine;

public class Jump : MonoBehaviour
{

    public float JumpForce;
    public float JumpTime;
    public float JumpTimeCounter;
    public bool Grounded; // whether you are on the ground or not
    public bool StoppedJumping; // lets us track when the player stops jumping.*/
    public Transform GroundCheck;
    public Rigidbody Rb; //Rigidbody to apply forces for jumping

    void Start()
    {
        //sets the jumpCounter to whatever we set our jumptime to in the editor
        JumpTimeCounter = JumpTime;
    }

    void Update()
    {
        Grounded = GroundCheck.position.y < 4f;
        var resetPos = new Vector3(Rb.position.x, Rb.position.y, 0);

        if (Grounded)
        {
            Rb.position = resetPos;
            Rb.rotation = Quaternion.Euler(0, 90, 0);// reset rotation when touching ground
            JumpTimeCounter = JumpTime;
        }
    }

    void FixedUpdate()
    {
        //FixedUpdate because using phyics to move.

        //use any key to jump
        if (Input.GetMouseButtonDown(0))
        {
            if (Grounded)
            {
                Rb.rotation = Quaternion.Euler(0, 90, 0);
                //jump!
                Rb.velocity = new Vector3(Rb.velocity.x, JumpForce, 0);
                StoppedJumping = false;
            }

            if (JumpTimeCounter > 0)
            {
                //keep jumping!
                Rb.velocity = new Vector3(Rb.velocity.x, JumpForce, 0);
            }
            JumpTimeCounter -= Time.deltaTime;
        }

        if (StoppedJumping)
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the
            //update function.
            JumpTimeCounter = 0;
            StoppedJumping = true;
        }
    }
}
