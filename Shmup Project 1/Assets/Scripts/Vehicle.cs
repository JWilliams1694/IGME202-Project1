using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    float speed=0f;
    [SerializeField]
    private Camera cam;
    Vector3 vehiclePosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    float height;
    float width;
    [SerializeField]
    List<Sprite> sprites;
    SpriteRenderer spriteRenderer;
    public int health=4;
    public int score;
    Animator animator;
    [SerializeField]
    GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        //starts vehicle where placed, not center
        vehiclePosition = transform.position;
        //sets camera size
        height = cam.orthographicSize;
        width = height * cam.aspect;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocity is  direction * speed * Time.deltaTime
        velocity = direction * speed * Time.deltaTime; 

        //add velocity to position
        vehiclePosition+= velocity;

        //checks for screen wrap
        ScreenWrap();

        //draw this vehicle at that position
        transform.position = vehiclePosition;
        explosion.transform.position = vehiclePosition;
        if (health == 0)
        {
            explosion.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        { explosion.GetComponent<SpriteRenderer>().enabled = false; }

       if (health == 4)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (health == 3)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (health == 2)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (health == 1)
        {
            spriteRenderer.sprite = sprites[3];
        }
       else if (health <= 0)
        {
            //GetComponent<SpriteRenderer>().enabled = false;
        }
        if (health < 0)
            {
                health = 0;
            }
       if (health <= 0)
        {
            speed = 0;
        }

    }

    //method called by other script
    public void OnMove(InputAction.CallbackContext context)
    {
        if (health > 0)
        {
            direction = context.ReadValue<Vector2>();
        }
        
        
    }
    public void ScreenWrap()
    {
        if (vehiclePosition.x > width)
        {
            vehiclePosition.x = width;
        }
        else if (vehiclePosition.x < -width)
        {
            vehiclePosition.x = -width;
        }
        if (vehiclePosition.y > height-1)
        {
            vehiclePosition.y = height-1;
        }
        else if (vehiclePosition.y < -height)
        {
            vehiclePosition.y = -height;
        }
    }
}
