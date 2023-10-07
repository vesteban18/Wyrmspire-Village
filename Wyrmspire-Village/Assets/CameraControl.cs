using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float speed = 100.0f;
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
        }
        */
        float cameraPosition = Camera.main.transform.position.y;
        
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if (cameraPosition > -220.0)
            {
            transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
            }
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (cameraPosition < 220.0)
            {
            transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
            }
        }
    }
}
