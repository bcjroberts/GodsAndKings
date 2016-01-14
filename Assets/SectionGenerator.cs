using UnityEngine;
using System.Collections;

public class SectionGenerator {

    private int dimensions;


	public SectionGenerator(int ndimensions) {
        dimensions = ndimensions;
    }
    //Use this for first section
    public SectionData createSection(float max, float min, float range) {
        SectionData data = new SectionData(dimensions);
        data.botLeft = UnityEngine.Random.Range(min, max);
        data.botRight = UnityEngine.Random.Range(min, max);
        data.topLeft = UnityEngine.Random.Range(min, max);
        data.topRight = UnityEngine.Random.Range(min, max);

        //Now the data from the corners needs to be averaged and applied to each individual block
        data.fillValues();

        return data;
    }
    //Use this for when there is other data used for the section. -1 denotes not used
    public SectionData createSection(float max, float min, float range, float topLeft, float botLeft, float botRight) {
        SectionData data = new SectionData(dimensions);
        if (topLeft != -1)
            data.topLeft = topLeft;
        else
            data.topLeft = UnityEngine.Random.Range(min, max);

        if (botLeft != -1)
            data.botLeft = botLeft;
        else
            data.botLeft = UnityEngine.Random.Range(min, max);

        if (botRight != -1)
            data.botRight = botRight;
        else
            data.botRight = UnityEngine.Random.Range(min, max);

        data.topRight = UnityEngine.Random.Range(min, max);


        data.fillValues();
        return data;
    }
}
