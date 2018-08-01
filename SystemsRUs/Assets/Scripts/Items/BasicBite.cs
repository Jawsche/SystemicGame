using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBite : Weapon {

    public List<GameObject> targets;
    public bool playerUsed = false;

    // Use this for initialization
    void Start () {
        thePlayer = GameObject.FindGameObjectWithTag("Player"); 
        reticule = GameObject.FindGameObjectWithTag("Reticule").GetComponent<Reticule>();
        AudioSrc = GetComponent<AudioSource>();
        camShake = Camera.main.GetComponent<CameraShake>();
        if (transform.root.gameObject == thePlayer)
            playerUsed = true;
        if (playerUsed)
            lookTarget = reticule.gameObject;
        else
            lookTarget = thePlayer;
    }
	
	// Update is called once per frame
	void Update () {
        vecTovecToTrg = transform.position - lookTarget.transform.position;
        if (transform.root.gameObject.GetComponent<Character>().isDead)
            gameObject.SetActive(false);
    }

    public void Fire()
    {

        if (Time.time > nextAtk)
        {
            nextAtk = Time.time + atkRate;
            camShake.Shake(camShakeAmt, camShakeLength);
            AudioSrc.Play();

            for (int i = 0; i < targets.Count; i++)
            {
                if (targets.Count > 0)
                {
                    if (targets[i].tag == "Player" || targets[i].tag == "NPC")
                    {
                        if (targets[i].GetComponent<Character>().isDead == false)
                            targets[i].GetComponent<Character>().TakeDamage(Damage);

                    }
                    if (targets[i].GetComponent<Rigidbody>() != null)
                        targets[i].GetComponent<Rigidbody>().AddForce(vecTovecToTrg.normalized * concQuote * -500.0f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "NPC")
        {
            targets.Add(collision.gameObject);
      

        }

        
        
    }
    private void OnTriggerExit(Collider collision)
    {
       
        targets.Remove(collision.gameObject);

    }
    
 
}
