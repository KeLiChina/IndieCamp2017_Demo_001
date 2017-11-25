using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RoleBase
{

    // protected override void Update()
    // {
    //     base.Update();
    //     M_Vec = Vector2.zero;
       

    // }
    public Transform groundCheck;
    private bool grounded=true;
    private bool jump = false;
    public float maxSpeed;
    public float moveForce;
    public float jumpForce;
    protected override void Update()
    {
		base.Update();
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetKeyDown(KeyCode.Space)&& grounded)
		{
			 jump = true;
		}
		 if (Input.GetKey(KeyCode.A))
        {
            Walk();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Walk();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            // Idle();
        }
           
    }


    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        m_Animator.SetFloat("Speed", Mathf.Abs(h));

        if (h * m_Rigidbody.velocity.x < maxSpeed)
		{
			m_Rigidbody.AddForce(Vector2.right * h * moveForce);
		}
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
		{
			  m_Rigidbody.velocity = new Vector2(Mathf.Sign(m_Rigidbody.velocity.x) * maxSpeed, m_Rigidbody.velocity.y);
		}
     
        if (jump)
        {
            m_Rigidbody.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

}
