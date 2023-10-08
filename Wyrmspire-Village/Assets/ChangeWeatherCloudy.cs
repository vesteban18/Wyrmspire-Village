using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeatherCloudy : MonoBehaviour
{
    
    public GameObject cloudyButton;
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

    public void changeCloudy()
    {
        cloudyButton.GetComponent<SpriteRenderer>().color = new Color(0.6886792f, 0.6886792f, 0.6886792f);
        cloud.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.4f);
        wind.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        rain.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
    }
}
