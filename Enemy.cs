using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField]
    private float _enemySpeed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down 4m/s
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        //respawn at top if not destoryed by player
        //respawn at top at a new random x position

        if(transform.position.y <= -6.38){
            float randomX = Random.Range(-8f,8f);
            transform.position = new Vector3(randomX,6.4f,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //private void OnTriggerEnter2D(Collider other)this is for 3D collision
    {
        //Debug.Log("Hit: " + other.transform.name);

        //if other is player
        //damange the player
        //destory us
        if(other.tag == "Player"){
            //only component in unity we have direct access to is transform
            //we are accessing the Damage method which is in the Player component in the transform
            Player player = other.transform.GetComponent<Player>();  //null checking just in case the player object does not exist to catch errors
            if(player != null){
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        //if other is laser
        //destory laser
        //destroy us
        if(other.tag == "Laser"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}