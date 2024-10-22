using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> playerBullets;
    [SerializeField]
    List<GameObject> enemies;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bulletManager;
    [SerializeField]
    float healthTimer=3;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip enemyHitSound;
    [SerializeField]
    AudioClip playerHitSound;
    bool type2;
    float hitStun;
    // Start is called before the first frame update
    void Start()
    {
        playerBullets = new List<GameObject>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthTimer += Time.deltaTime;
        playerBullets = player.GetComponent<Fire>().Bullets;
        if (player.GetComponent<SpriteRenderer>().color == Color.red)
        {
            hitStun += Time.deltaTime;
        }
        if (hitStun > 1)
        {
            player.GetComponent<SpriteRenderer>().color = Color.white;
            hitStun =0;
        }
        foreach (GameObject bullet in playerBullets)
        {
            bullet.GetComponent<SpriteRenderer>().color = Color.white;
        }

        foreach (GameObject bullet in playerBullets)
        {
            foreach (GameObject em in enemies)
            {
                if (enemies != null)
                {
                    if (GetComponent<CollisionDetection>().CircleCollision(em, bullet))
                    {
                        bulletManager.GetComponent<DestroyBullet>().destroyedBullets.Add(bullet);
                        if (em.GetComponent<SpriteRenderer>().color != Color.red && player.GetComponent<Vehicle>().health > 0) 
                        {
                            type2 = em.GetComponent<EnemyFire>().enemyType2;
                            if (type2 == false)
                            {
                                player.GetComponent<Vehicle>().score += 10;
                            }
                            else
                            {
                                player.GetComponent<Vehicle>().score += 30;
                            }
                            
                            audioSource.PlayOneShot(enemyHitSound);
                        }
                        em.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }
        }
        foreach (GameObject em in enemies)
        {
            if (em.GetComponent<SpriteRenderer>().color != Color.red)
            {
                em.GetComponent<SpriteRenderer>().color = Color.white;
            }   
        }
        foreach (GameObject em in enemies)
        {
            if (GetComponent<CollisionDetection>().CircleCollision(player, em))
            {
                if (healthTimer > 1)
                {
                    audioSource.PlayOneShot(playerHitSound);
                    if (player.GetComponent<SpriteRenderer>().color != Color.red)
                    {
                        player.GetComponent<Vehicle>().health -= 1;
                    }
                    healthTimer = 0;
                    player.GetComponent<SpriteRenderer>().color = Color.red;
                }
                
            }
        }
        if (bulletManager.GetComponent<EnemyBulletManager>().totalBulletList != null) 
            {
            foreach (GameObject bullet in bulletManager.GetComponent<EnemyBulletManager>().totalBulletList) 
                {
                if (GetComponent<CollisionDetection>().CircleCollision(player, bullet)) 
                    {
                    bulletManager.GetComponent<EnemyBulletManager>().destroyedBullets.Add(bullet);
                    if (player.GetComponent<SpriteRenderer>().color != Color.red)
                    {
                        player.GetComponent<Vehicle>().health -= 1;
                        audioSource.PlayOneShot(playerHitSound);
                    }
                    player.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                } 
            }
        }
    }



