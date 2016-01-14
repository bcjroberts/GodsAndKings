using UnityEngine;
using System.Collections;

public class SectionData {

    public float botLeft = -1;
    public float botRight = -1;
    public float topLeft = -1;
    public float topRight = -1;
    
    public BlockData[,] blockData;
    private int dimensions;

    public SectionData(int ndimensions) {
        blockData = new BlockData[ndimensions, ndimensions];
        dimensions = ndimensions;
    }
    public void fillValues() {
        float[,] valueArray;
        if (dimensions % 2 == 0) {
            valueArray = new float[dimensions + 1, dimensions + 1];
            fillArray(valueArray);
            //Now we need to actually calculate the block heights
            for (int j = 0; j < blockData.GetLength(0) - 1; j++) {
                for (int k = 0; k < blockData.GetLength(1) - 1; k++) {
                    BlockData bd = new BlockData((valueArray[j, k] + valueArray[j + 1, k] + valueArray[j, k + 1] + valueArray[j + 1, k + 1]) / 4f);
                    blockData[j, k] = bd;
                }
            }
        } else {
            valueArray = new float[dimensions, dimensions];
            fillArray(valueArray);
            //Now we have the block heights, and can simply transfer them
            for (int j = 0; j < blockData.GetLength(0); j++) {
                for (int k = 0; k < blockData.GetLength(1); k++) {
                    BlockData bd = new BlockData(valueArray[j, k]);
                    blockData[j, k] = bd;
                }
            }
        }
        Debug.Log("Section Finished!");
    }
    public void fillArray(float[,] array) {
        array[0, 0] = botLeft;
        array[0, dimensions - 1] = topLeft;
        array[dimensions - 1, 0] = botRight;
        array[dimensions - 1, dimensions - 1] = topRight;

        calcValues(array, 0, 0, dimensions - 1, dimensions - 1);

        //Once the above finishes, return back up to the even and odd cases

    }
    private void calcValues(float[,] array, int sx,int sz,int ex,int ez) {

        int midx = (sx + ex) / 2;
        int midz = (sz + ez) / 2;

        //Calculate values
        array[midx, midz] = (array[sx, sz] + array[sx, ez] + array[ex, ez] + array[ex, sz]) / 4f;

        array[midx, sz] = (array[midx, midz] + array[sx, sz] + array[ex, sz]) / 3f;
        array[midx, ez] = (array[midx, midz] + array[sx, ez] + array[ex, ez]) / 3f;
        array[sx, midz] = (array[midx, midz] + array[sx, sz] + array[sx, ez]) / 3f;
        array[ex, midz] = (array[midx, midz] + array[ex, sz] + array[ex, ez]) / 3f;

        //Checks if complete. If so, return
        if ((ex / 2) - 1 <= sx)
            return;

        Debug.Log("Recursive!");
        calcValues(array, sx, sz, ex / 2, ez / 2);
        calcValues(array, ex / 2, ez / 2, ex, ez);
        calcValues(array, sx, ez / 2, ex / 2, ez);
        calcValues(array, ex / 2, sz, ex, ez / 2);
    }
}
