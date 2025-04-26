using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rbTarget;
    public float torqueValue = 10f;
    public float forceValueMin = 10f;
    public float forceValueMax = 15f;
    public float xSpawnLimit = 3.5f;
    public float ySpawnLocation = -1f;
    public float yMapLimit = -2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbTarget = GetComponent<Rigidbody>();
        AddRandomForce(rbTarget);
        AddRandomTorque(rbTarget);
        SetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    void DestroyOutOfBounds() {
        if (transform.position.y < yMapLimit) {
            Destroy(gameObject);
        }
    }       
    void SetRandomPosition() {
        transform.position = new Vector3(Random.Range(-xSpawnLimit, xSpawnLimit), -1, 0);
    }

    void AddRandomForce(Rigidbody rbTarget) {
        float forceValue = Random.Range(forceValueMin, forceValueMax);
        rbTarget.AddForce(Vector3.up * forceValue, ForceMode.Impulse);
    }
    void AddRandomTorque(Rigidbody rbTarget) {
        rbTarget.AddTorque(Random.Range(-torqueValue, torqueValue), Random.Range(-torqueValue, torqueValue), Random.Range(-torqueValue, torqueValue));
    }
}
