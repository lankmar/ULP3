using UnityEngine;

public class Test : MonoBehaviour
{
	[SerializeField] private Animator _myAnim;
	[SerializeField] private float _speed;

	private void OnValidate()
	{
		_myAnim = GetComponent<Animator>();
	}

	public void Moving()
	{
		if(_myAnim != null)
			_myAnim.SetFloat("Speed", _speed);
	}

	private void Update()
	{

		Moving();
	}

}
