using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject bullet;
    public AudioManager AudioManager;
    public float missileForce = 500f;
    public float EnemySpeed = 3f;
    public float EnemySpeedIncrease;
    public TextMeshProUGUI KillCountText;
    public static int KillCount;
    public float GunLoadTime = 3f;
    public float LastHitTime ;
    public Image GunLoadImage;
    public GameObject ComboUI;
    public TextMeshProUGUI ComboText;

    private float Loadtimer = 0f;
    private int comboCount = 0;
    //private float ComboTimer = 0f;
    void Start()
    {
        //comboCount = 1;
        ComboUI.SetActive(false);
        LastHitTime = Time.timeSinceLevelLoad;
        AudioManager.PlaySound("BG");
        KillCount = 0;
        UpdateKillCount();
    }

    private void FixedUpdate()
    {
        EnemySpeed += EnemySpeedIncrease * Time.deltaTime;
        LoadGun();
    }

    void LoadGun(){
        Loadtimer += Time.deltaTime;
        GunLoadImage.fillAmount = Loadtimer/GunLoadTime;
        if(GunLoadImage.fillAmount == 1){
            FireButton();   
        }
        if (Loadtimer > GunLoadTime){
            //print(timer);
            Loadtimer = 0f; // Remove the recorded 2 seconds.
        }
    }

    public void FireButton()    //Missile fire ui button
    {
        ComboUI.SetActive(false);
        print("Fire!");
        AudioManager.PlaySound("Fire");
        GameObject bulletInstance = Instantiate(bullet,Camera.main.transform.position, Quaternion.identity) as GameObject;
        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
        bulletInstance.transform.forward = Camera.main.transform.forward;
        bulletInstance.transform.Rotate(-90, 0, 0);
        rb.AddForce(Camera.main.transform.forward * missileForce);
    }

    public void RestartButton() //Gameover menu restart button
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateKillCount()
    {
        KillCountText.text = KillCount.ToString();
    }

    public void EnemyDestroy(GameObject bullet, GameObject enemy){  
            float currentHitTime = Time.timeSinceLevelLoad;
            if((currentHitTime - LastHitTime) < (GunLoadTime + 1f)){
                comboCount++;
                ComboText.text = (comboCount-1).ToString();
                ComboUI.SetActive(true);
            }
            else{
                comboCount = 1;
            }
            LastHitTime = currentHitTime;
            //Debug.Log("Current Hit Time %f", &currentHitTime);// + " LastHit time " + LastHitTime + "comboCount " + comboCount);
            UpdateKillCount();
            GameObject explosion = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = enemy.transform.position;
            print("EnemyHit");
            AudioManager.PlaySound("Explosion");
            Destroy(bullet.gameObject);
            Destroy(enemy.gameObject);
            GameManager.KillCount++;
            Destroy(explosion, 2);
            
    }

    public void HitBound(){
        ComboUI.SetActive(false);
    }
}
