using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTween : MonoBehaviour
{
    public Vector3 endPOS;

    public float jumpPower = 1;
    public int jumpCount;
    public float duration;
    public float gravityModifier = 2;
   
    //public Vector3 turnVector = new Vector3(180, 0, 0);
    private RotateMode mode;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DORotate(transform.localRotation.eulerAngles + new Vector3(180, 0, 0), 1f);
            //transform.DOMoveZ(1, 1f);
            transform.DOJump(endPOS, jumpPower, jumpCount, duration);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sliecable"))
        {
            Physics.gravity /= gravityModifier;
        }
    }
}
