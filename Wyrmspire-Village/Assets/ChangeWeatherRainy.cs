using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeatherRainy : MonoBehaviour
{
    public GameObject rainyButton;
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
    }
}
