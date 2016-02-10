using UnityEngine;
using System.Collections;

public class DeathParticle : MonoBehaviour {

    private float resetDelay = 2f;
	// Use this for initialization
	void Start () {
        Invoke("Kill", resetDelay);
	}
	
    void Kill()
    {
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
