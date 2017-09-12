using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public Vector3 targetOffset;

    public float cameraLag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(target);

        Vector3 targetPosition = target.position + targetOffset;

        Vector3 nextPosition = transform.position + (targetPosition - transform.position) * cameraLag;

        transform.position = nextPosition;
	}
}
