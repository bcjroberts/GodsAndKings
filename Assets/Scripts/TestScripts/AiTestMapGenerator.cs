using UnityEngine;
using System.Collections;

public class AiTestMapGenerator : MonoBehaviour {

    public int xDim = 40;
    public int yDim = 40;
    public GameObject mapBlock;

    public GameObject[,] map;
	// Use this for initialization
	void Start () {
        map = new GameObject[xDim, yDim];

        for(int j = 0; j < xDim; j++) {
            for(int k = 0; k < yDim; k++) {
                GameObject b = (GameObject)Instantiate(mapBlock, new Vector3(j,(j+k)%2/8f,k), Quaternion.identity);
                map[j,k] = b;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
