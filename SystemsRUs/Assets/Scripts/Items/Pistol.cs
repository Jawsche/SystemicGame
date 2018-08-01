using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Pistol : Weapon {

    public Projectile bulletPrefab = new Projectile();
    public GameObject emitPoint;
    Rigidbody bulletPrefabRB;
    public float ProjectileSpeed = 250.0f;
    public bool playerUsed = false;

    // Use this for initialization
    void Start () {
        //Pistol Stats
        /*Damage = 34.0f;
        atkRate = 0.2f;
        nextAtk = 0.0f;
        concQuote = 1.0f;
        Range = 1000.0f;
        spread = 0.0f;
        penetrates = false;
        explodes = false;
        playerHeld = true;*/
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        reticule = GameObject.FindGameObjectWithTag("Reticule").GetComponent<Reticule>();



        camShake = Camera.main.GetComponent<CameraShake>();
        bulletPrefabRB = bulletPrefab.GetComponent<Rigidbody>();
        if (transform.root.gameObject == thePlayer)
            playerUsed = true;
        if (playerUsed)
            lookTarget = reticule.gameObject;
        else
            lookTarget = thePlayer;
    }
	
	// Update is called once per frame
	void Update () {
        
        vecTovecToTrg = emitPoint.transform.position - lookTarget.transform.position;
        if (transform.root.gameObject.GetComponent<Character>().isDead)
            gameObject.SetActive(false);

    }

    

    void makeProjectile(Vector3 source, GameObject gun)
    {
        //Pass projectile the Weapon stats it needs
        bulletPrefab.Damage = Damage;
        bulletPrefab.projSpeed = ProjectileSpeed;
        bulletPrefab.concForce = concQuote;
        bulletPrefab.vecToReticule = vecTovecToTrg;

        Rigidbody RB;
        RB = Instantiate(bulletPrefabRB, source, emitPoint.transform.rotation) as Rigidbody;
    }



    public void Fire()
    {
        if (Time.time > nextAtk)
        {
            makeProjectile(emitPoint.transform.position, gameObject);
            nextAtk = Time.time + atkRate;
            camShake.Shake(camShakeAmt, camShakeLength);
        }
    }

}
