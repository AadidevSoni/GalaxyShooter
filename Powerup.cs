using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{   
    [SerializeField]
    private float _powerUpSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,6.9f,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);

        if(transform.position.y <= -6.90){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player player = other.transform.GetComponent<Player>();
            if(player != null){
                player.collectedTrippleShot();
            }
            Destroy(this.gameObject);
        }
    }
}