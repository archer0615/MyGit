using System;
using System.Reflection;

namespace DependencyInversionPrinciple
{
    internal class Case3
    {
        /// <summary>
        /// 食物種類 列舉型態
        /// </summary>
        public enum EnumFood
        {
            Rice = 0,
            Noodles = 1,
        }
        /// <summary>
        /// 人
        /// </summary>
        internal class People
        {
            private IFillStomach eating;
            public int Satiation { get; set; }
            public string ateFood { get; set; }

            internal People()
            {
                Satiation = 0;
                ateFood = "吃過";
            }
            internal void Eat(EnumFood Food)
            {
                switch (Food)
                {
                    case EnumFood.Rice:
                        eating = new Rice();
                        break;
                    case EnumFood.Noodles:
                        eating = new Noodles();
                        break;
                    default:
                        break;
                }
                Satiation = eating.eatFood(Satiation);
                ateFood += ("," + Enum.GetName(typeof(EnumFood), Food));
            }
        }
        /// <summary>
        /// 吃東西介面
        /// </summary>
        internal interface IFillStomach
        {
            int eatFood(int PeopleSatiation);
        }
        /// <summary>
        /// 基底食物類別
        /// </summary>
        internal abstract class Food
        {
            public string FoodName = string.Empty;

            public virtual string getFoodName()
            {
                return FoodName;
            }
            public abstract int Satiation { get; }
        }
        /// <summary>
        /// 飯 ,繼承基底食物類別, 繼承吃介面
        /// </summary>
        internal class Rice : Food, IFillStomach
        {
            public Rice()
            {
                base.FoodName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            }
            public override int Satiation { get { return 30; } }
            public int eatFood(int PeopleSatiation)
            {
                Console.WriteLine($"吃{FoodName}");
                return PeopleSatiation + Satiation;
            }
        }
        /// <summary>
        /// 麵 ,繼承基底食物類別, 繼承吃介面
        /// </summary>
        internal class Noodles : Food, IFillStomach
        {
            public Noodles()
            {
                base.FoodName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            }
            public override int Satiation { get { return 20; } }
            public int eatFood(int PeopleSatiation)
            {
                Console.WriteLine($"吃{FoodName}");
                return PeopleSatiation + Satiation;
            }
        }
    }
}