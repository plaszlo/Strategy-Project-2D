using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    public const int sortingOrderDefault = 5000;

    public Grid(int width, int height, float cellSize){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        
        gridArray = new int[width, height];

        for(int x = 0; x < gridArray.GetLength(0); x++){
            for(int y = 0; y < gridArray.GetLength(1); y++){
                CreateWorldText(gridArray[x,y].ToString(), null, getWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(getWorldPosition(0, height), getWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(getWorldPosition(width, 0), getWorldPosition(width, height), Color.white, 100f);
    }

        // Create Text in the World - pasted from CodeMonkey Utils (Utils not added as package)
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault) {
            if (color == null) color = Color.white;
            return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }
        
        // Create Text in the World - pasted from CodeMonkey Utils (Utils not added as package)
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder) {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }

        private Vector3 getWorldPosition(int x, int y){
            return new Vector3(x, y) * cellSize;
        }
}
