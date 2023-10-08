using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeatherWindy : MonoBehaviour
{
    public GameObject windyButton;
    public GameObject cloud;
    public GameObject wind;
    public GameObject rain;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeWindy()
    {
        windyButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        cloud.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        wind.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.25f);
        rain.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
    }
}
