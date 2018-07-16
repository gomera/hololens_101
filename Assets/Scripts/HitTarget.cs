using UnityEngine;

public class HitTarget : MonoBehaviour {

    public GameObject underworld;
    public GameObject objectToHide;

    private void OnCollisionExit(Collision collision)
    {
        objectToHide.SetActive(false);
        underworld.SetActive(true);

        SpatialMapping.Instance.MappingEnabled = false;
    }
}
