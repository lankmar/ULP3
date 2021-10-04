using System;
using UnityEngine;

namespace Assets.Scripts
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;
		private static object _lock = new object();

		public static T Instance
		{
			get
			{
				#region То, что находится внутри конструкции lock
				//bool lockTaken = false;
				//Monitor.Enter(_syncRoot, ref lockTaken);
				//Monitor.Enter(_syncRoot);
				//Monitor.Wait(_syncRoot, 1000);
				//try
				//{

				//}
				//finally
				//{
				//    Monitor.Exit(_syncRoot);
				//} 
				#endregion

				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = (T)FindObjectOfType(typeof(T));

						if (FindObjectsOfType(typeof(T)).Length > 1)
						{
							Debug.LogError("[Singleton] Something went really wrong " +
										   " - there should never be more than 1 singleton!" +
										   " Reopening the scene might fix it.");
							return _instance;
						}

						if (_instance == null)
						{
							GameObject singleton = new GameObject();
							_instance = singleton.AddComponent<T>();
							singleton.name = String.Format("{0} {1}", "(singleton) ", typeof(T));

							DontDestroyOnLoad(singleton);

							Debug.Log("[Singleton] An instance of " + typeof(T) +
									  " is needed in the scene, so '" + singleton +
									  "' was created with DontDestroyOnLoad.");
						}
						else
						{
							Debug.Log("[Singleton] Using instance already created: " +
									  _instance.gameObject.name);
						}
					}

					return _instance;
				}
			}
		}
	}
}