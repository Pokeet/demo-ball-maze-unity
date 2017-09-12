using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject sphere;
    public GameObject mainCamera;

    public Transform spawnPoint;

    private SphereControls sphereControls;
    private CameraFollow cameraFollow;

    private GameObject currentSphere;

	// Use this for initialization
	void Start () {
        cameraFollow = mainCamera.GetComponent<CameraFollow>();

        SpawnSphere();
	}

    void SpawnSphere ()
    {
        currentSphere = Instantiate(sphere);
        currentSphere.transform.position = spawnPoint.position;

        sphereControls = currentSphere.GetComponent<SphereControls>();
        sphereControls.OnGoalReached = OnSphereReachGoal;

        cameraFollow.target = currentSphere.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSphereReachGoal()
    {
        cameraFollow.StopFollow();
    }
}
