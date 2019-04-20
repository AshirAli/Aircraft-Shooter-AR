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
    public float speed = 1f;
    public Text debugText;
    #endregion

    private float step;

    void Start()
    {
        InvokeRepeating("SpawnEnemyAircrafts", 1f, SpawnRate);
    }

    private void FixedUpdate()
    {
        SpawnRate += SpawnRateIncrease * Time.deltaTime;
        step = speed * Time.deltaTime;
    }

    void SpawnEnemyAircrafts()
    {
        Vector3 pos =  new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y), Camera.main.farClipPlane);
        /* Vector3 camPos = Camera.main.ScreenToWorldPoint(
                            new Vector3(
                                Random.Range(0, Screen.width), 
                                Random.Range(0, Screen.height), 
                                Camera.main.farClipPlane)
                      );
        Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.nearClipPlane));
        Debug.Log(pos);
        Debug.Log(camPos);
        */
        Debug.Log(pos);
        debugText.text = ("Pos = " + pos);
        GameObject EnemyInstance = Instantiate(EnemyAirCraft,pos,Quaternion.identity);
        //EnemyInstance.transform.Rotate(0, -180, 0);
        //EnemyInstance.transform.LookAt(Camera.main.transform); //Make the enemy look at the camera.
        EnemyInstance.transform.parent = transform;
    }
}
