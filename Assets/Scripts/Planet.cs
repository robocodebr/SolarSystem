using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    GameObject sun;
    public float speed = 1f;
    public float selfSpeed = 1f;
    public float maxSpeed = 300f;
    void Start()
    {
        sun = GameObject.Find("Sun");
        speed = Random.Range(5, maxSpeed/3);
        selfSpeed = Random.Range(5, maxSpeed/3);
        if (this.name != "Sun") transform.RotateAround(sun.transform.position, Vector3.up, 1000 * speed * Time.deltaTime);
    }
    void Update()
    {
        if(sun && this.name != "Sun") transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
        this.transform.Rotate(Vector3.right*Time.deltaTime*selfSpeed);
    }
}
