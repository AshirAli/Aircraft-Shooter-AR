using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraMove : MonoBehaviour
{
    public float sensitivity;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameManager.FireButton();
        }
        float rotateHorizontal = Input.GetAxis ("Mouse X");
        //float rotateVertical = Input.GetAxis ("Mouse Y");
        transform.Rotate(-transform.up * -rotateHorizontal * sensitivity);
        //transform.Rotate(transform.right * -rotateVertical * sensitivity);
    }
}
