using UnityEngine;
using System.Collections;

public class Singleton<T>:MonoBehaviour where T:MonoBehaviour{
	private static T _instance;
	private static object _lock = new object ();
	public static T Instance
	{
		get{ 
			if (applicationIsQutting) {
				return null;
			}
			lock (_lock) {
				if (_instance == null) {
					_instance = (T)FindObjectOfType (typeof(T));
					if (_instance == null) {
						GameObject singleton = new GameObject ();
						_instance = singleton.AddComponent<T> ();
						singleton.name = typeof(T).ToString()+"(singleton)";

					}
				}
				return _instance;
			}
		}
	}
	private static bool applicationIsQutting = false;
	public void OnDestory()
	{
		applicationIsQutting = true;
	}
}
