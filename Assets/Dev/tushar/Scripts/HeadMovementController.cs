using UnityEngine;
using System.Collections;

public class HeadMovementController : MonoBehaviour {

    public GameObject VRCamera;
    public GameObject leftHand;
    public GameObject rightHand;
    public bool isButtonPressed;
    int leftDeviceIndex;
    int rightDeviceIndex;
    Vector3 initPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
        leftDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        rightDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
	}
	
	// Update is called once per frame
	void Update () {
        if (isButtonPressed || Input.GetKey(KeyCode.A))
        {
            DrawLine(initPosition, initPosition.normalized * 20, Color.blue);
            Ray ray = Camera.main.ScreenPointToRay (initPosition.normalized * 20);
            RaycastHit hit;
         if (hit.collider.gameObject.name !=null) {
             VRCamera.transform.position = hit.collider.transform.position;
         }
        }
        else if (!isButtonPressed && SteamVR_Controller.Input(leftDeviceIndex).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            isButtonPressed = true;
            initPosition = leftHand.transform.position;
        }
	}

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
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
