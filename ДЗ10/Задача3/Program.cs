Unit unit = new Unit { Name = "Голем", HP = 200, Armor = 20 };

DamageSystem physicalSystem = new DamageSystem(new PhysicalDamageCalculator());
DamageSystem magicSystem = new DamageSystem(new MagicDamageCalculator());
DamageSystem fireSystem = new DamageSystem(new FireDamageCalculator());

physicalSystem.ApplyDamage(unit, 60);
magicSystem.ApplyDamage(unit, 60);
fireSystem.ApplyDamage(unit, 60);

Unit slime = new Unit { Name = "Слайм", HP = 100, Armor = 0 };
magicSystem.ApplyDamage(slime, 30);

// Вопрос для размышления: чтобы добавить новый тип урона (например, ледяной),
// нужно создать новый класс IceDamageCalculator, реализующий IDamageCalculator,
// и передать его в конструктор DamageSystem — DamageSystem менять не придётся,
// потому что он зависит от абстракции IDamageCalculator, а не от конкретных классов.
