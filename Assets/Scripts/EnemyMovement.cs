using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    GameManager GameManager;

    private void Awake()
    {
        transform.Rotate(0, -180, 0);
    }
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        movementSpeed = GameManager.EnemySpeed;
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, step);
        
        Vector3 relativePos = Camera.main.transform.position - transform.position;
        transform.LookAt(Camera.main.transform); //Make the enemy look at the camera.
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos,
                                                      Vector3.up);
        transform.rotation = rotation;
    }
}
