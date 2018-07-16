using UnityEngine;

public class SphereCommands : MonoBehaviour {

    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = this.transform.localPosition;
    }

    void OnSelect()
    {
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidBody = this.gameObject.AddComponent<Rigidbody>();
            rigidBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        }
    }

    void OnReset()
    {
        var rigidbody = this.gameObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
            Destroy(rigidbody);
        }
        this.transform.localPosition = originalPosition;
    }

    void OnDrop()
    {
        OnSelect();
    }
}
