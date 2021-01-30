using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_collide : MonoBehaviour
{
    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="target")
        {
            Audio.Play();
        }
    }
}
