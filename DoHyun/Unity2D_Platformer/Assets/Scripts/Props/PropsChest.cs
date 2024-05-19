using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsChest : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemPrefabs; //생성되는 아이템 프리팹들
    [SerializeField]
    private int itemCount;  //상자에서 생성되는 아이템 개수
    [SerializeField]
    private Sprite openChestImage; //열린 상자 이미지

    private SpriteRenderer spriteRenderer;
    private bool isChestOpen = false;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isChestOpen == false && other.CompareTag("Player"))
        {
            isChestOpen = true;
            spriteRenderer.sprite = openChestImage;


            StartCoroutine(nameof(SpawnAllItems));
        }
    }


    private IEnumerator SpawnAllItems()
    {
        int count = 0;
        while (count < itemCount)
        {
            //0~itemPrefabs.Length-1까지 숫자 중 임의의 숫자를 뽑아 index 변수에 저장
            int index = Random.Range(0, itemPrefabs.Length);
            //아이템 오브젝트 생성
            GameObject item = Instantiate(itemPrefabs[index], transform.position, Quaternion.identity);

            //아이템 타일, 상자에서 생성된 아이템 처리를 위한 메소드인 'SpawnItemProcess()' 코루틴을 호출하는 메소드
            item.GetComponent<ItemBase>().Setup();
            //아이템 간에 간격을 두고 생성
            yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));

            count++;
        }

        float destoryTime = 2;
        //아이템 상자 페이드 효과
        StartCoroutine(FadeEffect.Fade(spriteRenderer, 1, 0, destoryTime));
        Destroy(gameObject, destoryTime);
    }

}
