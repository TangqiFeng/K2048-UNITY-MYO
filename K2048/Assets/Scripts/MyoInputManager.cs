using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

/* control game when certain poses are made with the Myo armband.
 *   move up -> Fist,           move down -> FingersSpread
 *   move left -> WaveIn,       move right -> WaveOut
 *   restart game -> DoubleTap
 */ 
public class MyoInputManager : MonoBehaviour {
	// connect to gameManager
	private GameManager gm;
	void Awake ()
	{
		gm = GameObject.FindObjectOfType<GameManager> ();
	}

	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;

	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;
	
	// Update is called once per frame
	void Update () {
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;

			if (thalmicMyo.pose == Pose.Fist) {
				// Vibrate the Myo armband when a fist is made.
				thalmicMyo.Vibrate (VibrationType.Short);
				// down move
				gm.Move(MoveDirection.Down); 

				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.FingersSpread) {
				// Vibrate the Myo armband when a FingersSpread is made.
				thalmicMyo.Vibrate (VibrationType.Short);
				// up move
				gm.Move(MoveDirection.Up);

				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				// Vibrate the Myo armband when a WaveIn is made.
				thalmicMyo.Vibrate (VibrationType.Short);
				// left move
				gm.Move(MoveDirection.Left);

				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				// Vibrate the Myo armband when a WaveOut is made.
				thalmicMyo.Vibrate (VibrationType.Short);
				// right move
				gm.Move(MoveDirection.Right);

				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.DoubleTap) {
				// Vibrate the Myo armband when a DoubleTap is made.
				thalmicMyo.Vibrate (VibrationType.Medium);
				// Restart Game
				gm.NewGameButtonHandler ();
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}
		}
	}

	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;

		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}

		myo.NotifyUserAction ();
	}
}
