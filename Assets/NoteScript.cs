using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public float speed;

    private Rigidbody rbRef;
    //private Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        Color color = this.GetComponent<MeshRenderer>().material.color;
        color.a = 0;
        this.GetComponent<MeshRenderer>().material.color = color;
        if (speed == null || speed == 0.0f)
        {
            speed = 1500.0f;
        }
        rbRef = gameObject.GetComponent<Rigidbody>();
        rbRef.AddForce(Vector3.down * speed);
        //rotation = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.Rotate(rotation);
        //gameObject.transform.Translate(gameObject.transform.localRotation*Vector3.down);
        if(gameObject.transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Color color = this.GetComponent<MeshRenderer>().material.color;
        color.a += Time.deltaTime  * 1f;
        color.a = color.a < 1f ? color.a : 1f;
        this.GetComponent<MeshRenderer>().material.color = color;
    }
}
