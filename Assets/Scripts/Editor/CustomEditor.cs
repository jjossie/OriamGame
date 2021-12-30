
using UnityEngine;
using UnityEditor;

[UnityEditor.CustomEditor(typeof(LevelGenerator), false)]
public class CustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Draw Normal Inspector
        base.OnInspectorGUI();

        //Get References
        LevelGenerator level = (LevelGenerator)target;

        //Layout Options
        GUIStyle labels = new GUIStyle();
        labels.fontSize = 16;
        labels.fontStyle = FontStyle.Bold;

        //Layout
        EditorGUILayout.Space();

        //MapImage
        int mapImageSize = 4;
        EditorGUILayout.LabelField("LevelMap Image", labels);
        Texture2D enlargedImage = Instantiate(level.mapImage);
        TextureScale.Bilinear(enlargedImage, enlargedImage.width * mapImageSize, enlargedImage.height * mapImageSize);
        //EditorGUILayout.LabelField( new GUIContent(enlargedImage));

        level.mapImage = (Texture2D)EditorGUILayout.ObjectField("Image", level.mapImage, typeof(Texture2D), true);

        //GroundTileTemplates --- To-Do next: either implement this the way it is, or change the nature of GroundTile Templateing altogether. Maybe make a collection of groundtiletemplates instantiatable so the level can simply pick one? if you do that, maybe make them assignable to different ground-tile-pixel alpha values?

        //TileAssociations

        EditorGUILayout.LabelField("Tile Mappings", labels);
        EditorGUILayout.BeginHorizontal();
        int itemcount = 0;
        int columns = 3;
        float columnwidth = (EditorGUIUtility.currentViewWidth / columns) - 20;
        float imagewidth = 70;
        foreach (TileAssociation tileAssoc in level.tileAssociations.ToArray())
        {
            if (itemcount % columns == 0)
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
            }

            EditorGUILayout.BeginVertical();
            //Color Field
            tileAssoc.color = EditorGUILayout.ColorField(tileAssoc.color, GUILayout.Width(columnwidth));
            //Image Field
            if (tileAssoc.prefab != null && tileAssoc.prefab.GetComponent<SpriteRenderer>())
            {
                EditorGUILayout.LabelField(new GUIContent(tileAssoc.prefab.GetComponent<SpriteRenderer>().sprite.texture), new[] { GUILayout.Height(imagewidth), GUILayout.Width(columnwidth) });
            }
            else
            {
                EditorGUILayout.LabelField("", new[] { GUILayout.Height(imagewidth), GUILayout.Width(columnwidth) });
            }
            //Prefab field
            tileAssoc.prefab = (GameObject)EditorGUILayout.ObjectField(tileAssoc.prefab, typeof(GameObject), true, GUILayout.Width(columnwidth));
            if (GUILayout.Button("Delete Tile", GUILayout.Width(columnwidth)))
            {
                level.RemoveTileAssociation(tileAssoc);
            }
            EditorGUILayout.EndVertical();



            itemcount++;
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add New Tile"))
        {
            level.AddTileAssociation();
        }
        //End TileAssociations


    }

}
