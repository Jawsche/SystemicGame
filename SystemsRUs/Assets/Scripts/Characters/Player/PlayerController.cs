using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : Character
{
    float input_H;
    float input_V;
    public Vector3 vecToReticule;
    public Reticule reticule;


    void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
        //m_Animator = GetComponent<Animator>();
        isFriendly = true;
        reticule = GameObject.FindGameObjectWithTag("Reticule").GetComponent<Reticule>();
    }


    new void Update()
    {
        vecToReticule = gameObject.transform.position - reticule.transform.position;
        if (!isDead)
        {
            base.Update();
            if (!isDead)
                Move();
            //Animation();
        }
        LookAtMouse();
    }

    void Animation()
    {
        //m_Animator.SetFloat ("HorizSpeed", input_H);
        //m_Animator.SetFloat ("VertSpeed", input_V);
        //m_Animator.SetBool("IsRunning", isRunning);
        //m_Animator.SetBool("isDead", isDead);
    }
    void Move()
    {
        input_H = CrossPlatformInputManager.GetAxis("Horizontal");
        input_V = CrossPlatformInputManager.GetAxis("Vertical");
        if (input_H != 0.0f)
        {
            m_RigidBody.AddForce(Vector3.right * input_H * speed * Time.deltaTime * 500.0f, ForceMode.Impulse);

        }
        if (input_V != 0.0f)
        {
            m_RigidBody.AddForce(Vector3.forward * input_V * speed * Time.deltaTime * 500.0f, ForceMode.Impulse);
        }
        if (input_V == 0.0f && input_H == 0.0f)
        {

        }
    }
    void LookAtMouse()
    {
        transform.LookAt(new Vector3(reticule.pointToLook.x, transform.position.y, reticule.pointToLook.z));

    }
}