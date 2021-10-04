using UnityEngine;

namespace Assets.Scripts
{
	public class TestSingleton : MonoBehaviour
	{
		private void Start()
		{
			Main.Instance.NameMethod();
		}
	}
}