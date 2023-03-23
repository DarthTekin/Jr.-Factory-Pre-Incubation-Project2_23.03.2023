using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheScene : MonoBehaviour
{
    public float speed = -1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();  
    }
    public void MoveLeft()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
