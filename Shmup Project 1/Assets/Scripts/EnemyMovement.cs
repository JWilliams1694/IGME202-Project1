using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float height;
    float width;
    Vector3 position;
    Vector3 velocity;
    float randomX;
    float randomY;
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
        randomX = Random.Range(-2f, 2f);
        randomY = Random.Range(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 2f)
        {
            randomX = Random.Range(-4f, 4f);
            randomY = Random.Range(-4f, 4f);
            time = 0;
        }
        if (player.GetComponent<Vehicle>().health > 0)
        {
            velocity = new Vector3(randomX, randomY, 0) * Time.deltaTime;
            position += velocity;
            transform.position = position;
            ScreenWrap();
            time += Time.deltaTime;
        }
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            hitStunColor += Time.deltaTime;
        }
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.red&&hitStunColor>.7)
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
        if (position.y > height-1)
        {
            position.y = height-1;
        }
        else if (position.y < 2)
        {
            position.y = 2;
        }
    }
}
