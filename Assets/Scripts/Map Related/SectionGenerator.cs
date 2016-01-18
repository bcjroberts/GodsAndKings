using UnityEngine;
using System.Collections;

public class SectionGenerator {

    private int dimensions;


	public SectionGenerator(int ndimensions) {
        dimensions = ndimensions;
    }
    //Use this for first section
    public SectionData createSection(float min, float max, float range) {
        SectionData data = new SectionData(dimensions);
        Vector2 temp = getBounds((min + max) / 2f, range, min, max);
        min = temp.x;
        max = temp.y;
        
        data.botLeft = Random.Range(min, max);
        data.botRight = Random.Range(min, max);
        data.topLeft = Random.Range(min, max);
        data.topRight = Random.Range(min, max);

        //Now the data from the corners needs to be averaged and applied to each individual block
        data.fillValues();

        return data;
    }
    //Use this for when there is other data used for the section. -1 denotes not used
    public SectionData createSection(float min, float max, float range, float topLeft, float botLeft, float botRight) {
        SectionData data = new SectionData(dimensions);
        float avgStartHeight = 0;
        float totalNums = 0;
        if (topLeft != -1) {
            avgStartHeight += topLeft;
            totalNums += 1f;
        }
        if (botLeft != -1) {
            avgStartHeight += botLeft;
            totalNums += 1f;
        }
        if (botRight != -1) {
            avgStartHeight += botRight;
            totalNums += 1f;
        }
        avgStartHeight /= totalNums;

        Vector2 temp = getBounds(avgStartHeight, range, min, max);
        min = temp.x;
        max = temp.y;


        if (topLeft != -1)
            data.topLeft = topLeft;
        else
            data.topLeft = Random.Range(min, max);

        if (botLeft != -1)
            data.botLeft = botLeft;
        else
            data.botLeft = Random.Range(min, max);

        if (botRight != -1)
            data.botRight = botRight;
        else
            data.botRight = Random.Range(min, max);

        data.topRight = Random.Range(min, max);


        data.fillValues();
        return data;
    }
    private Vector2 getBounds(float start, float range, float min, float max) {
        Vector2 result = new Vector2();
        float temp = start;
        float rem = 0;
        float mint = min;
        float maxt = max;

        if (temp - range/2f >= min) {
            mint = temp - range;
        }
        else {
            mint = min;
            rem = min - (temp - range);
        }

        maxt = max;
        if (temp + range*2f <= max) {
            maxt = temp + range + rem;
            if (maxt > max)
                maxt = max;
        }
        else if (rem == 0) {
            rem = temp + range - max;
            if (mint - rem > min) {
                mint -= rem;
            }
            else {
                mint = min;
            }
        }
        min = mint;
        max = maxt;
        result.x = min;
        result.y = max;
        return result;
    }
}
