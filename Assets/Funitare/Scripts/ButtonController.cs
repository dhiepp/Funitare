namespace Nhom7.Funitare
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.UI;

	public class ButtonController : MonoBehaviour
	{
		public Button CaptureBtn;
		public Button MenuBtn;
		public Button DeleteBtn;
		public GameObject MenuPanel;
		
		public GameObject PlaneGenerator;
		public GameObject PointCloud;

		public static GameObject SnackBar;
		private static float cd;
		private static bool showSB = false;

		void Start()
		{
			SnackBar = MenuPanel.transform.parent.GetChild(4).gameObject;
		}

		public void ClickCapture()
		{
			StartCoroutine(Capture());
		}

		private IEnumerator Capture()
		{
			SetUI(false);

			yield return new WaitForEndOfFrame();

			Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
			ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
			ss.Apply();

			// Save the screenshot to Gallery/Photos
			string name = string.Format(Application.productName + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
			Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName, name));

			SetUI(true);
			ShowSnackBar("Image Captured!");
		}

		private void SetUI(bool state)
		{
			CaptureBtn.gameObject.SetActive(state);
			MenuBtn.gameObject.SetActive(state);
			DeleteBtn.gameObject.SetActive(state);
			PlaneGenerator.SetActive(state);
			PointCloud.SetActive(state);
		}

		public void ClickMenu()
		{
			if (!MenuPanel.activeSelf) MenuPanel.SetActive(true);
			else MenuPanel.SetActive(false);
		}

		public void ClickDelete()
		{
			PawnController.deleteSelectedObject();
		}

		void Update()
		{
			if (showSB)
			{
				if (cd > 0) cd -= Time.deltaTime;
				if (cd < 0) HideSnackBar();
			}

		}

		public static void ShowSnackBar(string message)
		{
			SnackBar.GetComponentInChildren<Text>().text = message;
			SnackBar.SetActive(true);
			cd = 2;
			showSB = true;
		}

		public static void HideSnackBar()
		{
			SnackBar.SetActive(false);
			showSB = false;
		}
	}
}