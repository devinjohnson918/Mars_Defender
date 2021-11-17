using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;

    [SerializeField] int scoreUpdate = 10;

    [SerializeField] int hitPoints = 1;

    GameObject parent;
    Scoreboard scoreboard;

    private void Start()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        scoreboard = FindObjectOfType<Scoreboard>();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
    }

    // Start is called before the first frame update
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints<1) {
            KillEnemy();
        }
        
    }
    void ProcessHit()
    {
        GameObject vfx1 = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx1.transform.parent = parent.transform;
        hitPoints--;
        scoreboard.UpdateScore(scoreUpdate);
    }
    void KillEnemy()
    {
        GameObject vfx2 = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx2.transform.parent = parent.transform;
        Destroy(gameObject, 0.0f);
    }
}
