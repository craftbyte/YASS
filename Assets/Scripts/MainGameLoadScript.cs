using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoadScript : MonoBehaviour
{
    public GameObject Ship1;
    public GameObject Ship2;
    public GameObject Parent;
    public PickupBoxHelper PickupBox;
    public HealthBarHelper HealthBar;
    // Start is called before the first frame update
    void Awake()
    {
        var ship = Instantiate(PlayerConfig.SelectedShip == 1 ? Ship1 : Ship2);
        ship.transform.parent = Parent.transform;
        PickupBox.Player = ship;
        HealthBar.Player = ship;
        var music = GameObject.FindGameObjectWithTag("Music");
        if (music != null) music.GetComponent<MusicClass>().StopMusic();
    }
}
