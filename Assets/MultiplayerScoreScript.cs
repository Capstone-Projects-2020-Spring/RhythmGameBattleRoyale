using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerScoreScript : MonoBehaviour
{
    Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // change text
    public void changeText(int scoreNum)
    {
        textScore.text = $"{scoreNum:n0}";
    }
}
