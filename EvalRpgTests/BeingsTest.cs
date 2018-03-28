using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{
    [TestClass]
    public class BeingsTest
    {
        public Unit GetPerso(string name)
        {
            Weapon stick = new Weapon("God Rod", false);
            Unit personnage = new Unit(name, null, null, stick);

            /* Configuration du stat manager */
            personnage.StatManager.BaseAttributes[AttributeEnum.Agility] = 20;
            personnage.StatManager.BaseAttributes[AttributeEnum.Strength] = 30;
            personnage.StatManager.BaseAttributes[AttributeEnum.Intelligence] = 15;

            /* Ajout de l'armure */
            AttributEffect att = new AttributEffect
            {
                Attribute = AttributeEnum.Strength,
                Value = 10
            };

            Armor head = new Armor("Casque", ArmorType.Head, 5);
            head.AddAttributEffects(att);
            personnage.Equipement.Add(ArmorType.Head, head);
            Armor hands = new Armor("Gants", ArmorType.Hands, 3);
            hands.AddAttributEffects(att);
            personnage.Equipement.Add(ArmorType.Hands, hands);
            Armor chest = new Armor("Plastron", ArmorType.Chest, 3);
            chest.AddAttributEffects(att);
            personnage.Equipement.Add(ArmorType.Chest, chest);
            Armor boots = new Armor("Bottes", ArmorType.Legs, 3);
            boots.AddAttributEffects(att);
            personnage.Equipement.Add(ArmorType.Legs, boots);
            personnage.UpdateStats();
            return personnage;
        }


        [TestMethod]
        public void TestCreateArmor()
        {
            Armor armor = new Armor("Solomonk", ArmorType.Head, 20);
            AttributEffect att = new AttributEffect();
            att.Attribute = AttributeEnum.Agility;
            att.Value = 20;
            armor.AddAttributEffects(att);
            att.Attribute = AttributeEnum.Intelligence;
            att.Value = 20;
            armor.AddAttributEffects(att);

            Assert.AreEqual(armor.Name, "Solomonk");
            Assert.AreEqual(armor.Type, ArmorType.Head);
            Assert.IsTrue(armor.StatusEffects.Count == 2);

        }

        [TestMethod]
        public void TestCreateWeapon()
        {
            Weapon stick = new Weapon("God Rod", true);
            AttributEffect att = new AttributEffect();
            att.Attribute = AttributeEnum.Strength;
            att.Value = 10;
            stick.AddAttributEffects(att);
            att.Attribute = AttributeEnum.Intelligence;
            att.Value = 20;
            stick.AddAttributEffects(att);

            Assert.AreEqual(stick.Name, "God Rod");
            Assert.IsTrue(stick.IsMagic);
            Assert.IsTrue(stick.StatusEffects.Count == 2);
        }



        [TestMethod]
        public void TestCurrentAttributes()
        {
            Unit personnage = GetPerso("Albert");
            /* Calcul des resultat attendus */
            int forceAttendu = personnage.StatManager.BaseAttributes[AttributeEnum.Strength];
            int intelAttendu = personnage.StatManager.BaseAttributes[AttributeEnum.Intelligence];
            int agiAttendu = personnage.StatManager.BaseAttributes[AttributeEnum.Agility];
            foreach (AttributEffect a in personnage.Equipement[ArmorType.Head].StatusEffects)
            {
                switch (a.Attribute)
                {
                    case AttributeEnum.Strength:
                        forceAttendu += a.Value;
                        break;
                    case AttributeEnum.Intelligence:
                        intelAttendu += a.Value;
                        break;
                    case AttributeEnum.Agility:
                        agiAttendu += a.Value;
                        break;
                }
            }
            foreach (AttributEffect a in personnage.Equipement[ArmorType.Hands].StatusEffects)
            {
                switch (a.Attribute)
                {
                    case AttributeEnum.Strength:
                        forceAttendu += a.Value;
                        break;
                    case AttributeEnum.Intelligence:
                        intelAttendu += a.Value;
                        break;
                    case AttributeEnum.Agility:
                        agiAttendu += a.Value;
                        break;
                }
            }
            foreach (AttributEffect a in personnage.Equipement[ArmorType.Legs].StatusEffects)
            {
                switch (a.Attribute)
                {
                    case AttributeEnum.Strength:
                        forceAttendu += a.Value;
                        break;
                    case AttributeEnum.Intelligence:
                        intelAttendu += a.Value;
                        break;
                    case AttributeEnum.Agility:
                        agiAttendu += a.Value;
                        break;
                }
            }
            foreach (AttributEffect a in personnage.Equipement[ArmorType.Chest].StatusEffects)
            {
                switch (a.Attribute)
                {
                    case AttributeEnum.Strength:
                        forceAttendu += a.Value;
                        break;
                    case AttributeEnum.Intelligence:
                        intelAttendu += a.Value;
                        break;
                    case AttributeEnum.Agility:
                        agiAttendu += a.Value;
                        break;
                }
            }

            /* Comparaison des valeurs */
            Assert.AreEqual(forceAttendu, personnage.GetCurrentAttribute(AttributeEnum.Strength));
            Assert.AreEqual(agiAttendu, personnage.GetCurrentAttribute(AttributeEnum.Agility));
            Assert.AreEqual(intelAttendu, personnage.GetCurrentAttribute(AttributeEnum.Intelligence));
        }

        [TestMethod]
        public void TestBaseStatistics()
        {
            Unit personnage = GetPerso("John");

            Assert.AreEqual(70, personnage.GetCurrentAttribute(AttributeEnum.Strength));
            Assert.AreEqual(20, personnage.GetCurrentAttribute(AttributeEnum.Agility));
            Assert.AreEqual(15, personnage.GetCurrentAttribute(AttributeEnum.Intelligence));

            Assert.AreEqual(701, personnage.StatManager.BaseStatistics[StatisticsEnum.Health]);
            Assert.AreEqual(31, personnage.StatManager.BaseStatistics[StatisticsEnum.MagicalDamange]);
            Assert.AreEqual(41, personnage.StatManager.BaseStatistics[StatisticsEnum.MagicalResistance]);
            Assert.AreEqual(151, personnage.StatManager.BaseStatistics[StatisticsEnum.Mana]);
            Assert.AreEqual(141, personnage.StatManager.BaseStatistics[StatisticsEnum.PhysicalDamage]);
            Assert.AreEqual(41, personnage.StatManager.BaseStatistics[StatisticsEnum.PhysicalResistance]);
            Assert.AreEqual(201, personnage.StatManager.BaseStatistics[StatisticsEnum.Stamina]);
        }

        [TestMethod]
        public void TestTakeDamage()
        {
            Unit personnage = GetPerso("Sam");
            Unit personnage1 = GetPerso("Pounch");

            int damage = 0;
            if (personnage.Weapon.IsMagic)
            {
                damage = personnage.Weapon.Damage + personnage.StatManager.BaseStatistics[StatisticsEnum.MagicalDamange];
            }
            else
            {
                damage = personnage.Weapon.Damage + personnage.StatManager.BaseStatistics[StatisticsEnum.PhysicalDamage];
            }
            personnage.StatManager.CurrentStatistics = personnage.StatManager.BaseStatistics;
            personnage1.StatManager.CurrentStatistics = personnage1.StatManager.BaseStatistics;
            personnage1.TakeDamage(damage, false, personnage);

            Assert.AreEqual(601, personnage1.GetCurrentStat(StatisticsEnum.Health));
        }

        [TestMethod]
        public void TestSkills()
        {
            Unit personnage = GetPerso("Sam");
            Unit personnage1 = GetPerso("Pounch");
            Skill skill = new SkillTest(personnage);

            personnage.Skills.Add(skill);

            personnage.StatManager.CurrentStatistics = personnage.StatManager.BaseStatistics;
            personnage1.StatManager.CurrentStatistics = personnage1.StatManager.BaseStatistics;

            Assert.AreEqual(701, personnage1.GetCurrentStat(StatisticsEnum.Health));
            Assert.AreEqual(201, personnage.GetCurrentStat(StatisticsEnum.Stamina));
            personnage.UseSkill(skill, personnage1);
            Assert.AreEqual(672, personnage1.GetCurrentStat(StatisticsEnum.Health));
            Assert.AreEqual(191, personnage.GetCurrentStat(StatisticsEnum.Stamina));
        }

        [TestMethod]
        public void TestAttack()
        {
            Unit personnage = GetPerso("Georges");
            Unit personnage1 = GetPerso("Hubert");
            personnage.StatManager.CurrentStatistics = personnage.StatManager.BaseStatistics;
            personnage1.StatManager.CurrentStatistics = personnage1.StatManager.BaseStatistics;
            Assert.AreEqual(701, personnage1.GetCurrentStat(StatisticsEnum.Health));
            personnage.Attack(personnage1);
            Assert.AreEqual(601, personnage1.GetCurrentStat(StatisticsEnum.Health));
        }
    }

    internal class SkillTest : Skill
    {
        public SkillTest(Unit caster) : base(caster)
        {
            Name = "Test";
            Description = "Test.";
            Cost = 10;
            StatisticReference = StatisticsEnum.Stamina;
            Ability = Effect;
        }

        private bool Effect(Unit target)
        {
            int baseDamage = ComputePower();
            target.TakeDamage(baseDamage, false, Caster);

            return true;
        }
    }
}
