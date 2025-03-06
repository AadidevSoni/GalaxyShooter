using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{   
    [SerializeField]
    private float _powerUpSpeed = 3f;
    //ID for powerups
    [SerializeField] 
    private int powerupID; //0-tripple shot, 1-speed, 2-shield
    // Start is called before the first frame update
    void Start()
    {
        
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
                
                switch(powerupID){
                    case 0:
                        player.collectedTrippleShot();
                        break;
                    case 1:
                        player.collectedSpeedBoost();
                        break;
                    case 2:
                        player.collectedShields();
                        break;
                    default:
                        Debug.Log("ERROR");
                        break;
                }
                
            }
            Destroy(this.gameObject);
        }
    }
}