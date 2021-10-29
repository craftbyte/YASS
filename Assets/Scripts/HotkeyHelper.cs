using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotkeyHelper : MonoBehaviour
{
    void Update()
    {
        bool exit = Input.GetButtonDown("Cancel");
        if (exit) SceneManager.LoadScene("MenuScene");
    }
}
