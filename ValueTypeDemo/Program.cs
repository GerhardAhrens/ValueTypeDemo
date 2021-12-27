using ConsoleMenue;

using EasyPrototyping.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using ValueTypeLibrary.Console;

public class Program
{
    private static List<MenueOption> options;

    private static void Main(string[] args)
    {
        options = new List<MenueOption>();
        options.Add(new MenueOption("Create Entity EMail [A]", () =>
        {
            new DemoEntityEMail().CreateEntity();
            ConsoleMenuSmall.WriteMenu(options, options.First());
        }, ConsoleKey.A));

        options.Add(new MenueOption("E[x]it", () => 
        { 
            Environment.Exit(0); 
        }));

        ConsoleMenuSmall.Run(options, options[0]);

        /*

        Firstname firstName = new Firstname("gerhard");
        if (firstName != null)
        {
            MessageBox.Show($"{firstName.Value}\n{firstName.PhoneticCode}");
        }

        Address adr1 = new Address("Deutschland", "68195", "Musterstadt", "Musterstrasse");
        if (adr1 != null)
        {
            Address adr2 = new Address("Deutschland", "68195", "Musterstadt", "Musterstrasse");
            if (adr1 == adr2)
            {
                Address adr3 = (Address)adr1.Clone();
                Address adr4 = adr1.CloneTo<Address>();
                var aa = adr1.GetProperties();
            }
        }
        */

    }
}
