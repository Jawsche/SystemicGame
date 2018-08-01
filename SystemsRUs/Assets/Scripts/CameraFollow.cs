using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject Player;
    public float distance;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        distance = gameObject.transform.position.y - Player.transform.position.y;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 temp;
        temp = Player.transform.position;
        temp.y = Player.transform.position.y + distance;
        transform.position = temp;
	}
}
