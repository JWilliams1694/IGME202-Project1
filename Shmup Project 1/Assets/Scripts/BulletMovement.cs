using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Vector3 position;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        velocity = new Vector3(0, 10f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        position += velocity*Time.deltaTime;
        transform.position = position;
    }
}
