using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Knife : MonoBehaviour
{
    public Material material;
    private GameObject sliceable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sliceable != null)
        {
            SlicedHull divident = Divide(sliceable, material);
            GameObject dividentup = divident.CreateUpperHull(sliceable, material);
            dividentup.AddComponent<MeshCollider>().convex = true;
            dividentup.AddComponent<Rigidbody>();
            dividentup.layer = LayerMask.NameToLayer("Sliceable");
            GameObject dividentdown = divident.CreateLowerHull(sliceable, material);
            dividentdown.AddComponent<MeshCollider>().convex = true;
            dividentdown.AddComponent<Rigidbody>();
            dividentdown.layer = LayerMask.NameToLayer("Sliceable");
            Destroy(sliceable);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Sliceable"))
        {
            material = other.GetComponent<MeshRenderer>().material;
            sliceable = other.gameObject;
        }
    }

    public SlicedHull Divide(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }
}
