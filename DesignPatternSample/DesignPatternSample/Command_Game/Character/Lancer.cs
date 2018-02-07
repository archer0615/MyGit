using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game.Character
{
    public class Lancer : ICharacter
    {
        private string TrueName;
        public Lancer(string name)
        {
            this.TrueName = name;
        }
        public void Attack()
        {
            Console.WriteLine($"{this.TrueName}攻擊");
        }

        public void Avoid()
        {
            Console.WriteLine($"{this.TrueName}迴避");
        }

        public void Dash()
        {
            Console.WriteLine($"{this.TrueName}衝刺");
        }

        public void Defense()
        {
            Console.WriteLine($"{this.TrueName}防禦");
        }

        public void HoldWeapon()
        {
            Console.WriteLine("拿起武器");
        }

        public void Store()
        {
            Console.WriteLine("蓄力");
        }

        public void UnloadClothing()
        {
            Console.WriteLine("脫裝備");
        }

        public void UnloadWeapon()
        {
            Console.WriteLine("放下武器");
        }

        public void WearClothing()
        {
            Console.WriteLine("穿裝備");
        }
    }
}
