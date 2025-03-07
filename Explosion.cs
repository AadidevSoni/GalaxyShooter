using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,3f); //otherwise the explosion prefab continues to exist
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}