using UnityEngine;
using System.Collections;

public class FlyingCamera : MonoBehaviour 
{
	#region Properties
	
	public float MovementSpeed = 10F;
	
	#endregion Properties
	
	#region MonoBehaviour Methods
	
	void Awake ()
	{
	}
	
	void Start ()
	{
	}
	
	void Update ()
	{
		ProcessInputForUpdateUsingDefaultKeyBinds(Time.deltaTime);
	}
	
	#endregion MonoBehaviour Methods
	
	/// <summary>
	/// Processes the input for update.  This uses the default unity keybinds for w,a,s,d
	/// movement.  Unfortunately by default these have a roll-in/out factor so movement isn't
	/// tight and snappy.  Additionally no default keybind we can use for altitude control
	/// </summary>
	/// <param name='deltaTime'>deltaTime for this update</param>
	void ProcessInputForUpdateUsingDefaultKeyBinds ( float deltaTime )
	{
		Vector3 cameraRelativeMovementDir = Vector3.zero;
		
		if ( Input.GetAxis("Vertical") > 0F )
		{
			// forward
			cameraRelativeMovementDir += (MovementSpeed * Vector3.forward);
		}
		else if ( Input.GetAxis("Vertical") < 0F )
		{
			// back
			cameraRelativeMovementDir -= (MovementSpeed * Vector3.forward);
		}
		
		if ( Input.GetAxis("Horizontal") > 0F )
		{
			// right
			cameraRelativeMovementDir += (MovementSpeed * Vector3.right);
		}
		else if ( Input.GetAxis("Horizontal") < 0F )
		{
			// left
			cameraRelativeMovementDir -= (MovementSpeed * Vector3.right);
		}
		
		Vector3 worldMovementDir = transform.TransformDirection(cameraRelativeMovementDir);
		
		transform.position += (worldMovementDir * deltaTime);
	}
}
