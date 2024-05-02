public enum ItemType
{
    //임의의 아이템이 나오길 원할 때는 Random을 사용
    //0부터 순서대로 coin, invincibility, hp potion, projectile, star를 나타낸다.
    //변수 값을 0부터 순서대로 저장했기 때문에 마지막 아이템인 Star 뒤에 있는 Count의 값은 아이템 개수를 뜻한다.

    Random = -1,
    Coin = 0,
    invincibility,
    HPPotion,
    Projectile,
    Star,
    Count

}