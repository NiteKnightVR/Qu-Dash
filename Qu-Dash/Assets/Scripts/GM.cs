using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

    public GameObject cube;
    public int lives;
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
        lives = 3;
        cube.transform.position = Vector3.zero;
        menu = false;
    }

	// Update is called once per frame
	void Update () {
	    
	}

    public void Die()
    {
        lives--;
        if (lives == 0)
            Endgame();
        cube.transform.position = Vector3.zero;
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
}
