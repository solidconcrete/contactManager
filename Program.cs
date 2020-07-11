using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using contactManager;
using Newtonsoft.Json;

namespace contactManager
{
    class Program
    {
        static void Main(string[] args)
        {

            UI ui = new UI();
            ui.start();
        }
    }
}

