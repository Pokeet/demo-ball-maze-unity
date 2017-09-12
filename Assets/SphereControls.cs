using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControls : MonoBehaviour {

    public float inputStrength = 10.0f;
    public float jumpStrength = 500.0f;

    private Rigidbody body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        body.AddForce(Vector3.forward * inputStrength * verticalInput);
        body.AddForce(Vector3.right * inputStrength * horizontalInput);

        if (Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector3.up * jumpStrength);
        }

    }
}
