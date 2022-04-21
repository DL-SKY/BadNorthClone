using UnityEngine;

namespace Test
{
    public class Generation : MonoBehaviour
    {
        [SerializeField] private Vector2Int _areaSize;
        [SerializeField] private Vector2 _offset;
        [SerializeField] private float _scaleNoise;
        [SerializeField] private int _seed;

        private float[,] _area;


        [ContextMenu("OnGenerate")]
        private void OnGenerate()
        {
            _area = new float[_areaSize.x, _areaSize.y];
            Generate(_area, _seed, _offset, _scaleNoise);
            LoggingArea(_area);
        }

        private void Generate(float[,] matrix, int seed, Vector2 offset, float scale)
        {
            System.Random rand = new System.Random(seed);

            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    var x1 = x * scale + offset.x;//(x + offset.x) * scale;
                    var y1 = y * scale + offset.y;//(y + offset.y) * scale;
                    matrix[x, y] = (int)(Mathf.PerlinNoise(x1, y1) * 10);
                }
        }

        private void LoggingArea(float[,] area)
        {
            var log = "";

            for (int x = 0; x < area.GetLength(0); x++)
            {
                log += "\n";
                for (int y = 0; y < area.GetLength(0); y++)
                    log += $"{area[x,y]}  ";
            }

            Debug.LogError(log);
        }
    }
}