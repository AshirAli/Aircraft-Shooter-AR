using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour
{
    #region public
    public GameObject EnemyAirCraft;
    public Vector3 size;    //size of spawn area
    public float SpawnRate = 2f;
    public float SpawnRateIncrease = 1.2f;
    public Text debugText;
    #endregion

    private Vector2 ScreenSize;
    private float cameraFarClip;
    void Start()
    {
        InvokeRepeating("SpawnEnemyAircrafts", 1f, SpawnRate);
        ScreenSize.x = Screen.width/8;
        ScreenSize.y = Screen.height/8;
        cameraFarClip = Camera.main.farClipPlane - 20;
         Random.InitState(255);
    }

    private void FixedUpdate()
    {
        SpawnRate += SpawnRateIncrease * Time.deltaTime;
    }

    void SpawnEnemyAircrafts()
    {
       
        Vector3 pos =  new Vector3(Random.Range(-size.x/2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Camera.main.farClipPlane);
        Vector3 camPos = Camera.main.ScreenToWorldPoint(
                            new Vector3(
                                Random.Range(-ScreenSize.x, ScreenSize.x), 
                                Random.Range(-ScreenSize.y, ScreenSize.y),
                                cameraFarClip)
                            );
        Debug.Log(camPos);

        debugText.text = ("camPos" + camPos);
        GameObject EnemyInstance = Instantiate(EnemyAirCraft,camPos,Quaternion.identity);
        //EnemyInstance.transform.Rotate(0, -180, 0);
        //EnemyInstance.transform.LookAt(Camera.main.transform); //Make the enemy look at the camera.
        EnemyInstance.transform.parent = transform;
    }
}
