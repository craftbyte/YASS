using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
    void Start() {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }
    void Update() {
        #if UNITY_STANDALONE
        bool exit = Input.GetButtonDown("Cancel");
        if (exit) Application.Quit();
        #endif
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void SelectShip()
    {
        SceneManager.LoadScene("ShipSelectScene");
    }
    public void StartGame(int selectedShip)
    {
        PlayerConfig.SelectedShip = selectedShip;
        SceneManager.LoadScene("GameScene");
    }
    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}