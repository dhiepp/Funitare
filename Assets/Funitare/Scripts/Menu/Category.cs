namespace Nhom7.Funitare
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class Category : MonoBehaviour
	{
		public GameObject categoryMenu;
		public GameObject itemMenu;

		public static string type = "";


		public void onClick(Text text)
		{
			type = text.text;
			categoryMenu.SetActive(false);
			itemMenu.SetActive(true);
		}
	}
}