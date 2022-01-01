using UnityEngine;

public class InputState : MonoBehaviour
{

    public bool upButton;
    public bool leftButton;
    public bool rightButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rightButton = (Input.GetAxisRaw("Horizontal") > 0);
        leftButton = (Input.GetAxisRaw("Horizontal") < 0);
        upButton = (Input.GetAxisRaw("Vertical") > 0);

    }
}
