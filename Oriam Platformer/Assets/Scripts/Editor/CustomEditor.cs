/*
using UnityEngine;
using UnityEditor;

[UnityEditor.CustomEditor(typeof(GroundTileGenerator), false)]
public class CustomEditor : Editor {
	public override void OnInspectorGUI() {
		EditorGUILayout.BeginHorizontal();

		GroundTileGenerator gtg = (GroundTileGenerator)target;

		if (GUILayout.Button("Generate Ground Tiles"))
			gtg.GenerateAllGroundTiles();

		EditorGUILayout.EndHorizontal();

		base.OnInspectorGUI();
	}

}
*/