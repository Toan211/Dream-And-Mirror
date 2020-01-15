using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    public Vector2 m_Velociy { get; set; }
    public Animator m_Animator;
    Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        doAnimation();
    }

    private void FixedUpdate()
    {   
        //Because of using a rigidbody, doMovement should put into FixxedUpdate
        doMovement();
    }

    void doMovement()
    {
        if(this.transform.localScale.x > 0) //Facing right
        {
            if(m_Velociy.x < 0) //Turn left
            {
                Vector3 flipedScale = transform.localScale;
                flipedScale.x *= -1;

                this.transform.localScale = flipedScale;
            }
        }
        else if (this.transform.localScale.x < 0) //Facing left
        {
            if (m_Velociy.x > 0) //Turn right
            {
                Vector3 flipedScale = transform.localScale;
                flipedScale.x *= -1;

                this.transform.localScale = flipedScale;
            }
        }

        m_Rigidbody.MovePosition(this.m_Rigidbody.position + m_Velociy * Time.fixedDeltaTime);
    }

    void doAnimation()
    {
        if (m_Animator != null)
        {
            m_Animator.SetFloat("xSpeed", m_Velociy.magnitude);
        }
    }
}
