using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public bool autoGenerate = false;
    public int ranSeed = 10;
    public int sectionDimensions = 8;
    public int mapDimX = 4;
    public int mapDimY = 4;
    public float maxHeight = 10f;
    public float minHeight = 0f;
    public float heightDiff = 5f;

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
        SectionGenerator sg = new SectionGenerator(sectionDim);

        sectionMap[0, 0] = sg.createSection(minHeight, maxHeight, heightDiff);

        float topLeft = -1;
        float botLeft = -1;
        float botRight = -1;

        for(int j = 0; j < mapX; j++) {
            for(int k = 0; k < mapY; k++) {
                topLeft = -1;
                botLeft = -1;
                botRight = -1;

                if (j == 0 && k==0) {
                    continue;
                }
                if (j == 0) {
                    botLeft = sectionMap[j, k - 1].topLeft;
                    botRight = sectionMap[j, k - 1].topRight; 
                } else if (k == 0) {
                    topLeft = sectionMap[j - 1, k].topRight;
                    botLeft = sectionMap[j - 1, k].botRight;
                } else {
                    topLeft = sectionMap[j - 1, k].topRight;
                    botLeft = sectionMap[j, k - 1].topLeft;
                    botRight = sectionMap[j, k - 1].topRight;
                }
                sectionMap[j, k] = sg.createSection(minHeight,maxHeight,heightDiff,topLeft,botLeft,botRight);
            }
        }
        Debug.Log("Done");

    }
	
}
