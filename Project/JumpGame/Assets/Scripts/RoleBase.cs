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
	[HideInInspector]
    public float speed = 0;
    private float dic = 1;
    private Vector3 Temp_WalkDis = Vector3.zero;
    private Rigidbody2D m_Rigidbody;
	private Animator m_Animator;

    public float M_Dic
    {
        get { return dic; }
        set { dic = value; }
    }
    public RoleStatus M_Status
    {
        get { return m_Status; }
        set { m_Status = value; }
    }
    protected virtual void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Animator = GetComponentInChildren<Animator>();
    }
    protected virtual void Start()
    {

    }


    protected virtual void Update()
    {
        Idle();
    }
    // update
    public virtual void Walk()
    {
		float temp = 0.1f;
        if (m_Status != RoleStatus.Jump)
            m_Status = RoleStatus.Move;
		Temp_WalkDis = transform.position;
		m_Animator.SetTrigger("Move");
        float drive = (dic * speed*temp) + transform.position.x;
        Temp_WalkDis.x = drive;
        transform.position = Temp_WalkDis;
    }
    // trigger
    public virtual void Jump()
    {
        if (m_Status == RoleStatus.Jump)
            return;
		m_Animator.SetTrigger("Jump");
        m_Status = RoleStatus.Jump;
        m_Rigidbody.AddForce(new Vector2(0, 1));
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        m_Status = RoleStatus.Idle;
    }
	// update
	public virtual void Idle()
	{
		if (m_Status != RoleStatus.Jump || speed != 0)
            m_Status = RoleStatus.Idle;
		m_Animator.SetTrigger("Idle");
	}
	public virtual void Flip()
	{
		if (M_Dic == 1)
		{

		}
		else if (M_Dic == -1)
		{
			
		}
	}
}
