using UnityEngine;

public class CursorManager : MonoBehaviour {

    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(headPosition, gazeDirection, out hit))
        {
            meshRenderer.enabled = true;
            this.transform.position = hit.point;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        } else
        {
            meshRenderer.enabled = false; // Only show cursor if we are looking at a hologram
        }
	}
}
