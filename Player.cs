using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //Allows unity to drag and drop scripts and behaviors to game objects
{   
    //public or private, datatype, name, value(optional)

    //public float speed = 3.5f;   to modify it in unity
    //OR SERIALIE PRIVATE
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.5f;
    private float nextFire = 0.0f;

    [SerializeField]
    private int _lives = 3;

    private Spawn_Manager _spawnManager;

    [SerializeField]
    private bool isTrippleShotActive = true;

    [SerializeField]
    private GameObject _trippleShotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //take current position = new position (0,0,0)
        //everything related to rotation and positioning is done through vector3
        transform.position = new Vector3(0, 0, 0);     //player position snaps to origin

        //TO GET ACCESS TO SPAWN MANAGER SCRIPT
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();  //the value in <> should match with the value of type we are searching for

        if(_spawnManager == null){
            Debug.LogError("The Spawn manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        //PLAYER MOVEMENT
        float horizontalInput = Input.GetAxis("Horizontal"); //horizontalInput is 0 when not pressed and hence the cube will only move if we press a or d
        float verticalInput = Input.GetAxis("Vertical");

        //Moves the transform in the direction and distance of translation.
        //transform.Translate(Vector3.right); Player moves infinitely to the right in speed of sound    -  we are moving the player 1m per frame 60 times per sec i.e, 60m/sec
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);  //Time.delataTime converts from frame dependent to real word seconds
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        //transform.Translate(new Vector3(1,0,0));   when we use new vector3, we must provide the coordinates

        //OPTIMIZED TRANSLATION CODE
        //transform.Translate(new Vector3(horizontalInput,verticalInput,0) * _speed * Time.deltaTime);
        //OR
        //Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        //transform.Translate(direction * _speed * Time.deltaTime);

        //PLAYER BOUND

        //Y Bounds Checking
        if(transform.position.y >= 0){
            transform.position = new Vector3(transform.position.x,0,0);
        }else if(transform.position.y <= -5f){
            transform.position = new Vector3(transform.position.x,-5f,0);
        }

        //ABOVE CODE can be done by a unity specific clamping function in Mathf
        //transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-5f,0),0);   //Mathf.clamp(variable,min,max)

        //X Bounds Checking
        /*
        if(transform.position.x >= 9.3f){
            transform.position = new Vector3(9.3f,transform.position.y,0);
        }else if(transform.position.x <= -9.3f){
            transform.position = new Vector3(-9.3f,transform.position.y,0);
        }
        */

        //X Wrapping
        
        if(transform.position.x > 11.3f){
            transform.position = new Vector3(-11.3f,transform.position.y,0);
        }else if(transform.position.x < -11.3f){
            transform.position = new Vector3(11.3f,transform.position.y,0);
        }
    }

    void FireLaser(){
        //hit space key -> spawn game object
        //to listen for a space key press
    
        nextFire = Time.time + _fireRate;
        if(isTrippleShotActive == true){
            Instantiate(_trippleShotPrefab,new Vector3(transform.position.x,transform.position.y + 1.05f,0),Quaternion.identity);
        }else{
            Instantiate(_laserPrefab,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);  //spawning a laser  (prefab,position,rotation)  quaternion is used to measure rotation and its 0 here 
        }
        
        //we want to spawn the laser 9.8 units above the player
    }

    public void Damage()
    {
        _lives -= 1;
        
        if(_lives < 1){
            //communicate with spawn manager
            _spawnManager.onPlayerDeath();
            Destroy(this.gameObject);
        }

    }
}