using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    private int Width;
    private int Height;
    public Point PointPrefab;
    public Canvas canvas;
    public Dropdown dropdown;
    public Button button;    
    private int cont;
    private Point _initialPoint;
    public Line LinePrefab;
    private Point _finalPoint;


    private void Awake()
    {
        Instance = this;
        cont=2;
    }
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => {
            canvas.gameObject.SetActive(false);
            int value = dropdown.value;
            int tam = int.Parse(dropdown.options[value].text); 
            GenerateBoard(tam, tam);
        });
    }

    private void GenerateBoard(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                var p = new Vector2(i, j);
                Instantiate(PointPrefab, p, Quaternion.identity);
            }
        }
        var center = new Vector2((float)Height/2 - 0.5f, (float)Width/2 - 0.5f);
        Camera.main.orthographicSize = (float)Height/ 2 + 1.5f;
        Camera.main.transform.position = new Vector3(center.x, center.y, -5);

    }

    public void setPoint(Point p){
        GameManager.Instance.SwitchPlayer();
        cont-=1;
        if (cont == 0)
        {
            _initialPoint = p;
            cont = 2;
            var line = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
            //Vertical arriba
            if (_finalPoint.GetComponent<Transform>().position.y - _initialPoint.GetComponent<Transform>().position.y==1)
            {

                line.transform.position = _initialPoint.GetComponent<Transform>().position + new Vector3(0, 0.5f, 0);
                line.transform.Rotate(0,0,180);
            }else{
                //Vertical abajo
                if (_finalPoint.GetComponent<Transform>().position.y - _initialPoint.GetComponent<Transform>().position.y==-1)
                {
                    line.transform.position = _initialPoint.GetComponent<Transform>().position - new Vector3(0, 0.5f, 0);
                line.transform.Rotate(0,0,180);
                }else{
                    //Horizontal derecha
                    if (_finalPoint.GetComponent<Transform>().position.x - _initialPoint.GetComponent<Transform>().position.x==-1)
                {
                    line.transform.position = _initialPoint.GetComponent<Transform>().position - new Vector3(0.5f, 0, 0);
                    line.transform.Rotate(0,0,90);
                }else{
                        //Horizontal izquierda
                        
                            line.transform.position = _initialPoint.GetComponent<Transform>().position + new Vector3(0.5f, 0, 0);
                            line.transform.Rotate(0,0,90);
                        
    
                    }
                }
            }
            

        }else
        {
            _finalPoint = p;
        }
    }
}
