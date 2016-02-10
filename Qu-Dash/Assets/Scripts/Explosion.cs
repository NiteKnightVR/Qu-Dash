using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float spriteSpeed = 1;
    float spriteNumber = 0;

    private int direction = 0;
    public float speed = 1;

    void Start()
    {
        changeDirection();
    }

    void Update()
    {
        continueExplosion();
    }

    void continueExplosion()
    {
        if((int)spriteNumber >= ExplosionController.getFinalSpriteNumber())
        {
            GetComponent<SpriteRenderer>().sprite = null;
            spriteNumber = 0;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ExplosionController.getSprite((int)spriteNumber);
            spriteNumber += spriteSpeed;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        changeDirection();
    }

    void changeDirection()
    {
        Vector3 force;


        if (direction == 0)
        {
            force = new Vector3(0, -1, 0);
            direction = 1;
        }
            
        else
        {
            force = new Vector3(0, 1, 0);
            direction = 0;
        }
            
        GetComponent<Rigidbody>().AddForce(force * speed);
    }
}
