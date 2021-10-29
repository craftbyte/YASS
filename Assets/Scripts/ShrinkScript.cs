using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkScript : MonoBehaviour
{
    private SpriteRenderer rendererComponent;
    void Awake() 
    {
        rendererComponent = GetComponent<SpriteRenderer>();
    }
    void Update() {
        if (rendererComponent.IsVisibleFrom(Camera.main) == false)
        {
            Destroy(gameObject);
        }
    }
}
