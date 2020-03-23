using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartParser;

public class Chart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath;
        print(path+ "/MEGALOVANIA.chart");
        var Holder = new Song();
        Holder = Parser.ChartReader(path + "/MEGALOVANIA.chart");
        print(Holder.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
