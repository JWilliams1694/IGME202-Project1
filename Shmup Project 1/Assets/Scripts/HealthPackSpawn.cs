using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawn : MonoBehaviour
{
    float height;
    float width;
    Vector3 velocity;
    float randomX;
    [SerializeField]
    float time = 0;
    [SerializeField]
    GameObject healthPack;
    Vector3 spawnPosition;
    [SerializeField]
    GameObject player;
    public GameObject Player
    {
        get { return player; }
    }
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        randomX = Random.Range(-width+.5f, width-.5f);
        spawnPosition = new Vector3(randomX, 9, 0);
        time += Time.deltaTime;

        if (time > 15 && player.GetComponent<Vehicle>().health > 0) 
        {
            GameObject temp= Instantiate(healthPack, spawnPosition, Quaternion.identity);
            temp.GetComponent<HealthMovement>().Player = player;
            time = 0;  
        }
        
    }
}
