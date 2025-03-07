using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{   
    [SerializeField]
    private float _rotateSpeed = 3f;

    [SerializeField]
    private GameObject _explosionPrefab;

    private Spawn_Manager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        if(_spawnManager == null){
            Debug.LogError("Spawn manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Laser"){
            Instantiate(_explosionPrefab,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject,0.045f);

            _spawnManager.StartSpawning();
        }
    }
}