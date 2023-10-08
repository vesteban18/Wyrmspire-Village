using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeatherRainy : MonoBehaviour
{
    public GameObject rainyButton;
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

    public void changeRainy()
    {
        rainyButton.GetComponent<SpriteRenderer>().color = new Color(0.5764706f, 0.4313726f, 0.4313726f);
        cloud.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        wind.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        rain.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.75f);
    }
}
