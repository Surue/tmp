using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

    float timeToLive = 3;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(50,0));
	}
	
	// Update is called once per frame
	void Update () {
        timeToLive -= Time.deltaTime;

        if(timeToLive <= 0)
        {
            Destroy(gameObject);
        }
	}
}
