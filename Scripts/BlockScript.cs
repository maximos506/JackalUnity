using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject PreviousBlock;
    public float MoveCost;
    public bool IsShip;
    public bool CanChangeTexture = true;
    public bool isDiscovered;
    public bool isActivated;
    public bool HasPlayer;
    public bool HasMoney;
    public bool IsShelter;
    public int MoneyAmount;
    public int EffectID;
    public bool CantEnterWithMoney;
    float[] AngleValue = { 0, 90, 180, 270, 360 };
    public bool GiveRandomEffect;
    public bool IsDirectionalBlock;
    public int EffectsAmount = 41;
    public MeshRenderer RenderedComponent;
    public GameObject ScriptHolder;
    public MaterialsHolderScript MaterialsHolderComponent;
    public GameObject TextObject, CoinObject;
    public GameObject CreatedCoin,CoinTextObject;
    public List<GameObject> PlayersInBlock = new List<GameObject>();
    public TextMeshPro TMP;
    public bool IsOccupied;
    public int OccupyIndex;
    void Start()
    {
        //Cheat = true;
        int CheatInt = PlayerPrefs.GetInt("Cheat");
        if (CheatInt == 1)
        {
            isDiscovered = true;
        }
        MoveCost = 1000000;
        NoMoneyCheck();
        CoinObject = GameObject.Find("CoinModel");
        CreateCoin();
        ScriptHolder = GameObject.Find("ScriptsHolder");
        MaterialsHolderComponent = ScriptHolder.GetComponent<MaterialsHolderScript>();
        RenderedComponent = GetComponent<MeshRenderer> ();
        //GetRandomRotation();
        //SetEffect();
        //SetRotation();
        /*if (CanChangeTexture)
        {
            SetTexture();
        }*/
    }
    public void NoMoneyCheck() // блок на вход с монеткой
    {
        if (EffectID == 29)
        {
            CantEnterWithMoney = true;
        }
        if (EffectID == 30)
        {
            CantEnterWithMoney = true;
        }
    }
    public void CheckPlayers()
    {
        if (PlayersInBlock.Count > 0)
        {
            HasPlayer= true;
        }
        else
        {
            HasPlayer= false;
        }
    }
    public void AddPlayerToBlock(GameObject PlayerObject) // добавить игрока в блок
    {
        PlayersInBlock.Add(PlayerObject);
    }
    public void DeletePlayerFromBlock(GameObject PlayerObject) // убрать игрока из блока
    {
      PlayersInBlock.Remove(PlayerObject);

    }
    public void ShelterCheck() // проверка на укрытие
    {
        if (IsShelter)
        {
            IsOccupied = HasPlayer;
        }
        if (IsOccupied)
        {
            switch (PlayersInBlock[0].transform.tag)
            {
                case "Team1":
                    OccupyIndex = 1;
                    break;
                case "Team2":
                    OccupyIndex = 2;
                    break;
                case "Team3":
                    OccupyIndex = 3;
                    break;
                case "Team4":
                    OccupyIndex = 4;
                    break;
            }
        }
    }
    void CreateCoin() // создать монетку на блоке
    {
        CreatedCoin = Instantiate(CoinObject);
        CreatedCoin.transform.parent = gameObject.transform;
        CreatedCoin.transform.position = gameObject.transform.position + new Vector3(0, (0.6f), 0);
        CreatedCoin.SetActive(false);
        CoinTextObject = CreatedCoin.transform.GetChild(0).gameObject;
    }
    void CoinValue() 
    {
        TMP = CoinTextObject.GetComponent<TextMeshPro>();
        TMP.text = MoneyAmount.ToString();
    }
    public void SetEffect(int Effect) // присвоить эффект блоку
    {
        EffectID = Effect;
        if (EffectID > 0 && EffectID < 20)
        {
            IsDirectionalBlock = true;
        }
    }
    public void SetRotation() // установить вращение блоку
    {
        switch(EffectID)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, AngleValue[0], 0);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, AngleValue[1], 0);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0, AngleValue[3], 0); // 270
                break;
            case 5:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0); // 180
                break;
            case 6:
                transform.rotation = Quaternion.Euler(0, AngleValue[1], 0); // 90
                break;
            case 7:
                transform.rotation = Quaternion.Euler(0, AngleValue[3], 0); // 270
                break;
            case 8:
                transform.rotation = Quaternion.Euler(0, AngleValue[0], 0); // 0
                break;
            case 9:
                break;
            case 10:
                transform.rotation = Quaternion.Euler(0, AngleValue[3], 0);
                break;
            case 11:
                break;
            case 12:
                transform.rotation = Quaternion.Euler(0, AngleValue[1], 0);
                break;
            case 13:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 14:
                transform.rotation = Quaternion.Euler(0, AngleValue[3], 0);
                break;
            case 15:
                break; // без изменений
            case 16:
                transform.rotation = Quaternion.Euler(0, AngleValue[1], 0);
                break;
            case 17:
                break;
            case 18:
                break;
            case 19:
                break;
            case 20:
                break;
            case 21:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 22:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 23:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 24:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 25:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 31:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 32:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 33:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 34:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 35:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 38:
                transform.rotation = Quaternion.Euler(0, AngleValue[2], 0);
                break;
            case 39:
                transform.rotation = Quaternion.Euler(0, AngleValue[3], 0);
                break;
            case 40:
                transform.rotation = Quaternion.Euler(0, AngleValue[1], 0);
                break;
            case 41:
                transform.rotation = Quaternion.Euler(0, AngleValue[0], 0);
                break;
        }
    }
    public void SetTexture() // присвоить текстуру
    {
        if (isDiscovered)
        {
            switch(EffectID)
            {
                case 0:
                    RenderedComponent.material = MaterialsHolderComponent.GroundMat;
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    RenderedComponent.material = MaterialsHolderComponent.StraightArrow;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    RenderedComponent.material = MaterialsHolderComponent.DiagonalArrow;
                    break;
                case 9:
                case 10:
                    RenderedComponent.material = MaterialsHolderComponent.DiagonalBoth;
                    break;
                case 11:
                case 12:
                    RenderedComponent.material = MaterialsHolderComponent.SideArrow;
                    break;
                case 13:
                case 14:
                case 15:
                case 16:
                    RenderedComponent.material = MaterialsHolderComponent.TripleArrow;
                    break;
                case 17:
                    RenderedComponent.material = MaterialsHolderComponent.AllArrow;
                    break;
                case 18:
                    RenderedComponent.material = MaterialsHolderComponent.AllDiagonalArrow;
                    break;
                case 19:
                    RenderedComponent.material = MaterialsHolderComponent.HorseMove;
                    break;
                case 20:
                    RenderedComponent.material = MaterialsHolderComponent.Barrel;
                    break;
                case 21:
                    RenderedComponent.material = MaterialsHolderComponent.Maze2;
                    break;
                case 22:
                    RenderedComponent.material = MaterialsHolderComponent.Maze3;
                    break;
                case 23:
                    RenderedComponent.material = MaterialsHolderComponent.Maze4;
                    break;
                case 24:
                    RenderedComponent.material = MaterialsHolderComponent.Maze5;
                    break;
                case 25:
                    RenderedComponent.material = MaterialsHolderComponent.Ice;
                    break;
                case 26:
                    RenderedComponent.material = MaterialsHolderComponent.Trap;
                    break;
                case 27:
                    RenderedComponent.material = MaterialsHolderComponent.Crocodile;
                    break;
                case 28:
                    RenderedComponent.material = MaterialsHolderComponent.Killer;
                    break;
                case 29:
                    RenderedComponent.material = MaterialsHolderComponent.Fortress;
                    break;
                case 30:
                    RenderedComponent.material = MaterialsHolderComponent.Woman;
                    break;
                case 31:
                    RenderedComponent.material = MaterialsHolderComponent.Chest1;
                    break;
                case 32:
                    RenderedComponent.material = MaterialsHolderComponent.Chest2;
                    break;
                case 33:
                    RenderedComponent.material = MaterialsHolderComponent.Chest3;
                    break;
                case 34:
                    RenderedComponent.material = MaterialsHolderComponent.Chest4;
                    break;
                case 35:
                    RenderedComponent.material = MaterialsHolderComponent.Chest5;
                    break;
                case 36:
                    RenderedComponent.material = MaterialsHolderComponent.Balloon;
                    break;
                case 37:
                    RenderedComponent.material = MaterialsHolderComponent.Plane;
                    break;
                case 38:
                    RenderedComponent.material = MaterialsHolderComponent.Cannon;
                    break;
                case 39:
                    RenderedComponent.material = MaterialsHolderComponent.Cannon;
                    break;
                case 40:
                    RenderedComponent.material = MaterialsHolderComponent.Cannon;
                    break;
                case 41:
                    RenderedComponent.material = MaterialsHolderComponent.Cannon;
                    break;
            }
        }
        else
        {
            RenderedComponent.material = MaterialsHolderComponent.UnDiscovered;
        }
    }
    void GetRandomRotation() // случайное вращение
    {
        transform.rotation = Quaternion.Euler(0, AngleValue[Random.Range(0, AngleValue.Length)], 0);
    }
    void MoneyCheck() // проверка на монету
    {
        if (MoneyAmount > 0)
        {
            HasMoney= true;
            CreatedCoin.SetActive(true);
            CoinValue();
        }
        else
        {
            HasMoney= false;
            CreatedCoin.SetActive(false);
        }
    }
    void Update()
    {
        MoneyCheck();
        CheckPlayers();
        ShelterCheck();
        if (IsShip == false)
        {
            SetTexture();
            SetRotation();
        }
    }
}
