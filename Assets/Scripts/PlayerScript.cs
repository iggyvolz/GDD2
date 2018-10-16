using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float moveMag;
    public float jumpMag;

    //private Vector3 myVelocity;
    private int jumpsLeft;
    private float score;

	// Use this for initialization
	void Start ()
    {
        jumpsLeft = 2;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        score += Time.deltaTime;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, GetComponent<Rigidbody>().velocity.y, 0.0f);

        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(1f, 0.0f, -1f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(-1f, 0.0f, 1f);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(1f, 0.0f, 1f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(-1f, 0.0f, -1f);
        }
        GetComponent<Rigidbody>().velocity = new Vector3(
            GetComponent<Rigidbody>().velocity.normalized.x * moveMag * Time.deltaTime,
            GetComponent<Rigidbody>().velocity.y,
            GetComponent<Rigidbody>().velocity.normalized.z * moveMag * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpMag, GetComponent<Rigidbody>().velocity.z);
            jumpsLeft--;
        }
	}

    public void AddScore(int deltaScore)
    {
        if (deltaScore < 0)
        {
            deltaScore *= -1;
        }
        score += deltaScore;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0.0f, GetComponent<Rigidbody>().velocity.z);
            jumpsLeft = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Hazard"))
        {
            gameObject.SetActive(false);
        }
    }
}
