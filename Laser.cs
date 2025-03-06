using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{   
    //speed variable
    [SerializeField]
    private float _laserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        //if laser position > 7 -> dstory laser
        if(transform.position.y >= 7f){
            //destroying tripple shot as it has a parent so it doesnt get destoryed
            if(transform.parent != null){
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);  //Destroy(this.gameObject,5f); to delete after 5 sec 
        }
    }
}