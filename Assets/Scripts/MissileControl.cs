using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MissileControl : MonoBehaviour
{
    AudioManager AudioManager;
    GameManager GameManager;

    void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        GameObject KC = GameObject.Find("KillCount");
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CameraBound")
        {
            Destroy(gameObject);
            print("BoundHit");
        }
        
        else if(other.gameObject.tag == "Enemy")
        {
            try{
                GameManager.EnemyDestroy(this.gameObject, other.gameObject);
            }
            catch(NullReferenceException){
               print("Object nahi");
           }
        }
    }

}
