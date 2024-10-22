using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    float height;
    float width;
    Vector3 position;
    Vector3 velocity;
    [SerializeField]
    public List<GameObject> destroyedBullets;
    [SerializeField]
    public List<GameObject> totalBulletList;
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        position = gameObject.transform.position;
        destroyedBullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        DestroyBullets();
    }
    public void CheckBounds()
    {
        foreach (GameObject bullet in totalBulletList)
        {
            if (bullet.transform.position.x > width)
            {
                destroyedBullets.Add(bullet);
            }
            else if (bullet.transform.position.x < -width)
            {
                destroyedBullets.Add(bullet);
            }
            if (bullet.transform.position.y > height)
            {
                destroyedBullets.Add(bullet);
            }
            else if (bullet.transform.position.y < -height)
            {
                destroyedBullets.Add(bullet);
            }
        }

    }
    public void DestroyBullets()
    {
        if (destroyedBullets.Count > 0)
        {
            for (int i = 0; i < destroyedBullets.Count; i++)
            {
                for (int j = 0; j < totalBulletList.Count; j++)
                {
                    if (destroyedBullets[i].Equals(totalBulletList[j]))
                    {
                        Destroy(totalBulletList[j]);
                        totalBulletList.Remove(destroyedBullets[i]);
                    }
                }
            }
            destroyedBullets.Clear();
        }
    }
}
