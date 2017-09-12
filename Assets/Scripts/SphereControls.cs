using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControls : MonoBehaviour {

    public float inputStrength = 10.0f;
    public float jumpStrength = 500.0f;
    public float finalJumpStrength = 5000;

    public delegate void OnGoalReachedDelegate();
    public OnGoalReachedDelegate OnGoalReached;

    private Rigidbody body;

    private float xInput;
    private float yInput;

    private bool isPressingJump;

    private bool isOnGround;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");

        isPressingJump = (Input.GetButton("Jump"));
    }

    private void FixedUpdate()
    {
        body.AddForce(Vector3.forward * inputStrength * yInput);
        body.AddForce(Vector3.right * inputStrength * xInput);

        if (isPressingJump && isOnGround)
        {
            body.AddForce(Vector3.up * jumpStrength);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("goal"))
        {
            body.AddForce(Vector3.up * finalJumpStrength);

            if (OnGoalReached != null)
            {
                OnGoalReached();
            }
        }
    }
}
