using System;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
#pragma warning disable 0649

	[SerializeField] MeshGenerator meshGenerator;
	[SerializeField] Text height;
	[SerializeField] Text width;
	[SerializeField] Button generateMesh;

#pragma warning restore 0649

	// Events
	private void GenerateMesh()
	{
		int height = Int32.Parse(this.height.text);
		int width = Int32.Parse(this.width.text);

		meshGenerator.GenerateMesh(height, width);
	}

	// Unity
	private void Start()
	{
		generateMesh.onClick.AddListener(GenerateMesh);
	}
}