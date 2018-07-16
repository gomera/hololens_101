using UnityEngine;

public class MoveStageHandler : MonoBehaviour {

    bool placing = false;

    void OnSelect()
    {
        placing = !placing;
        SpatialMapping.Instance.DrawVisualMeshes = placing;    
    }

	void Update () {
		if (placing)
        {
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit raycast;
            if (Physics.Raycast(headPosition, gazeDirection, out raycast, 30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                this.transform.parent.position = raycast.point;
                Quaternion to = Camera.main.transform.localRotation;
                to.x = 0;
                to.y = 0;
                this.transform.parent.rotation = to;
            }
        }
	}
}
