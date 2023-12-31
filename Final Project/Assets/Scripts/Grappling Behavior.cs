//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GrapplingBehavior : MonoBehaviour
//{
//    [Header("References")]
//    private PlayerBehavior pm;
//    public Transform cam;
//    public Transform gunTip;
//    public LayerMask whatIsGrappleable;
//    public LineRenderer lr;

//    [Header("Grappling")]
//    public float maxGrappleDistance;
//    public float grappleDelayTime;

//    private Vector3 grapplePoint;

//    [Header("Cooldown")]
//    public float grapplingCd;
//    private float grapplingCdTimer;

//    [Header("Input")]
//    public KeyCode grappleKey = KeyCode.Mouse1;

//    private bool grappling;


//    void Start()
//    {
//        pm = GetComponent<PlayerBehavior>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(grappleKey))
//            StartGrapple();

//        if (grapplingCdTimer > 0)
//            grapplingCdTimer -= Time.deltaTime;
//    }

//    private void LateUpdate()
//    {
//        if (grappling)
//            lr.SetPosition(0, gunTip.position);
//    }

//    private void StartGrapple()
//    {
//        if (grapplingCdTimer > 0)
//            return;

//        grappling = true;

//        RaycastHit hit;
//        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatIsGrappleable))
//        {
//            grapplePoint = hit.point;

//            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
//        }
//        else
//        {
//            grapplePoint = cam.position + cam.forward * maxGrappleDistance;

//            Invoke(nameof(StopGrapple), grappleDelayTime);
//        }

//        lr.enabled = true;
//        lr.SetPosition(1, grapplePoint);
//    }

//    private void ExecuteGrapple()
//    {

//    }

//    private void StopGrapple()
//    {
//        grappling = false;

//        grapplingCdTimer = grapplingCd;

//        lr.enabled = false;
//    }

//}
