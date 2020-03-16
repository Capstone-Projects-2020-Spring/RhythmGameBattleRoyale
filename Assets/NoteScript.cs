using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public float speed;

    private Rigidbody rbRef;
    private Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        if(speed == null || speed == 0.0f)
        {
            speed = 3.0f;
        }
        rbRef = gameObject.GetComponent<Rigidbody>();
        rbRef.AddForce(Vector3.down * speed);
        rotation = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        gameObject.transform.Rotate(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotation);
        //gameObject.transform.Translate(gameObject.transform.localRotation*Vector3.down);
        if(gameObject.transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rbRef.AddForce(Vector3.down*speed);
    }
}
