using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeather : MonoBehaviour
{
    public GameObject summerButton;
    public GameObject cloud;
    public GameObject wind;
    public GameObject rain;

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
        wind.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        rain.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
    }
}
