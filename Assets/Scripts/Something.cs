using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Something : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime * speed);
        
    }
}
