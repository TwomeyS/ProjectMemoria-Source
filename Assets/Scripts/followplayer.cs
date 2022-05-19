using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset =  new Vector3(-2.11f, 2.74f, -7.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
