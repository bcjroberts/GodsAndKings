using UnityEngine;
using System.Collections;

public class SectionGenerator {

    private int dimensions;

	public SectionGenerator(int ndimensions) {
        dimensions = ndimensions;
    }
    //Use this for first section
    public SectionData createSection(int max, int min) {
        SectionData data = new SectionData(dimensions);

        return data;
    }
    //Use this for when there is other data used for the section. -1 denotes not used
    public SectionData createSection(int max, int min, int topLeft, int botLeft, int botRight) {
        SectionData data = new SectionData(dimensions);

        return data;
    }
}
