using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHelper : MonoBehaviour
{
    public GameObject Player;
    public GameObject HealthBar;
    
    public static HealthBarHelper Instance;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of HealthBarHelper!");
        }
        Instance = this;
    }
    void Start()
    {
        HealthBar.GetComponent<Slider>().maxValue = Player.GetComponent<HealthScript>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
            HealthBar.GetComponent<Slider>().value = Player.GetComponent<HealthScript>().hp;
        else 
            HealthBar.GetComponent<Slider>().value = 0;
    }
}
