// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _speed = 3f;

    Rigidbody _rigidbody;

    void Awake() => _rigidbody = GetComponent<Rigidbody>();

    // Start is called before the first frame update
    /* void Start()
    {
        
    } */

    
    void OnDisable()
    {
        // Debug.Log("OnDisable has been called.");
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        // PlayerPrefs.Save();
    }

    void OnEnable()
    {   
        // Debug.Log("OnEnable has been called.");
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            var x = PlayerPrefs.GetFloat("PlayerX");        
            var y = PlayerPrefs.GetFloat("PlayerY");        
            var z = PlayerPrefs.GetFloat("PlayerZ");
            transform.position = new Vector3(x, y, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(x:horizontal, y:0, z:vertical).normalized;
        _rigidbody.velocity = velocity * _speed;
    }
}
