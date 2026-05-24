using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMachine.Infrastructure.PLC
{
    public static class PLC
    {
        public static void Write(string tag, bool value)
        {
            Console.WriteLine($"{tag} = {value}");
        }

        public static void ReadHoldingRegisters(string tag, bool value)
        {
            Console.WriteLine($"{tag} = {value}");
        }

        public static void WriteSingleRegister(string tag, bool value)
        {
            Console.WriteLine($"{tag} = {value}");
        }
    }


}
