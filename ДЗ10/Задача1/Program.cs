Knight knight = new Knight("Артур");
Mage mage = new Mage("Мерлин");

while (!knight.IsDead && !mage.IsDead)
{
    knight.Attack(mage);
    if (mage.IsDead) break;
    mage.Attack(knight);
}

if (mage.IsDead)
    Console.WriteLine($"Победил Рыцарь {knight.Name}!");
else
    Console.WriteLine($"Победил Маг {mage.Name}!");
