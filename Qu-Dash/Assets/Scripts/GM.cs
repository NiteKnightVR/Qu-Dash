using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    private float time;
    private float resetDelay = 1f;

    public Text timer;
    public GameObject cube;
    public GameObject deathParticles;
    public GameObject go;
    public bool menu;
    public static GM instance;

	// Use this for initialization
	void Start () {
        if (instance == null)   //make sure only 1 instance
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        Setup();
    }

    void Setup()
    {        
        Time.timeScale = 1f;
        time = 0;
        cube.transform.position = Vector3.zero;
        //cube.transform.position = new Vector3(3, -23, 0);
        menu = false;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Endgame();

        time += Time.deltaTime;

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.
        var fraction = (time * 100) % 100;

        //update the label value
        timer.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
    }

    public void Die()
    {
        Instantiate(deathParticles, cube.transform.position, Quaternion.identity);
        Time.timeScale = .25f;
        Invoke("Setup", resetDelay);
    }

    void Endgame()
    {
        menu = true;
    }

    void OnGUI()
    {
        if (menu)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Restart"))
                Setup();
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "Exit"))
                Application.Quit();
        }
    }

    public void nextLevel()
    {
        int level = Application.loadedLevel;
        Application.LoadLevel(++level);
    }
}
