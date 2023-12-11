using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(1, xMin , xMax);

        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), transform.position.y, transform.position.z);
    }
}
