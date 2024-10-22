using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    Vector3 position;
    Vector3 velocity;
    [SerializeField]
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        velocity = new Vector3(0, -7f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        position += velocity * Time.deltaTime;
        transform.position = position;
        if (player.GetComponent<Vehicle>().health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
