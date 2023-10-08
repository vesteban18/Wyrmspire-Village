using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeatherWindy : MonoBehaviour
{
    public GameObject windyButton;
    public GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeWindy()
    {
        windyButton.GetComponent<SpriteRenderer>().color = new Color(0.6509804f, 0.5607843f, 0.5607843f);
        cloud.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.25f);
    }
}
