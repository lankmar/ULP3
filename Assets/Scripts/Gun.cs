using UnityEngine;

namespace Assets.Scripts
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private float _force = 150;

		private void Update()
		{
			if (!Input.GetMouseButtonDown(0)) return;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
			{
				var rb = hit.collider.GetComponent<Rigidbody>();
				if (rb != null)
				{
					rb.isKinematic = false;
					rb.AddForce(hit.collider.transform.forward * _force);
				}

				hit.collider.GetComponentInParent<Ragdoll>()?.Die();
			}
		}
	}
}