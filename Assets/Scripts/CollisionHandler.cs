using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
  
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem explosion;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.name + " triggered " + other.gameObject.name);
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        explosion.Play();
        foreach (MeshRenderer r in GetComponentsInChildren<MeshRenderer>())
        {
            r.enabled = false;
        }
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
