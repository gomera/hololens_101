using UnityEngine;
using UnityEngine.XR.WSA.Input;


public class GazeGestureManager : MonoBehaviour {

    // We will needed on the script that handle the gesture message
    public static GazeGestureManager Instance { get; private set; }

    // we want to keep track of the current gazed hologram
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer gestureRecognizer;

    private void Awake()
    {
        Instance = this;

        gestureRecognizer = new GestureRecognizer();
        gestureRecognizer.Tapped += (args) =>
        {
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
        };
        gestureRecognizer.StartCapturingGestures();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject oldObject = FocusedObject;

        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(headPosition, gazeDirection, out hit)) {
            // We get the hologram that we are looking at
            FocusedObject = hit.collider.gameObject;
        } else
        {
            FocusedObject = null;
        }

        // If we are looking at a different hologram, then we reset the gesture capturing
        if (FocusedObject != oldObject)
        {
            gestureRecognizer.CancelGestures();
            gestureRecognizer.StartCapturingGestures();
        }
	}
}
