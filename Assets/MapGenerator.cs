using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public bool autoGenerate = false;
    public int ranSeed = 10;
    public int sectionDimensions = 8;
    public int mapDimX = 4;
    public int mapDimY = 4;

    private BlockData[,] map;
    private SectionData[,] sectionMap;
    private bool mapGenerated = false;
	// Use this for initialization
	void Start () {
        UnityEngine.Random.seed = ranSeed;

        if (autoGenerate) {
            generateMap(sectionDimensions, mapDimX, mapDimY);
        }
	}
	public void generateMap(int sectionDim, int mapX, int mapY) {
        if (mapGenerated)
            return;
        map = new BlockData[mapX*sectionDim, mapY*sectionDim];
        sectionMap = new SectionData[mapX, mapY];

        for(int j = 0; j < mapX; j++) {
            for(int k = 0; k < mapY; k++) {



            }
        }

    }
	
}
