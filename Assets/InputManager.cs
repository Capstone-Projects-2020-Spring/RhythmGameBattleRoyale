using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //public data members that need explicit assignment in-editor
    public GameObject[] inputButtonObjects;
    public Material[] buttonMaterials;

    //public data members that are assigned at runtime
    public bool[] notesOnButtons;
    public int score;

    //private data members
    private MeshRenderer[] inputButtonMaterials;
    private bool[] buttonStates;
    private ButtonManager[] buttonScriptReferences;
    
    // Start is called before the first frame update
    void Start()
    {
        inputButtonMaterials = new MeshRenderer[inputButtonObjects.Length];
        buttonStates = new bool[inputButtonObjects.Length];
        buttonScriptReferences = new ButtonManager[inputButtonObjects.Length];
        notesOnButtons = new bool[inputButtonObjects.Length];

        for (int i = 0; i < inputButtonObjects.Length; i++)
        {
            inputButtonMaterials[i] = inputButtonObjects[i].GetComponent<MeshRenderer>();
            buttonStates[i] = false;
            notesOnButtons[i] = false;
            buttonScriptReferences[i] = inputButtonObjects[i].GetComponent<ButtonManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            inputButtonMaterials[0].material = buttonMaterials[5];
            buttonStates[0] = true;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            inputButtonMaterials[1].material = buttonMaterials[6];
            buttonStates[1] = true;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            inputButtonMaterials[2].material = buttonMaterials[7];
            buttonStates[2] = true;
        }
        if (Input.GetButtonDown("Fire4"))
        {
            inputButtonMaterials[3].material = buttonMaterials[8];
            buttonStates[3] = true;
        }
        if (Input.GetButtonDown("Fire5"))
        {
            inputButtonMaterials[4].material = buttonMaterials[9];
            buttonStates[4] = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            inputButtonMaterials[0].material = buttonMaterials[0];
            buttonStates[0] = false;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            inputButtonMaterials[1].material = buttonMaterials[1];
            buttonStates[1] = false;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            inputButtonMaterials[2].material = buttonMaterials[2];
            buttonStates[2] = false;
        }
        if (Input.GetButtonUp("Fire4"))
        {
            inputButtonMaterials[3].material = buttonMaterials[3];
            buttonStates[3] = false;
        }
        if (Input.GetButtonUp("Fire5"))
        {
            inputButtonMaterials[4].material = buttonMaterials[4];
            buttonStates[4] = false;
        }


        if(Input.GetButtonDown("Fire6"))
        {
            if (checkStrum())
            {
                executeStrum();
                score++;
                Debug.Log(score);
            }
        }
    }

    private bool checkStrum()
    {
        for(int i = 0; i < buttonStates.Length; i++)
        {
            if(buttonStates[i] != notesOnButtons[i])
            {
                return false;
            }
        }
        return true;
    }

    private void executeStrum()
    {
        for(int i = 0; i < notesOnButtons.Length; i++)
        {
            if(notesOnButtons[i])
            {
                buttonScriptReferences[i].destroyNote();
            }

            notesOnButtons[i] = false;
        }
    }
}
