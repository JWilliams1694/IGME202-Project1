using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    float height;
    float width;
    Vector3 position;
    Vector3 velocity;
    float randomX;
    float time = 0;
    [SerializeField]
    GameObject player;
    float hitStunColor;
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        position = transform.position;
        randomX = Random.Range(1,3);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomX == 1)
        {
            velocity = new Vector3(12f, 0, 0) * Time.deltaTime;
        }
        else
        {
            velocity = new Vector3(-12f, 0, 0) * Time.deltaTime;
        }
        if (time > 5f)
        {
            velocity = Vector3.zero;
        }
        if (time > 7f)
        {
            randomX = Random.Range(1, 2);
            time = 0;
        }
        if (player.GetComponent<Vehicle>().health > 0)
        {
            position += velocity;
            transform.position = position;
            ScreenWrap();
            time += Time.deltaTime;
        }
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            hitStunColor += Time.deltaTime;
        }
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.red && hitStunColor > .7)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            hitStunColor = 0;
        }
    }
    public void ScreenWrap()
    {
        if (position.x > width)
        {
            position.x = -width;
        }
        else if (position.x < -width)
        {
            position.x = width;
        }
        if (position.y > height - 1)
        {
            position.y = height - 1;
        }
        else if (position.y < 2)
        {
            position.y = 2;
        }
    }
}
