namespace ConsoleMenue
{
    using EasyPrototyping.Entity;

    using System;
    using System.Threading;
    using System.Windows;

    public class DemoEntityFirstname
    {
        public void CreateEntity()
        {
            Console.WriteLine("\nCreate empty Entity Value Object");

            Firstname entity = new Firstname();
            if (entity != null && string.IsNullOrEmpty(entity.Value) == true)
            {
                MessageBox.Show($"{entity.Value}\n{entity.PhoneticCode}");
            }

            Console.WriteLine("\nCreate Firstname Value Object");
            Firstname entity1 = new Firstname("gerhard");
            if (entity1 != null && string.IsNullOrEmpty(entity1.Value) == false)
            {
                MessageBox.Show($"Firstname: {entity1.Value}\nSoundEx:{entity1.PhoneticCode}\nFirstCharUpper:{entity1.FirstCharUpper}");
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
