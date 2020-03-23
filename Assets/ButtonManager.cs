using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public InputManager inputReference;
    public int inputNumber;

    //private SphereCollider colliderReference;
    private GameObject noteReference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyNote()
    {
        if (noteReference != null)
        {
            Destroy(noteReference);
            noteReference = null;
            //make destruction particle effects activate here
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In");
        if (other != null)
        {
            noteReference = other.gameObject;
            inputReference.notesOnButtons[inputNumber] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        noteReference = null;
        inputReference.notesOnButtons[inputNumber] = false;
    }
}
