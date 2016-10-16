using UnityEngine;
using System.Collections;

public class HeadMovementController : MonoBehaviour {

    public GameObject VRCamera;
    public GameObject leftHand;
    public GameObject rightHand;
    public bool isButtonPressed =false;
    int leftDeviceIndex;
    int rightDeviceIndex;
    Vector3 initPosition = Vector3.one;
    public bool isDebug;
    public GameObject debugObj;

	// Use this for initialization
	void Start () {
        leftDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        rightDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (isDebug)
        //{
        //    //if (!isButtonPressed)
        //    {
        //        if (Input.GetKey(KeyCode.Q))
        //        {
        //            isButtonPressed = true;
        //            initPosition = debugObj.transform.position;

        //        }
        //    } 
        //    // else if (isButtonPressed)
        //    {
        //        if (!Input.GetKey(KeyCode.Q))
        //        {
        //            isButtonPressed = false;
        //            initPosition = debugObj.transform.position;

        //        }
        //    }
        //}

        if (isButtonPressed)
        {

            RaycastHit hit; //Debug.(transform.position, forward, Color.green);
            Debug.DrawRay(debugObj.transform.position, debugObj.transform.forward, Color.red);
            Debug.Log("going to cast");
            // DrawLine(initPosition, initPosition.normalized * 20, Color.blue);
            if (Physics.Raycast(leftHand.transform.position, leftHand.transform.forward, out hit))
            {
                Debug.Log("raycasted");
                if (hit.collider != null && hit.collider.gameObject != null)
                {
                    Debug.Log("HIT HIT HIT");
                    VRCamera.transform.position = hit.collider.transform.position;
                }
            }
         
        }
        else if (!isButtonPressed && SteamVR_Controller.Input(leftDeviceIndex).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            isButtonPressed = true;
            initPosition = leftHand.transform.position;
        }
	}

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.1f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.05f, 0.05f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
