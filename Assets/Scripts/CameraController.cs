using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    PlayerController player;
    
    public float smoothTime = 0.125f;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        player = GameObject.FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetPosition = player.transform.position;
        targetPosition.z = -10;
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smoothTime);
    }
}
