using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeatherCloudy : MonoBehaviour
{
    
    public GameObject cloudyButton;
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
        cloudyButton.GetComponent<SpriteRenderer>().color = new Color(0.2313726f, 0.6039216f, 0.8588235f);
    }
}
