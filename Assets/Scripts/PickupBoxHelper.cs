using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupBoxHelper : MonoBehaviour
{
    public GameObject Player;
    public GameObject PickupBox;
    public static PickupBoxHelper Instance;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of PickupBoxHelper!");
        }
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Player != null)
            PickupBox.GetComponent<Toggle>().isOn = Player.GetComponent<PlayerScript>().hasShrink;
        else 
            PickupBox.GetComponent<Toggle>().isOn = false;
    }
}
