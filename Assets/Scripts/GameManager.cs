using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject sphere;
    public GameObject mainCamera;

    private SphereControls sphereControls;
    private CameraFollow cameraFollow;

	// Use this for initialization
	void Start () {
        sphereControls = sphere.GetComponent<SphereControls>();
        cameraFollow = mainCamera.GetComponent<CameraFollow>();

        sphereControls.OnGoalReached = OnSphereReachGoal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSphereReachGoal()
    {
        cameraFollow.StopFollow();
    }
}
