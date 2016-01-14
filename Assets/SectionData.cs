using UnityEngine;
using System.Collections;

public class SectionData {
    public BlockData[,] blockData;
    public SectionData(int ndimensions) {
        blockData = new BlockData[ndimensions, ndimensions];
    }
	
}
