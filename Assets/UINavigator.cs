using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UINavigator : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject singleplayerMenu;
    public GameObject multiplayerMenu;

	// Use this for initialization
	void Start () {
	
	}
    public void goToMenu(int menuNum)
    {
        mainMenu.SetActive(false);
        singleplayerMenu.SetActive(false);
        multiplayerMenu.SetActive(false);
        switch (menuNum)
        {
            case 0:
                mainMenu.SetActive(true);
                break;
            case 1:
                singleplayerMenu.SetActive(true);
                break;
            case 2:
                multiplayerMenu.SetActive(true);
                break;
        }
    }
	
	
}
