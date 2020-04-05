using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horzBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rbRef = this.GetComponent<Rigidbody>();
        rbRef.AddForce(Vector3.down * 1400);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
