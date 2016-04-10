using UnityEngine;
using System.Collections;

public class SudokuGrid : MonoBehaviour
{
    public Transform sectionPrefab, cellPrefab;
    void Start()
    {
        int[] values = { 8, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 3, 6, 0, 0, 0, 0, 0,
                    0, 7, 0, 0, 9, 0, 2, 0, 0,
                    0, 5, 0, 0, 0, 7, 0, 0, 0,
                    0, 0, 0, 0, 4, 5, 7, 0, 0,
                    0, 0, 0, 1, 0, 0, 0, 3, 0,
                    0, 0, 1, 0, 0, 0, 0, 6, 8,
                    0, 0, 8, 5, 0, 0, 0, 1, 0,
                    0, 9, 0, 0, 0, 0, 4, 0, 0};
	    for(int i=0; i<9; i++)
        {
            Transform sectionTransform = Instantiate<Transform>(sectionPrefab);
            sectionTransform.parent = transform;
            for(int j=0; j<9; j++)
            {
                int x = (i % 3) * 3 + j % 3;
                int y = (i / 3) * 3 + j / 3;
                Transform cellTransform = Instantiate<Transform>(cellPrefab);
                cellTransform.parent = sectionTransform;
                cellTransform.GetComponent<SudokuCell>().SetValue(values[x + y * 9]);
            }
        }
	}
	
	void Update ()
    {
	
	}
}
