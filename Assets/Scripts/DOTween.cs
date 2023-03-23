using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTween : MonoBehaviour
{
    public Transform knife;
    public Vector3 endPOS;

    public float jumpPower = 1;
    public int jumpCount;
    public float duration;
    //public Vector3 turnVector = new Vector3(180, 0, 0);
    private RotateMode mode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            knife.DORotate(knife.localRotation.eulerAngles + new Vector3(180, 0, 0), 1f);
            knife.DOMoveZ(1, 1f);
            knife.DOJump(endPOS, jumpPower, jumpCount, duration);
        }
    }
}
