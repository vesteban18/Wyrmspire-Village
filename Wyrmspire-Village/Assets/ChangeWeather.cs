using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeather : MonoBehaviour
{
    public GameObject summerButton;
    public GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor()
    {
        summerButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        cloud.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
    }
}
