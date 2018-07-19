using UnityEngine;

public class CameraController : MonoBehaviour {

    public float sliceSpeed = 10f;
    private bool lookMoviment = false; // if it is true, key doesn't work
    private Vector3 startPosition;

    private void Start ()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update () {
        if (GameManager.gameEnded)  // it is used for disable the moviment when the game is ended
            return;
        if (Input.GetKeyDown(KeyCode.Z)) // Z is toggle, the commands for moviment can be disabled
            lookMoviment = !lookMoviment;
        if (lookMoviment) // you can access here only if command are not disabled
            return;
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * sliceSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * sliceSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * sliceSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * sliceSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.up * sliceSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            transform.Translate(Vector3.down * sliceSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.R))    // for return to initial position
            transform.position = startPosition;
	}
}
