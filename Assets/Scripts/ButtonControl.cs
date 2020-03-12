using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultButton;
    public Sprite pressed;
    public KeyCode keyInput;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //if the input is pressed suppose to change button for a frame
        if (Input.GetKeyDown(keyInput))
        {
            SR.sprite = pressed;
        }
        //if input is let go 
        if (Input.GetKeyUp(keyInput))
        {
            SR.sprite = defaultButton;
        }
    }
}
