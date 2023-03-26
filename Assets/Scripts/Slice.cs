using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    public float gravityModifier = 1.0f;
    public bool gravity;
    public bool kinematic;

    public AudioClip sliceSound;
    private AudioSource playerAudio;
    public Material materialSliceSide;
    private MoveTheScene moveScript;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GameObject.FindGameObjectWithTag("UnSliceable").GetComponent<MoveTheScene>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sliceable"))
        {
            SlicedHull divident = Divide(other.gameObject, materialSliceSide);
            GameObject dividentUp = divident.CreateUpperHull(other.gameObject, materialSliceSide);
            GameObject dividentDown = divident.CreateLowerHull(other.gameObject, materialSliceSide);
            Destroy(other.gameObject);
            AddComponent(dividentUp);
            AddComponent(dividentDown);
            playerAudio.PlayOneShot(sliceSound, 0.2f);            
        }
    }

    private SlicedHull Divide(GameObject sliecable, Material mat)
    {
        return sliecable.Slice(transform.position, transform.right, mat);        
    }

    void AddComponent(GameObject sliceable)
    {
        sliceable.AddComponent<MoveTheScene>();
        sliceable.AddComponent<BoxCollider>();
        var rigidbody = sliceable.AddComponent<Rigidbody>();
        rigidbody.useGravity = gravity;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        //rigidbody.AddForce(Vector3.down, ForceMode.VelocityChange);
        rigidbody.isKinematic = kinematic;
        //rigidbody.AddExplosionForce(explosionForce, sliceable.transform.position, explosionRadius);        
        //sliceable.tag = "Sliceable";
        Destroy(sliceable, 5f);        
    }
}
