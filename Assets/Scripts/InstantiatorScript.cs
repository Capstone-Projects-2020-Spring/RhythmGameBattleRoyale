using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorScript : MonoBehaviour
{
    public GameObject noteObject;
    public int bpm;
    public Material noteMaterial;
    public float maxTime;

    private float timestep;
    private float timer;
    private float cumulativeTimer;

    // Start is called before the first frame update
    void Start()
    {
        timestep = 60.0f/bpm;
        timer = 0.0f;
        cumulativeTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        cumulativeTimer += Time.deltaTime;
        if(timer >= timestep || cumulativeTimer > maxTime)
        {
            GameObject note = Instantiate(noteObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
            note.GetComponent<MeshRenderer>().material = noteMaterial;
            timer -= timestep;
        }
    }
}
