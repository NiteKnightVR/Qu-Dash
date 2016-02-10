using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

    static string spritePath = "Textures/fire";
    static Sprite[] sprites;
    static int finalSpriteNumber;

    void Start()
    {
        sprites = Resources.LoadAll<Sprite>(spritePath);
        finalSpriteNumber = sprites.Length - 1;
    }

    public static int getFinalSpriteNumber()
    {
        return finalSpriteNumber;
    }

    public static Sprite getSprite(int i)
    {
        return sprites[i];
    }
}
