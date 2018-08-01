using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour{

    public float MaxHealth = 100.0f;
    public float Health = 100.0f;
    public float speed = 5.0f;
    public bool isFriendly = false;
    public bool isDead = false;

    public Rigidbody m_RigidBody;
    public Collider m_Collider;
    public GameObject bodyPrefab;

    public void Update()
    {
        if (Health <= 0.0f)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        m_Collider.enabled = false;
    }
    public void TakeDamage(float dmgValue)
    {
        Health -= dmgValue;
    }

 
}
