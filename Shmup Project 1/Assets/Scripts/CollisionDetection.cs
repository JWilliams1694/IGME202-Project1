using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    SpriteInfo spriteInfo1;
    SpriteInfo spriteInfo2;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool AABBCollision(GameObject obj1, GameObject obj2)
    {
        spriteInfo1 = obj1.GetComponent<SpriteInfo>();
        spriteInfo2 = obj2.GetComponent<SpriteInfo>();
        if (spriteInfo1.MinX < spriteInfo2.MaxX && spriteInfo1.MaxX > spriteInfo2.MinX && spriteInfo1.MaxY > spriteInfo2.MinY && spriteInfo1.MinY < spriteInfo2.MaxY)
        {
            return true;
        }
        else return false;
    }
    public bool CircleCollision(GameObject obj1, GameObject obj2)
    {
        spriteInfo1 = obj1.GetComponent<SpriteInfo>();
        spriteInfo2 = obj2.GetComponent<SpriteInfo>();
        float distance=spriteInfo1.Position.x - spriteInfo2.Position.x;
        distance = Mathf.Pow(distance, 2);
        distance += Mathf.Pow(spriteInfo1.Position.y - spriteInfo2.Position.y,2);
        distance=Mathf.Sqrt(distance);
        if ((obj1.GetComponent<SpriteInfo>().Radius+ obj2.GetComponent<SpriteInfo>().Radius) > distance) 
        {
            return true;
        }
        else return false;
    }
}
