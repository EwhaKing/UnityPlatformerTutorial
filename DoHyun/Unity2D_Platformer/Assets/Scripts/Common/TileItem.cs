using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileItem : TileBase
{
    [Header("Tile Item")]
    [SerializeField]
    private ItemType itemType = ItemType.Random; //아이템의 속성
    [SerializeField]
    private GameObject[] itemPrefabs;//아이템 타일과 상호작용 했을 때 생성되는 아이템 프리팹을 저장하는 itemPrefabs 배열
    [SerializeField]
    private int coinCount; //아이템의 속성이 코인일 때 코인 개수를 나타내는 coinCount
    [SerializeField]
    private Sprite nonBrokeImage; //아이템 타일의 모든 아이템이 소진되었을 때 출력하는 부서지지 않는 타일 이미지

    private bool isEmpty = false; //아이템 타일에 더 이상 아이템이 없으면 true, 있으면 false



    public override void UpdateCollision()
    {
        //isEmpty가 true면 아이템 타일이 비어있다는 뜻이므로 
        //NonBroke와 동일하게 상호작용 없음. 메소드 내부 코드를 실행하지 않고 return한다.
        if (isEmpty) return;

        //부모의 UpdateCollision() 호출
        base.UpdateCollision();

        //아이템 스폰(오버라이딩 부분)
        SpawnItem();

    }
    private void SpawnItem()
    {
        //아이템의 속성(itemType)이 random이면 임의의 아이템으로 속성을 변경한다.
        if (itemType == ItemType.Random)
        {
            itemType = (ItemType)Random.Range(0, itemPrefabs.Length);
        }
        //Instantiate() 메소드를 호출해 아이템 오브젝트를 아이템 타일의 위치(transform.position)에 생성한다.
        Instantiate(itemPrefabs[(int)itemType], transform.position, Quaternion.identity);

        //아이템이 Coin이면 아이템 타일이 소지하고 있는 코인 개수를 1 감소시킨다.
        if (itemType == ItemType.Coin)
        {
            coinCount--;
        }


        //아이템 속성이 코인이 아닐 때는 아이템이 1개만 들어있고, 코인일 때는 coinCount 개수만큼 들어있다.
        //따라서 아이템 속성이 코인이 아니거나, 들어있는 코인 개수가 0개인 경우
        if (itemType != ItemType.Coin || (itemType == ItemType.Coin && coinCount == 0))
        {
            GetComponent<SpriteRenderer>().sprite = nonBrokeImage; //아이템 타일의 이미지를 빈 타일 이미지로 변경
            isEmpty = true; //아이템 타일이 비어있음으로 설정
        }
    }



}
