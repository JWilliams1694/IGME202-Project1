using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    Vector3 position;
    float height;
    float width;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    List<GameObject> enemyBullets;
    [SerializeField]
    GameObject bulletManager;
    float time = 0;
    [SerializeField]
    float time2 = 0;
    float soundTimer;
    public bool enemyType2;
    [SerializeField]
    GameObject player;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip enemyFireSound1;
    [SerializeField]
    AudioClip enemyFireSound2;
    public List<GameObject> Bullets
    {
        get { return enemyBullets; }
        set { enemyBullets = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        position = enemy.transform.position;
        time += Time.deltaTime;
        time2 += Time.deltaTime;
        soundTimer += Time.deltaTime;

        if (time > 2.5 && enemyType2 == false && player.GetComponent<Vehicle>().health > 0) 
        {
            time = 0;
            audioSource.PlayOneShot(enemyFireSound1);
            Fire();
        }
        if (soundTimer > 5 && player.GetComponent<Vehicle>().health > 0) 
        {
            audioSource.PlayOneShot(enemyFireSound2,.2f);
            soundTimer = 0;
        }
        if (enemyType2 == true && time2 > 5 && time2 < 5.3 && player.GetComponent<Vehicle>().health > 0) 
        {
            Fire();  
        }
        if (time2 > 5.3)
        {
            time2 = 0;
            soundTimer = 0;
        }
    }
    public void Fire()
    {
        GameObject tempBullet = Instantiate(bullet, position, Quaternion.identity);
        bulletManager.GetComponent<EnemyBulletManager>().totalBulletList.Add(tempBullet);
    }
}
