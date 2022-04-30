#region

using UnityEngine;

#endregion

public class DirectionCalculator : MonoBehaviour {

    private Vector3 _normal;

    private void OnCollisionStay(Collision collision) {
        Vector3 tmpNormal = collision.contacts[0].normal;
        if(tmpNormal.y > 0.50) {
            _normal = tmpNormal;
        }
    }

    public Vector3 CalculateDirectionAlongSurface(Vector3 forward) {
        return forward - Vector3.Dot(forward, _normal) * _normal;
    }

    public Vector3 CalculateJumpDirection() { return (Vector3.up + _normal).normalized;
    }

}
