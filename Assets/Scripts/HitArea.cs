using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HitArea : MonoBehaviour
{
    public AudioManager AM;
    public Image healthBar;
    public int damage;
    public float health = 100f;
    public GameObject GameOverUI;
    public TextMeshProUGUI healthDownText;
    //public TextMeshProUGUI Hit;

    bool Cross50 = false;
    bool Cross25 = false;

    void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        healthDownText.text = "";
        //Hit.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            AM.PlaySound("Impact");
            //Hit.text = "HIT!";
            Invoke("HandleHit", 1);
            Destroy(other.gameObject);
            print("PlayerHit");
            health -= damage;
            healthBar.fillAmount = health / 100f;

            if(health <= 50 & !Cross50)
            {
                healthDownText.text = "Main armor integrity down to 50%";
                Cross50 = true;
                Invoke("HandleUI", 2);
            }
            else if (health <= 25 & !Cross25)
            {
               
                Cross25 = true;
                healthDownText.text = "Main armor integrity down to 25%";
                Invoke("HandleUI", 2);
                return;
            }
            else if (health <= 0)
            {
                    GameOver();
                    return;
            }
        }
    }

    private void HandleUI()
    {
        healthDownText.text = "";
    }
    void HandleHit()
    {
        //Hit.text = "";
    }
    private void GameOver()
    {
        print("GameOver");
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        GameOverUI.SetActive(true);
    }
}
