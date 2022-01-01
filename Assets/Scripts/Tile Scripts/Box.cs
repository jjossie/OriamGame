using UnityEngine;

public class Box : MonoBehaviour
{
    private FlowController flow;
    // Start is called before the first frame update
    void Start()
    {
        FlowController sceneFlowController = FindObjectOfType<FlowController>();
        flow = sceneFlowController;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        float colliderOffset = collider.GetComponentInParent<BoxCollider2D>().size.y / 2.0f;
        float boxOffset = boxCollider.size.y / 2.0f;

        if ((collider.transform.position.y + colliderOffset) < (transform.position.y - boxOffset))
        {
            Debug.Log("Box hit from the bottom");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
