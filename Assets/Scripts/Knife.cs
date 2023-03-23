using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public int jumpSpeed = Mathf.Clamp(5, 4, 6);
    public int turnSpeed = Mathf.Clamp(2, 1, 3);
    public int moveSpeed = Mathf.Clamp(1, 0, 2);
    public float gravityModifier = 1;
    public float turnAngle = 45;
    public float fallAngle = 90;
    public bool collided;
    public Vector3 turnVector = new Vector3(360, 0, 0);

    
    //public bool isOnGround = false;

    private Rigidbody knifeRb;
    public Vector3 coMass;
    // Start is called before the first frame update
    void Start()
    {
        knifeRb = GetComponent<Rigidbody>();
        coMass = knifeRb.centerOfMass;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheKnife();

        //if (transform.rotation.x > turnAngle && !collided)
        //{
        //    transform.rotation = Quaternion.Euler(fallAngle, transform.rotation.y, transform.rotation.z);
        //}
    }

    public void MoveTheKnife()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //knifeRb.AddTorque(turnVector * turnSpeed, ForceMode.Impulse);
        //    //knifeRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        //    //knifeRb.AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);           
        //}
    }
}
