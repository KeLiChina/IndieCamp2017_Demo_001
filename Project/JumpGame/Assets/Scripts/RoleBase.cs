using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoleStatus
{
    NULL = -1,
    Idle = 0,
    Move = 1,
    Jump = 2,
    SIZE
}
public class RoleBase : MonoBehaviour
{
    [HideInInspector]
    public RoleStatus m_Status;
    public SpriteRenderer m_SpRender;

    public float speed = 0;
    private Vector2 m_Vec = Vector2.zero;
    private Vector3 Temp_WalkDis = Vector3.zero;
    private Rigidbody2D m_Rigidbody;
    public Animator m_Animator;

    public Vector2 M_Vec
    {
        get { return m_Vec; }
        set { m_Vec = value; }
    }
    public RoleStatus M_Status
    {
        get { return m_Status; }
        set { m_Status = value; }
    }
    protected virtual void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

    }
    protected virtual void Start()
    {

    }


    protected virtual void Update()
    {
        
        Flip();
    }
    // update
    public virtual void Walk(Vector2 vec)
    {
        float temp = 0.1f;
        if (m_Status != RoleStatus.Jump)
            m_Status = RoleStatus.Move;
        Temp_WalkDis = transform.position;
        m_Animator.SetBool("Move",true);
        m_Animator.SetBool("Jump",false);
         m_Animator.SetBool("Idle",false);
        vec = vec.normalized;

        if (m_Rigidbody != null)
        {
            m_Rigidbody.MovePosition(transform.position + (Vector3)vec * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate((Vector3)vec * Time.deltaTime * speed);
        }

        transform.position = Temp_WalkDis;
    }
    // trigger
    public virtual void Jump()
    {
        if (m_Status == RoleStatus.Jump)
            return;
        m_Animator.SetBool("Jump",true);
         m_Animator.SetBool("Move",false);
         m_Animator.SetBool("Idle",false);
        m_Status = RoleStatus.Jump;
        m_Rigidbody.AddForce(new Vector2(0, 1) * 600);
        Debug.Log("Is Jump");
    }
    protected virtual void  OnCollisionEnter2D(Collision2D coll) 
    {
        Idle();
       Debug.Log("Trigger Enter "+ coll.gameObject.name);
    }
    // update
    public virtual void Idle()
    {
     
            m_Animator.SetBool("Idle",true);
        m_Animator.SetBool("Jump",false);
           m_Animator.SetBool("Move",false);
            m_Status = RoleStatus.Idle;
        


    }
    public virtual void Flip()
    {
        if (m_Vec.x == 0)
        {
            return;
        }
        else if (m_Vec.x > 0)
        {
            m_SpRender.flipX = false;
        }
        else if (m_Vec.x < 0)
        {
            m_SpRender.flipX = true;
        }
    }
}
