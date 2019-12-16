namespace Nhom7.Funitare
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class Item : MonoBehaviour
	{
		private List<string> itemList = new List<string>();
		public GameObject obj;
		public GameObject MenuPanel;
		public GameObject categoryMenu;
		public GameObject itemMenu;
		public GameObject content;

		private bool check = false;
		// Start is called before the first frame update
		void Start()
		{
			init();
		}

		private void Update()
		{
			if (check)
			{
				init();
				check = false;
			}
		}

		public void back()
		{
			foreach (Transform child in content.transform)
			{
				Destroy(child.gameObject);
			}
			categoryMenu.SetActive(true);
			itemMenu.SetActive(false);
			check = true;
			Debug.Log("CLICKED back");
		}

		private void init()
		{
			string type = Category.type;
			if (type.Length == 0) return;

			Sprite[] sprites = Resources.LoadAll<Sprite>("Images/" + type + "/");
			int n = sprites.Length;

			int contentWidth = n * 100 + (n - 1) * 30;
			content.GetComponent<RectTransform>().sizeDelta = new Vector2(contentWidth, 100);
			for (int i = 0; i < n; i++)
			{
				GameObject item = Instantiate(obj);
				item.transform.SetParent(content.transform);

				int posX = -(contentWidth / 2) + i * 130 + 50;
				item.transform.localPosition = new Vector2(posX, 0);
				item.transform.localScale = new Vector2(1,1);

				string name = sprites[i].name;
				item.GetComponentInChildren<Text>().text = name;
				item.GetComponent<Image>().sprite = sprites[i];

				item.GetComponentInChildren<Button>().onClick.AddListener(delegate
				{
					PawnController.selectModel(type, name);
					MenuPanel.SetActive(false);
				});
			}

			content.transform.localPosition = new Vector2(n*50, 0);
		}
	}
}