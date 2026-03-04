using System;
using System.Diagnostics;

// README.md를 읽고 코드를 작성하세요.

Console.WriteLine("=== 전투 시작 ===\n");
Character hero = new Character("용사", maxHp: 100, attackPower: 20);
Monster slime = new Monster("슬라임", maxHp: 30, attackPower: 5);
ProcessBattle(hero, slime);
ProcessBattle(slime, hero);
ProcessBattle(hero, slime);

Console.WriteLine("\n=== 고블린 등장 ===\n");
Monster goblin = new Monster("고블린", maxHp: 50, attackPower: 10);
ProcessBattle(hero, goblin);
ProcessBattle(goblin, hero);
ProcessBattle(hero, goblin);
ProcessBattle(hero, goblin);

void ProcessBattle(IAttacker attacker, IDefender defender)
{
    attacker.Attack(defender);

    Console.WriteLine($"{attacker.ToString()}(이/가) {defender.ToString()}에게 {attacker.AttackPower} 대미지! ({defender.ToString()} hp: {defender.CurrentHp}/{defender.MaxHp})");

    if (defender.IsDead)
    {
        Console.WriteLine($"{defender.ToString()}(이/가) 쓰러졌습니다!");
    }

}




interface IAttacker
{
    int AttackPower { get; }
    void Attack(IDefender target);
}
interface IDefender
{
    int CurrentHp { get; }
    int MaxHp { get; }
    bool IsDead { get; }
    void TakeDamage(int damage);
}
class Character : IAttacker, IDefender
{
    public string Name { get; private set; }
    public int CurrentHp { get; set; }
    public int MaxHp { get; set; }
    public int AttackPower { get; set; }
    public bool IsDead { get; set; }

    public Character(string name, int maxHp = 100, int attackPower = 20)
    {
        Name = name;
        MaxHp = maxHp;
        AttackPower = attackPower;
        CurrentHp = MaxHp;
    }

    public void Attack(IDefender target)
    {
        target.TakeDamage(AttackPower);
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp < 0)
        {
            CurrentHp = 0;
            IsDead = true;
            Console.WriteLine($"{Name}이(가) 쓰러졌습니다!");
        }
    }
    public override string ToString()
    {
        return $"{Name}";
    }
}

class Monster : IAttacker, IDefender
{
    public string Name { get; private set; }
    public int CurrentHp { get; set; }
    public int MaxHp { get; set; }
    public int AttackPower { get; set; }
    public bool IsDead { get; set; }

    public Monster(string name, int maxHp, int attackPower)
    {
        Name = name;
        MaxHp = maxHp;
        AttackPower = attackPower;
        CurrentHp = MaxHp;
    }

    public void Attack(IDefender target)
    {
        target.TakeDamage(AttackPower);
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp < 0)
        {
            CurrentHp = 0;
            IsDead = true;
        }
    }
    public override string ToString()
    {
        return $"{Name}";
    }
}