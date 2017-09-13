using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject sphere;
    public GameObject mainCamera;

    public Transform spawnPoint;

    public float deathY = -500;

    public Text chronoText;

    private SphereControls sphereControls;
    private CameraFollow cameraFollow;

    private GameObject currentSphere;

    private float time = 0;

    private bool goalReached = false;

	// Use this for initialization
	void Start () {
        cameraFollow = mainCamera.GetComponent<CameraFollow>();

        SpawnSphere();
	}

    void SpawnSphere ()
    {
        time = 0;

        currentSphere = Instantiate(sphere);
        currentSphere.transform.position = spawnPoint.position;

        sphereControls = currentSphere.GetComponent<SphereControls>();
        sphereControls.OnGoalReached = OnSphereReachGoal;

        cameraFollow.target = currentSphere.transform;
    }
	
	// Update is called once per frame
	void Update () {

        if (!goalReached)
        {
            time += Time.deltaTime;
        }

        int cents = Mathf.RoundToInt(time * 100) % 100;
        int seconds = Mathf.FloorToInt(time);
        int minutes = Mathf.FloorToInt(time / 60);

        chronoText.text = "Chrono : " + minutes + ":" + seconds + ":" + cents;

        if (currentSphere.transform.position.y < -100)
        {
            Destroy(currentSphere);
            SpawnSphere();
        }
	}

    void OnSphereReachGoal()
    {
        cameraFollow.StopFollow();

        goalReached = true;

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
