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
        sectionMap[0, 0].printSection();

        for (int l = 0; l < sectionDimensions; l++) {
            for (int h = 0; h < sectionDimensions; h++) {
                map[l,h] = sectionMap[0,0].blockData[l, h];
            }
        }

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
                sectionMap[j, k].printSection();

                for(int l = 0; l < sectionDimensions; l++) {
                    for(int h = 0; h < sectionDimensions; h++) {
                        map[j * sectionDimensions + l, k * sectionDimensions + h] = sectionMap[j, k].blockData[l, h];
                    }
                }
            }
        }
        Debug.Log("Done");
        instantiateMap();
    }
    private void instantiateMap() {
        for(int j = 0; j < map.GetLength(0); j++) {
            for(int k = 0; k < map.GetLength(1); k++) {
                Instantiate(Resources.Load("MapBlock"), new Vector3(j,map[j,k].height,k), Quaternion.identity);
            }
        }
    }
	
}
