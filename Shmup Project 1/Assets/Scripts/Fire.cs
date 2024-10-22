using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Fire : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector3 position;
    [SerializeField]
    float height;
    float width;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    List<GameObject> bullets;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip playerShootSound;

    float time=0;

     public List<GameObject> Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        position = player.transform.position;
        time += Time.deltaTime;
    }

    public void OnClick()
    {
        if (time >= .5f&& player.GetComponent<Vehicle>().health>0)
        {
            audioSource.PlayOneShot(playerShootSound);
            bullets.Add(Instantiate(bullet, position, Quaternion.identity));
            time = 0;
        }
        
    }
}
