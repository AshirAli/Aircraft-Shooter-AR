using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MissileControl : MonoBehaviour
{
    AudioManager AudioManager;


    void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        GameObject KC = GameObject.Find("KillCount");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CameraBound")
        {
            Destroy(gameObject);
            print("BoundHit");
        }
        
        if(other.gameObject.tag == "Enemy")
        {
            GameObject explosion = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = other.transform.position;
            print("EnemyHit");
            AudioManager.PlaySound("Explosion");
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManager.KillCount++;
            Destroy(explosion, 2);
        }
    }
}
