using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject bullet;
    public AudioManager AudioManager;
    public float missileForce = 500f;
    public float EnemySpeed = 3f;
    public float EnemySpeedIncrease;
    public TextMeshProUGUI KillCountText;
    public static int KillCount;

    void Start()
    {

        AudioManager.PlaySound("BG");
        KillCount = 0;
        UpdateKillCount();
    }

    private void FixedUpdate()
    {
        EnemySpeed += EnemySpeedIncrease * Time.deltaTime;
        UpdateKillCount();
    }

    public void FireButton()    //Missile fire ui button
    {
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
}
