using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenerationMenu : MonoBehaviour {

    public InputField number;
    public MapGenerator mp;
    private int seed = 0;
	// Use this for initialization
	void Start () {
        number.text = seed + "";
	}

    public void generateTerrain() {
        seed = int.Parse(number.text);
        mp.destroyMap();
        mp.ranSeed = seed;
        seed++;
        number.text = seed+"";
        mp.generateMap(mp.sectionDimensions, mp.mapDimX, mp.mapDimY);
    }
}
