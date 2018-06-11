using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder_Pattern
{
    public class BPMain
    {
        public void Main()
        {
            Context ct = new Context();
            Profile p1 = new Profile.Builder(ct, "123456")
                .setIsActivated(true)
                .build();
            Console.WriteLine();
        }
    }
}
