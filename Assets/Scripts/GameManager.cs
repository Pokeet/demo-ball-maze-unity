using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject sphere;
    public GameObject mainCamera;

    public Transform spawnPoint;

    public float deathY = -500;

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
        if (currentSphere.transform.position.y < -100)
        {
            Destroy(currentSphere);
            SpawnSphere();
        }
	}

    void OnSphereReachGoal()
    {
        cameraFollow.StopFollow();

        Invoke("LoadNextLevel", 2);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);

        if (nextScene != null)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
