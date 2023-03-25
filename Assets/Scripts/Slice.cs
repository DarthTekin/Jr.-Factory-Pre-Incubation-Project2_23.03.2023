using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice : MonoBehaviour
{
    public Material materialSliceSide;
    public float explosionForce;
    public float explosionRadius;
    public bool gravity;
    public bool kinematic;

    private MoveTheScene moveScript;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GameObject.FindGameObjectWithTag("UnSliceable").GetComponent<MoveTheScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sliceable"))
        {
            SlicedHull sliceObj = Divide(other.gameObject, materialSliceSide);
            GameObject sliceObjectUp = sliceObj.CreateUpperHull(other.gameObject, materialSliceSide);
            GameObject sliceObjectDown = sliceObj.CreateLowerHull(other.gameObject, materialSliceSide);
            Destroy(other.gameObject);
            AddComponent(sliceObjectUp);
            AddComponent(sliceObjectDown);
        }
    }

    private SlicedHull Divide(GameObject obj, Material mat)
    {
        return obj.Slice(transform.position, transform.right, mat);        
    }

    void AddComponent(GameObject obj)
    {
        obj.AddComponent<MoveTheScene>();
        obj.AddComponent<BoxCollider>();
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity = gravity;
        rigidbody.isKinematic = kinematic;
        rigidbody.AddExplosionForce(explosionForce, obj.transform.position, explosionRadius);
        obj.tag = "Sliceable";
        Destroy(obj, 5f);
    }
}
