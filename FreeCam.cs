using UnityEngine;

public class FreeCam : MonoBehaviour
{
	const int MOUSE_LEFT_BUTTON = 0;
	const int MOUSE_RIGHT_BUTTON = 1;

	/// <summary>
	/// Mouse sensitivity.
	/// Default 0.3.
	/// </summary>
	public float MouseSensitivity = 0.3f;

	/// <summary>
	/// Keyboard sensitivity.
	/// Default 5.0.
	/// </summary>
	public float KeyboardSensitivity = 5.0f;

	/// <summary>
	/// Last position of the mouse.
	/// </summary>
	private Vector3 _lastMousePosition;

	private void Awake()
	{
		_lastMousePosition = new Vector3(0, 0, 0);
	}

	private void Start()
	{
		//
	}

	private void Update()
	{
		HandleMouse();
		HandleKeyboard();
	}

	private void HandleMouse()
	{
		Vector3 cursorDelta = Input.mousePosition - _lastMousePosition;
		cursorDelta = new Vector3(-cursorDelta.y * MouseSensitivity, cursorDelta.x * MouseSensitivity, 0);
		cursorDelta = new Vector3(transform.eulerAngles.x + cursorDelta.x, transform.eulerAngles.y + cursorDelta.y, 0);

		if (Input.GetMouseButton(MOUSE_RIGHT_BUTTON))
		{
			transform.eulerAngles = cursorDelta;
		}

		_lastMousePosition = Input.mousePosition;
	}

	private void HandleKeyboard()
	{
		Vector3 position = new Vector3();

		if (Input.GetKey(KeyCode.Q)) position += Vector3.down;
		if (Input.GetKey(KeyCode.E)) position += Vector3.up;
		if (Input.GetKey(KeyCode.W)) position += Vector3.forward;
		if (Input.GetKey(KeyCode.A)) position += Vector3.left;
		if (Input.GetKey(KeyCode.S)) position += Vector3.back;
		if (Input.GetKey(KeyCode.D)) position += Vector3.right;

		position = position * Time.deltaTime * KeyboardSensitivity;

		transform.Translate(position);
	}
}