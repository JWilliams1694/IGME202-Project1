using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMovement : MonoBehaviour
{
    float height;
    float width;
    Vector3 position;
    Vector3 velocity;
    [SerializeField]
    GameObject player;
    AudioSource audioSource;
    [SerializeField]
    AudioClip healSound;
    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
        position = gameObject.transform.position;
        velocity = new Vector3(0, -5f, 0);
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        position += velocity * Time.deltaTime;
        transform.position = position;

        if (GetComponent<CollisionDetection>().CircleCollision(gameObject, player))
        {
            audioSource.PlayOneShot(healSound);
            Destroy(gameObject);
            if (player.GetComponent<Vehicle>().health < 4)
            {
                player.GetComponent<Vehicle>().health += 1;
            }


        }
        if (gameObject.transform.position.y < -height)
        {
            Destroy(gameObject);
        }
        if (player.GetComponent<Vehicle>().health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
