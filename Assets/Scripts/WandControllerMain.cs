using UnityEngine;
using Valve.VR;
using System.Collections;


public class WandControllerMain : MonoBehaviour {

	private SteamVR_Controller.Device controllerMain { get { return SteamVR_Controller.Input((int) trackedObjMain.index);}}
	private SteamVR_TrackedObject trackedObjMain;
	private int _index;
	private bool _connected = false;

	private Valve.VR.EVRButtonId gripButtonMain = Valve.VR.EVRButtonId.k_EButton_Grip;
	public bool gripButtonMainDown = false;
	public bool gripButtonMainUp = false;
	public bool gripButtonMainPressed = false;


	private Valve.VR.EVRButtonId triggerButtonMain = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	public bool triggerButtonMainDown = false;
	public bool triggerButtonMainUp = false;
	public bool triggerButtonMainPressed = false;

	private Valve.VR.EVRButtonId trackpadButtonMain = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
	public bool trackpadButtonMainDown = false;
	public bool trackpadButtonMainUp = false;
	public bool trackpadButtonMainPressed = false;

	//private bool gripMenuOpen = false; 

	//public Canvas UImenu;

	// Use this for initialization
	void Start () {
		//leftDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
		//rightDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
		trackedObjMain = GetComponent<SteamVR_TrackedObject>();

		if(trackedObjMain != null) {
			_index = (int)trackedObjMain.index;
			_connected = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (controllerMain == null) {
			Debug.Log("Controller not initialized");
			return;
		}


		//grip button initialization
		gripButtonMainDown = controllerMain.GetPressDown(gripButtonMain);
		gripButtonMainUp = controllerMain.GetPressUp(gripButtonMain);
		gripButtonMainPressed = controllerMain.GetPress(gripButtonMain);

		//trigger button initialization
		triggerButtonMainDown = controllerMain.GetPressDown(triggerButtonMain);
		triggerButtonMainUp = controllerMain.GetPressUp(triggerButtonMain);
		triggerButtonMainPressed = controllerMain.GetPress(triggerButtonMain);

		//trackpad button initialization
		trackpadButtonMainDown = controllerMain.GetPressDown(trackpadButtonMain);
		trackpadButtonMainUp = controllerMain.GetPressUp(trackpadButtonMain);
		trackpadButtonMainPressed = controllerMain.GetPress(trackpadButtonMain);



		if (gripButtonMainPressed == true)
		{
			Debug.Log("Open the menu -- Menu State:");
		}
			
}
}

