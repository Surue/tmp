using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed = 2;
    [SerializeField]
    float maxSpeed = 8;
    [SerializeField]
    GameObject prefabBubble;

    float acceleraction = 6;
    float timeToFire = 0.0f;

    Rigidbody2D body;

    bool lookingRight = true;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();

        if(prefabBubble == null)
        {
            Debug.LogError("Bubble prefab is missing");
        }
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        if(horizontalSpeed != 0)
        {
            if(Mathf.Abs(body.velocity.x) < maxSpeed)
            {
                body.AddForce(new Vector2((horizontalSpeed / Mathf.Abs(horizontalSpeed)) * maxSpeed,body.velocity.y));
            }
            else
            {
                body.velocity = new Vector2(body.velocity.x,body.velocity.y);
            }
        }
        else
        {
            body.velocity = new Vector2(0,body.velocity.y);
        }

        if(Input.GetButtonDown("Jump"))
        {
            body.velocity =new Vector2(body.velocity.x, acceleraction);
        }

        //Flip player
        if(body.velocity.x > 0)
        {
            if(!lookingRight)
            {
                Flip();
            }
        }
        else
        {
            if(lookingRight)
            {
                Flip();
            }
        }

        if(Input.GetButtonDown("Fire1") && timeToFire <= 0)
        {
            timeToFire = 1;
            if(lookingRight)
            {
                Instantiate(prefabBubble,transform.position + new Vector3(1.2f,0,0),transform.rotation);
            }
            else
            {
                Instantiate(prefabBubble,transform.position + new Vector3(-1.2f,0,0),transform.rotation);
            }
        }

        if(timeToFire > 0)
        {
            timeToFire -= Time.deltaTime;
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        lookingRight = !lookingRight;
    }
}
