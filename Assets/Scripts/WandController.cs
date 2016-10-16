using UnityEngine;
using Valve.VR;
using System.Collections;


public class WandController : MonoBehaviour {
	
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int) leftDeviceIndex);}}
	private SteamVR_Controller.Device controllerMain { get { return SteamVR_Controller.Input((int) rightDeviceIndex);}}
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_TrackedObject trackedObjMain;

	int leftDeviceIndex;
	int rightDeviceIndex;

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

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	public bool gripButtonDown = false;
	public bool gripButtonUp = false;
	public bool gripButtonPressed = false;

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	public bool triggerButtonDown = false;
	public bool triggerButtonUp = false;
	public bool triggerButtonPressed = false;

	private Valve.VR.EVRButtonId trackpadButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
	public bool trackpadButtonDown = false;
	public bool trackpadButtonUp = false;
	public bool trackpadButtonPressed = false;

	private bool gripMenuOpen = false; 

	public Canvas UImenu;

	// Use this for initialization
	void Start () {
		leftDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
		rightDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

		trackedObj = GetComponent<SteamVR_TrackedObject>();
		trackedObjMain = GetComponent<SteamVR_TrackedObject>();

		if(trackedObj != null) {
			_index = (int)trackedObj.index;
			_connected = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log("Controller not initialized");
			return;
		}
			
		//grip button initialization
		gripButtonDown = controller.GetPressDown(gripButton);
		gripButtonUp = controller.GetPressUp(gripButton);
		gripButtonPressed = controller.GetPress(gripButton);

		//trigger button initialization
		triggerButtonDown = controller.GetPressDown(triggerButton);
		triggerButtonUp = controller.GetPressUp(triggerButton);
		triggerButtonPressed = controller.GetPress(triggerButton);

		//trackpad button initialization
		trackpadButtonDown = controller.GetPressDown(trackpadButton);
		trackpadButtonUp = controller.GetPressUp(trackpadButton);
		trackpadButtonPressed = controller.GetPress(trackpadButton);

		//grip ButtonMain initialization
		gripButtonMainDown = controllerMain.GetPressDown(gripButtonMain);
		gripButtonMainUp = controllerMain.GetPressUp(gripButtonMain);
		gripButtonMainPressed = controllerMain.GetPress(gripButtonMain);

		//trigger ButtonMain initialization
		triggerButtonMainDown = controllerMain.GetPressDown(triggerButtonMain);
		triggerButtonMainUp = controllerMain.GetPressUp(triggerButtonMain);
		triggerButtonMainPressed = controllerMain.GetPress(triggerButtonMain);

		//trackpad ButtonMain initialization
		trackpadButtonMainDown = controllerMain.GetPressDown(trackpadButtonMain);
		trackpadButtonMainUp = controllerMain.GetPressUp(trackpadButtonMain);
		trackpadButtonMainPressed = controllerMain.GetPress(trackpadButtonMain);


		if (gripButtonPressed == true && gripMenuOpen == false)
		{
			menuOpen();	
			Debug.Log("Open the menu -- Menu State:" + UImenu.gameObject.activeInHierarchy);
		}
		if (gripButtonPressed == false && UImenu.gameObject.activeInHierarchy == true)
		{
			gripMenuOpen = true;
		}

		if (gripButtonDown == true && gripMenuOpen == true)
		{
			MenuClose();
			Debug.Log("Close menu -- Menu State:" + UImenu.gameObject.activeInHierarchy);
		}
		if (gripButtonPressed == false && UImenu.gameObject.activeInHierarchy == false)
		{
			gripMenuOpen = false;
		}

	}
	public void laserPointerOn()
	{
		//balls
	}

	public void menuOpen()
	{
		UImenu.gameObject.SetActive(true);
	}

	public void MenuClose()
	{
		UImenu.gameObject.SetActive(false);
	}

	/*public override void OnEnterControl(GameObject control)
	{
		var device = SteamVR_Controller.Input(_index);
		device.TriggerHapticPulse(1000);
	}

	public override void OnExitControl(GameObject control)
	{
		var device = SteamVR_Controller.Input(_index);
		device.TriggerHapticPulse(600);
	}
*/
	/*
	public override bool ButtonDown()
	{
		return false;
	}
	public override bool ButtonUp()
	{
		return false;
	}
	*/
}

