# 게임 캐릭터 시스템

게임 캐릭터와 몬스터가 전투하는 시스템을 인터페이스를 활용하여 구현합니다.

### 요구사항

**1. IAttacker 인터페이스 정의**

공격 능력을 가진 객체를 나타내는 인터페이스:

- `int AttackPower { get; }` - 공격력을 반환하는 읽기 전용 속성
- `void Attack(IDefender target)` - 대상에게 공격을 가하는 메서드

**2. IDefender 인터페이스 정의**

방어 능력을 가진 객체를 나타내는 인터페이스:

- `int CurrentHp { get; }` - 현재 체력을 반환하는 읽기 전용 속성
- `int MaxHp { get; }` - 최대 체력을 반환하는 읽기 전용 속성
- `bool IsDead { get; }` - 사망 여부를 반환하는 읽기 전용 속성
- `void TakeDamage(int damage)` - 대미지를 받는 메서드

**3. Character 클래스 구현**

IAttacker와 IDefender를 모두 구현하는 플레이어 캐릭터:

- 이름(Name), 최대 체력(MaxHp: 100), 공격력(AttackPower: 20)
- Attack 메서드: 대상에게 대미지를 주고 결과 출력
- TakeDamage 메서드: 대미지를 받고 남은 체력 출력

**4. Monster 클래스 구현**

IAttacker와 IDefender를 모두 구현하는 몬스터:

- 이름(Name), 최대 체력(MaxHp), 공격력(AttackPower)을 생성자에서 받음
- Character와 동일하게 Attack, TakeDamage 구현

**5. 전투 함수 구현**

`void ProcessBattle(IAttacker attacker, IDefender defender)` 함수를 구현하여 전투를 처리:

- IAttacker가 IDefender에게 공격

## 예상 실행 결과

```
=== 전투 시작 ===

용사(이/가) 슬라임에게 20 대미지! (슬라임 HP: 10/30)
슬라임(이/가) 용사에게 5 대미지! (용사 HP: 95/100)
용사(이/가) 슬라임에게 20 대미지! (슬라임 HP: 0/30)
슬라임(이/가) 쓰러졌습니다!

=== 고블린 등장 ===

용사(이/가) 고블린에게 20 대미지! (고블린 HP: 30/50)
고블린(이/가) 용사에게 10 대미지! (용사 HP: 85/100)
용사(이/가) 고블린에게 20 대미지! (고블린 HP: 10/50)
용사(이/가) 고블린에게 20 대미지! (고블린 HP: 0/50)
고블린(이/가) 쓰러졌습니다!
```
