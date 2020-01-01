namespace Nhom7.Funitare
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class PawnController : MonoBehaviour
	{
		public static GameObject SelectedModel;
		public static List<GameObject> SpawnedObjects = new List<GameObject>();

		void Start()
		{

		}

		public static void deleteSelectedObject()
		{
			foreach (GameObject del in SpawnedObjects)
			{
				if (del.GetComponent<Manipulator>().IsSelected())
				{
					Destroy(del.transform.parent.gameObject);
					SpawnedObjects.Remove(del);

					SoundController.PlayPopSound();
				}
			}
		}

		public static void selectModel(string type, string name)
		{
			SelectedModel = Resources.Load<GameObject>("Models/" + type + "/" + name);
		}
	}
}