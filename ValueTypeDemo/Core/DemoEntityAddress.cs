namespace ConsoleMenue
{
    using EasyPrototyping.Entity;

    using System;
    using System.Threading;
    using System.Windows;

    public class DemoEntityAddress
    {
        public void CreateEntity()
        {
            Console.WriteLine("\nCreate empty Entity Value Object");

            Address adr0 = new Address("", "", "", "","");
            if (adr0 == null || adr0.IsEmpty() == true)
            {
                MessageBox.Show("Leeres Adress-Objekt!");
            }

            Address adr1 = new Address("Deutschland", "68195", "Musterstadt", "Musterstrasse");
            if (adr1 != null)
            {
                Address adr2 = new Address("Deutschland", "68165", "Musterstadt", "Musterstrasse");
                if (adr1 == adr2)
                {
                    Address adr3 = (Address)adr1.Clone();
                    Address adr4 = adr1.CloneTo<Address>();
                    var aa = adr1.GetProperties();
                }
                else
                {
                    MessageBox.Show("Adresse 'adr1' und 'adr2' sind nicht gleich!");

                    Address adr3 = (Address)adr2.Clone();
                    if (adr2 == adr3)
                    {
                        MessageBox.Show("Adresse 'adr2' und 'adr3' sind gleich!");
                    }
                }
            }

            Thread.Sleep(1000);
        }
    }
}
