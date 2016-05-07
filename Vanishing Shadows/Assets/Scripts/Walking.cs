using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class Walking : MonoBehaviour {
	public int slider;

	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward; 
	private Vector3 m_Move;
	float m_MovingTurnSpeed = 360;
	float m_StationaryTurnSpeed = 180;
	float m_TurnAmount;
	float m_ForwardAmount;
	Vector3 m_GroundNormal;

	public Animator anim;
	// Use this for initialization
	public float turnSmoothing = 15f;
	public float speedDampTime = 0.1f; 
	public float walk = 0.3f;
	void Start () {
		m_Cam = Camera.main.transform;
		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		//anim.SetFloat ("Blend", walk);
		float targetRotation = h;

		m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
		m_Move = v*m_CamForward + h*m_Cam.right;
		//transform.Rotate (0.0f, targetRotation * 100 * Time.deltaTime, 0.0f);
		Move(m_Move);
		//transform.Translate (Vector3.forward * slider * Time.deltaTime);
		//transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime * slider,0f,Input.GetAxis("Vertical")*Time.deltaTime * slider);
	}
	public void Move(Vector3 move)
	{
		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f) move.Normalize();
		move = transform.InverseTransformDirection(move);
		move = Vector3.ProjectOnPlane(move, m_GroundNormal);
		m_TurnAmount = Mathf.Atan2(move.x, move.z);
		m_ForwardAmount = move.z;
		float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
		transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
		transform.Translate (move * Time.deltaTime * slider);
	}
	// Update is called once per frame
	void Update () {


	}
}
=======
public class Walking : MonoBehaviour
{
    public int slider;

    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;
    private Vector3 m_Move;
    float m_MovingTurnSpeed = 360;
    float m_StationaryTurnSpeed = 180;
    float m_TurnAmount;
    float m_ForwardAmount;
    Vector3 m_GroundNormal;

    public Animator anim;
    // Use this for initialization
    public float turnSmoothing = 15f;
    public float speedDampTime = 0.1f;
    public float walk = 0.3f;
    void Start()
    {
        m_Cam = Camera.main.transform;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //anim.SetFloat ("Blend", walk);
        float targetRotation = h;

        m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
        m_Move = v * m_CamForward + h * m_Cam.right;
        //transform.Rotate (0.0f, targetRotation * 100 * Time.deltaTime, 0.0f);
        Move(m_Move);
        //transform.Translate (Vector3.forward * slider * Time.deltaTime);
        //transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime * slider,0f,Input.GetAxis("Vertical")*Time.deltaTime * slider);
    }
    public void Move(Vector3 move)
    {
        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (move.magnitude > 1f) move.Normalize();
        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);
        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
        transform.Translate(move * Time.deltaTime * slider);
    }
    // Update is called once per frame
    void Update()
    {


    }
}
>>>>>>> origin/master
