using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	public bool gripButtonDown = false;
	public bool gripButtonUp = false;
	public bool gripButtonPressed = false;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	public bool triggerButtonDown = false;
	public bool triggerButtonUp = false;
	public bool triggerButtonPressed = false;
	public bool triggerButtonPrev = false;
	//public string triggerButtonPrev = "";
	private Valve.VR.EVRButtonId trackpadButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
	public bool trackpadButtonDown = false;
	public bool trackpadButtonUp = false;
	public bool trackpadButtonPressed = false;

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int) trackedObj.index);}}
	private SteamVR_TrackedObject trackedObj;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log("Controller not initialized");
			return;
		}

		//grip button initialization
		gripButtonDown = controller.GetPressDown(gripButton);
		gripButtonUp = controller.GetPressDown(gripButton);
		gripButtonPressed = controller.GetPressDown(gripButton);

		//trigger button initialization
		triggerButtonDown = controller.GetPressDown(triggerButton);
		triggerButtonUp = controller.GetPressUp(triggerButton);
		triggerButtonPressed = controller.GetPressDown(triggerButton);

		//trackpad button initialization
		trackpadButtonDown = controller.GetPressDown(trackpadButton);
		trackpadButtonUp = controller.GetPressUp(trackpadButton);
		trackpadButtonPressed = controller.GetPress(trackpadButton);

		if (gripButtonDown == true)
			Debug.Log("Grip button is down");
		if (triggerButtonDown == true)
			Debug.Log("Trigger button is down");
		if (triggerButtonPressed == true)
			Debug.Log("Trigger button is down");
		if (trackpadButtonDown == true)
			Debug.Log("Trigger button is down");
	}
}
