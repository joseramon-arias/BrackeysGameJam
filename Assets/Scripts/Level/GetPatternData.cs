using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatternData : MonoBehaviour
{
    [SerializeField] private TextAsset patternsCsv;
    public TextAsset PatternsCsv
    {
        set { patternsCsv = value; }
    }
    private static List<string[]> data;
    public static string[][] Data => data.ToArray();

    void Awake()
    {
        WrangleDataAndCreatePatternsArray();
    }

    public void WrangleDataAndCreatePatternsArray()
    {
        data = new List<string[]>();
        string fileData = patternsCsv.ToString();
        fileData = fileData.Replace("\r", string.Empty);
        string[] lines = fileData.Split("\n"[0]);
        List<string> pattern = new List<string>();

        foreach (string line in lines)
        {
            string[] splittedLine = line.Split(","[0]);
            // If we get to a `patternSeparationSymbol`, one pattern has ended, so save it and go to the next one.
            if (splittedLine[0] == TileCodes.Separator)
            {
                data.Add(pattern.ToArray());
                pattern = new List<string>();
                continue;
            }

            pattern.AddRange(splittedLine);
        }
    }
}
