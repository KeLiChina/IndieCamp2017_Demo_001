using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
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

    private Vector2 m_Vec = Vector2.zero;
    private Vector3 Temp_WalkDis = Vector3.zero;
    protected Rigidbody2D m_Rigidbody;
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
    public virtual void Walk()
    {
       
        if (m_Status != RoleStatus.Jump)
            m_Status = RoleStatus.Move;
        Temp_WalkDis = transform.position;
        m_Animator.SetBool("Move",true);
        m_Animator.SetBool("Jump",false);
         m_Animator.SetBool("Idle",false);
     
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
        if ( Input.GetAxis("Horizontal") == 0)
        {
            return;
        }
        else if ( Input.GetAxis("Horizontal") > 0)
        {
            m_SpRender.flipX = false;
        }
        else if ( Input.GetAxis("Horizontal") < 0)
        {
            m_SpRender.flipX = true;
        }
    }
}
