using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
	Mesh mesh;
	List<Vector3> vertices = new List<Vector3>();
	List<int> triangles = new List<int>();
	List<Vector2> uv = new List<Vector2>();

	Coroutine coroutin;

	public void GenerateMesh(int height, int width)
	{
		if (coroutin != null)
		{
			StopCoroutine(coroutin);
		}

		transform.position = new Vector3(-width / 2, 0, -height / 2);
		GenerateTexture(height, width);
		coroutin = StartCoroutine(GenerateMesh2(height, width));
	}

	public IEnumerator GenerateMesh2(int height, int width)
	{
		vertices.Clear();
		triangles.Clear();
		int squaresAmount = height * width;

		// vertices
		for (int z = 0; z < height + 1; ++z)
		{
			for (int x = 0; x < width + 1; ++x)
			{
				vertices.Add(new Vector3(x, 0, z));
			}
		}

		// squares
		for (int i = 0; i < squaresAmount; ++i)
		{
			int j = i + i / width;

			// triangle 1
			triangles.Add(j);
			triangles.Add(j + width + 1);
			triangles.Add(j + 1);

			yield return new WaitForSeconds(.02f);

			// triangle 2
			triangles.Add(j + 1);
			triangles.Add(j + width + 1);
			triangles.Add(j + width + 2);

			yield return new WaitForSeconds(.02f);
		}
	}

	private void GenerateTexture(int height, int width)
	{
		uv.Clear();

		for (int z = 0; z < height + 1; ++z)
		{
			for (int x = 0; x < width + 1; ++x)
			{
				uv.Add(new Vector2((float)x / width, (float)z / height));
			}
		}
	}

	private void UpdateMesh()
	{
		mesh.Clear();

		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uv.ToArray();
	}

	// Unity
	private void Update()
	{
		UpdateMesh();
	}

	private void Start()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
	}
}